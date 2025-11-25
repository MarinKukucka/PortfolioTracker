import type { PortfolioAssetDTO } from "../../api/portfolios/portfolioTypes";

interface Props {
    assets?: PortfolioAssetDTO[];
}

function PortfolioAssets({ assets }: Props) {
    return <>{assets && assets.map((asset) => <p>{asset.assetSymbol}</p>)}</>;
}

export default PortfolioAssets;
