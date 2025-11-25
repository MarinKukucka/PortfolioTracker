import { List } from "antd";
import type { PortfolioAssetDTO } from "../../../api/portfolios/portfolioTypes";
import styles from "./PortfolioAssets.module.css";

interface Props {
    assets?: PortfolioAssetDTO[];
}

function PortfolioAssets({ assets }: Props) {
    return (
        <List
            className={styles.assetList}
            itemLayout="horizontal"
            dataSource={assets}
            renderItem={(item) => (
                <List.Item>
                    <List.Item.Meta
                        avatar={item.assetSymbol}
                        title={item.value + "$"}
                    />
                </List.Item>
            )}
        />
    );
}

export default PortfolioAssets;
