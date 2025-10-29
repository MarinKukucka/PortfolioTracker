import { useMutation } from "@tanstack/react-query";
import { createOrUpdateUser } from "./usersApi";
import type { UserInfo } from "./usersTypes";
    
export const useCreateOrUpdateUserMutation = () => {
    return useMutation({
        mutationFn: async (userInfo: UserInfo) => {
            return await createOrUpdateUser(userInfo);
        }
    })
}