import { List } from "antd";
import { useNavigate } from "@tanstack/react-router";
import type { PortfolioDTO } from "../../../api/portfolios/portfolioTypes";

interface Props {
    portfolios: PortfolioDTO[];
}

function PortfolioList({ portfolios }: Props) {
    const navigate = useNavigate();

    return (
        <List
            itemLayout="vertical"
            dataSource={portfolios}
            renderItem={(portfolio) => (
                <List.Item id={portfolio.id}>
                    <List.Item.Meta
                        title={
                            <a
                                onClick={() =>
                                    navigate({
                                        to: "/Portfolios/$id",
                                        params: { id: portfolio.id },
                                    })
                                }
                            >
                                {portfolio.name}
                            </a>
                        }
                    />
                </List.Item>
            )}
        />
    );
}

export default PortfolioList;
