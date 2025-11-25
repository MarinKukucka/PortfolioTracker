import { useQuery } from "@tanstack/react-query"
import { getAssetOptions } from "./assetApi"
import { formatSelectOptions } from "../../helpers/OptionsMappingsHelper"

export const useFetchAssetOptions = () => {
    return useQuery({
        queryKey: ["assetOptions"],
        queryFn: async () => {
            return formatSelectOptions(await getAssetOptions());
        }
    })
}