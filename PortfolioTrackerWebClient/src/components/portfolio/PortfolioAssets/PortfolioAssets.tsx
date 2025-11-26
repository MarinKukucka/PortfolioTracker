import { List } from "antd";
import type { PortfolioAssetDTO } from "../../../api/portfolios/portfolioTypes";
import styles from "./PortfolioAssets.module.css";
import { Link } from "@tanstack/react-router";

interface Props {
    assets?: PortfolioAssetDTO[];
    portfolioId: string;
}

function PortfolioAssets({ assets, portfolioId }: Props) {
    return (
        <List
            className={styles.assetList}
            itemLayout="horizontal"
            dataSource={assets}
            renderItem={(item) => (
                <List.Item>
                    <List.Item.Meta
                        avatar={item.assetSymbol}
                        title={
                            <Link
                                to="/Portfolios/$id/Transactions/$assetId"
                                params={{
                                    id: portfolioId,
                                    assetId: item.assetId,
                                }}
                            >
                                {item.value + "$"}
                            </Link>
                        }
                    />
                </List.Item>
            )}
        />
    );
}

export default PortfolioAssets;
