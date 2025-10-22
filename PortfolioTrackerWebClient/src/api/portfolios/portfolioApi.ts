import { api } from "../apiClient";
import type { PortfolioDTO } from "./portfolioTypes";

export async function getPortoflios(signal?: AbortSignal): Promise<PortfolioDTO[]> {
    const res = await api.get(`/api/portfolio`, { signal });

    return res.data;
}