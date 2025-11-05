import { api } from "../apiClient";
import type { CreatePortfolioCommand, PortfolioDTO, UpdatePortfolioCommand } from "./portfolioTypes";

export async function getPortoflios(signal?: AbortSignal): Promise<PortfolioDTO[]> {
    const res = await api.get(`/api/portfolio`, { signal });

    return res.data;
}

export async function getPortfolioById(id: string, signal?: AbortSignal): Promise<PortfolioDTO> {
    const res = await api.get(`/api/portfolio/${id}`, { signal })

    return res.data;
}

export async function createPortfolio(command: CreatePortfolioCommand, signal?: AbortSignal): Promise<void> {
    await api.post(`/api/portfolio`, command, { signal });
}

export async function updatePortfolio(command: UpdatePortfolioCommand, signal?: AbortSignal): Promise<void> {
    await api.put(`/api/portfolio`, command, { signal });
}

export async function deletePortfolio(id: string, signal?: AbortSignal): Promise<void> {
    await api.delete(`/api/portfolio/${id}`, { signal });
}