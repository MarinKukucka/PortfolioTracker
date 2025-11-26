import { api } from "../apiClient";
import type { AddTransactionCommand, TransactionDTO } from "./transactionTypes";

export async function getTransactionsByPortfolioAndAssetId(portfolioId: string, assetId: string, signal?: AbortSignal): Promise<TransactionDTO[]> {
    const res = await api.get(`/api/transaction?portfolioId=${portfolioId}&assetId=${assetId}`, { signal });

    return res.data;
} 

export async function addTransaction(command: AddTransactionCommand): Promise<void> {
    await api.post('/api/transaction', command);
}