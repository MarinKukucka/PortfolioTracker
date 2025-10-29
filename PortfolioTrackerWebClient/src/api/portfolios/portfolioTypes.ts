export type PortfolioDTO = {
    id: string;
    name: string;
    isDefault: boolean;
    value: number;
}

export type CreatePortfolioCommand = {
    name: string;
    description?: string;
}

export type UpdatePortfolioCommand = {
    id: string;
    name: string;
    description?: string;
}