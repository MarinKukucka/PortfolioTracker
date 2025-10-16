import { api } from "../apiClient";
import type { UserDTO } from "./usersTypes";

export async function getUserById(id: string, signal?: AbortSignal): Promise<UserDTO> {
    if(id === undefined || id === null)
        throw new globalThis.Error("The parameter 'id' must be defined.");

    const res = (await api.get(`/api/user/${id}`, { signal }));

    return res.data;
}