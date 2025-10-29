import { List } from "antd";
import type { PortfolioDTO } from "../../api/portfolios/portfolioTypes";

interface Props {
    portfolios: PortfolioDTO[];
}

function PortfolioList({ portfolios }: Props) {
    return (
        <List
            itemLayout="vertical"
            dataSource={portfolios}
            renderItem={(portfolio) => (
                <List.Item>
                    <List.Item.Meta title={<a>{portfolio.name}</a>} />
                </List.Item>
            )}
        />
    );
}

export default PortfolioList;
