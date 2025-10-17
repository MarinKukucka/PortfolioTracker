import { useMutation, useQuery } from "@tanstack/react-query";
import { createOrUpdateUser, getUserById } from "./usersApi";
import type { UserInfo } from "./usersTypes";

export const useFetchUserByIdQuery = (authId: string) => {
    return useQuery({
        queryKey: ["user", authId],
        queryFn: async ({signal}) => {
            return await getUserById(authId, signal);
        }
    })
}
    
export const useCreateOrUpdateUserMutation = () => {
    return useMutation({
        mutationFn: async (userInfo: UserInfo) => {
            return await createOrUpdateUser(userInfo);
        }
    })
}