import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import { createPortfolio, deletePortfolio, getPortfolioById, getPortoflios, updatePortfolio } from "./portfolioApi";
import type { CreatePortfolioCommand, UpdatePortfolioCommand } from "./portfolioTypes";
import { message } from "antd";

export const useFetchPortfolios = () => {
    return useQuery({
        queryKey: ['portfolios'],
        queryFn: async ({ signal }) => {
            return await getPortoflios(signal);
        }
    })
}

export const useFetchPortfolioById = (id: string) => {
    return useQuery({
        queryKey: ['portfolio', id],
        queryFn: async ({ signal} ) => {
            return await getPortfolioById(id, signal);
        }
    })
}

export const useCreatePortfolioMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async (command: CreatePortfolioCommand) => {
            return await createPortfolio(command);
        },
        onSuccess: () => {
            message.success('Portfolio created successfully');
            queryClient.invalidateQueries({ queryKey: ['portfolios'] });
        },
        onError: () => {
            message.error('Failed to create portfolio');
        }
    })
}

export const useUpdatePortfolioMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async (command: UpdatePortfolioCommand) => {
            return await updatePortfolio(command);
        },
        onSuccess: () => {
            message.success('Portfolio updated successfully');
            queryClient.invalidateQueries({ queryKey: ['portfolios'] });
        },
        onError: () => {
            message.error('Failed to update portfolio');
        }
    })
}

export const useDeletePortfolioMutation = () => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async (id: string) => {
            return await deletePortfolio(id);
        },
        onSuccess: () => {
            message.success('Portfolio deleted successfully');
            queryClient.invalidateQueries({ queryKey: ['portfolios'] });
        },
        onError: () => {
            message.error('Failed to delete portfolio');
        }
    })
}