import { createFileRoute } from "@tanstack/react-router";
import { useFetchTransactionsByPortfolioAndAssetId } from "../../../../../../api/transactions/transactions";

export const Route = createFileRoute(
    "/_authorizedRoutes/Portfolios/$id/Transactions/$assetId/"
)({
    component: TransactionsPage,
});

function TransactionsPage() {
    const { id, assetId } = Route.useParams();

    const { data: transactions } = useFetchTransactionsByPortfolioAndAssetId(
        id,
        assetId
    );

    return (
        <div>
            Hello "/_authorizedRoutes/Portfolios/$id/Transactions/$assetId/"!
            {transactions?.map((transaction) => (
                <p>{transaction.id}</p>
            ))}
        </div>
    );
}
