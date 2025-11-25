import { useMutation } from "@tanstack/react-query";
import { createOrUpdateUser } from "./userApi";
import type { UserInfo } from "./userTypes";
    
export const useCreateOrUpdateUserMutation = () => {
    return useMutation({
        mutationFn: async (userInfo: UserInfo) => {
            return await createOrUpdateUser(userInfo);
        }
    })
}