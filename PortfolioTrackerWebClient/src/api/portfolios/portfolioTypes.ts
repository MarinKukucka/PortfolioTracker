export type PortfolioDTO = {
    id: string;
    name: string;
    isDefault: boolean;
    value: number;
    assets: PortfolioAssetDTO[];
}

export type PortfolioAssetDTO = {
    quantity: number;
    assetSymbol: string;
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