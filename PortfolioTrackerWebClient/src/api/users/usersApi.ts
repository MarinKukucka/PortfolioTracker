import { api } from "../apiClient";
import type { UserInfo } from "./usersTypes";

export async function createOrUpdateUser(userInfo: UserInfo): Promise<void> {
    await api.put('/api/user', userInfo);
}