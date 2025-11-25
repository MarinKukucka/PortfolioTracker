import { api } from "../apiClient";
import type { AddTransactionCommand } from "./transactionTypes";

export async function addTransaction(command: AddTransactionCommand): Promise<void> {
    await api.post('/api/transaction', command);
}