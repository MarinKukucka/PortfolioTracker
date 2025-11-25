import { api } from "../apiClient";
import type { UserInfo } from "./userTypes";

export async function createOrUpdateUser(userInfo: UserInfo): Promise<void> {
    await api.put('/api/user', userInfo);
}