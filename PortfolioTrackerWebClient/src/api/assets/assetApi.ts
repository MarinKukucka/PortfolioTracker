import type { OptionDTO } from "../../config/commonTypes";
import { api } from "../apiClient";

export async function getAssetOptions(signal?: AbortSignal): Promise<OptionDTO[]> {
    const res = await api.get('/api/asset/options', { signal });

    return res.data;
}