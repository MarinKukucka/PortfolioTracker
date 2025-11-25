import { useMutation, useQueryClient } from "@tanstack/react-query"
import type { AddTransactionCommand } from "./transactionTypes"
import { addTransaction } from "./transactionApi"
import { message } from "antd";

export const useAddTransactionMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async (command: AddTransactionCommand) => {
            return await addTransaction(command);
        },
        onSuccess: (_, command) => {
            message.success('Transaction added successfully');
            queryClient.invalidateQueries({queryKey: ['portfolio', command.portfolioId]});
        },
        onError: () => {
            message.error('Failed to add transaction');
        }
    })
}