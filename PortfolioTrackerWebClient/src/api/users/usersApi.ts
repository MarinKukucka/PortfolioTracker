import { api } from "../apiClient";
import type { UserDTO, UserInfo } from "./usersTypes";

export async function createOrUpdateUser(userInfo: UserInfo): Promise<void> {
    await api.put('/api/user', userInfo);
}

export async function getUserById(authId: string, signal?: AbortSignal): Promise<UserDTO> {
    if(authId === undefined || authId === null)
        throw new globalThis.Error("The parameter 'authId' must be defined.");

    const res = await api.get(`/api/user/${authId}`, { signal });

    return res.data;
}