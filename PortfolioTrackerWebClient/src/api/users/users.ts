import { useQuery } from "@tanstack/react-query";
import { getUserById } from "./usersApi";

export const useFetchUserByIdQuery = (id: string) => {
    return useQuery({
        queryKey: ["user", id],
        queryFn: async ({signal}) => {
            return await getUserById(id, signal);
        }
    })
}
    