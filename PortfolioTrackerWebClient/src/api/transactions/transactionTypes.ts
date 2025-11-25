import type { TransactionType } from "../../config/enums"

export type AddTransactionCommand = {
    type: TransactionType;
    quantity: number;
    unitPrice: number;
    totalPrice: number;
    portfolioId: string;
    assetId: string;
}