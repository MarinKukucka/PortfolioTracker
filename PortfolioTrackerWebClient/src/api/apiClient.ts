import axios, { AxiosHeaders } from "axios";
const API_BASE = import.meta.env.VITE_API_BASE || "https://localhost:7195";

export const api = axios.create({
    baseURL: API_BASE
  });

export function setupAuthInterceptor(getAccessTokenSilently: () => Promise<string>) {
  const id = api.interceptors.request.use(
    async (config) => {
      try {
        const token = await getAccessTokenSilently();
        if(token){
          const headers = new AxiosHeaders(config.headers ?? {});
          headers.set("Authorization", `Bearer ${token}`);
          config.headers = headers;
        }
      }
      catch (error) {
        console.warn("Failed to get token for request", error);
      }

      return config;
    },
    (error) => Promise.reject(error)
  );

  return () => api.interceptors.request.eject(id);
}

export function setupAuthResponseInterceptor(getAccessTokenSilently: (opts?: { ignoreCache?: boolean }) => Promise<string>) {
  const id = api.interceptors.response.use(
    (res) => res,
    async (error) => {
      const originalRequest = error?.config;
      if (!originalRequest) return Promise.reject(error);

      if (error.response?.status === 401 && !originalRequest._retry) {
        originalRequest._retry = true;
        try {
          // eslint-disable-next-line @typescript-eslint/no-explicit-any
          const token = await getAccessTokenSilently({ ignoreCache: true } as any);
          if (token) {
            const headers = new AxiosHeaders(originalRequest.headers ?? {});
            headers.set("Authorization", `Bearer ${token}`);
            originalRequest.headers = headers;
            return api(originalRequest);
          }
        } catch (error) {
          console.warn(error);
        }
      }
      return Promise.reject(error);
    }
  );

  return () => api.interceptors.response.eject(id);
}