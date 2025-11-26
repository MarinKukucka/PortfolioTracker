import type { TransactionType } from "../../config/enums"

export type TransactionDTO = {
    id: string;
    type: TransactionType;
    quantity: number;
    unitPrice: number;
    transactionDateTime: Date;
}

export type AddTransactionCommand = {
    type: TransactionType;
    quantity: number;
    unitPrice: number;
    totalPrice: number;
    portfolioId: string;
    assetId: string;
}