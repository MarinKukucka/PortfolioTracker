import { useQuery } from "@tanstack/react-query"
import { getPortoflios } from "./portfolioApi";

export const useFetchPortfolios = () => {
    return useQuery({
        queryKey: ['portfolios'],
        queryFn: async ({signal}) => {
            return await getPortoflios(signal);
        }
    })
}