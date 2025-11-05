import { createFileRoute } from "@tanstack/react-router";
import { useFetchPortfolioById } from "../../../../api/portfolios/portfolios";

export const Route = createFileRoute("/_authorizedRoutes/Portfolios/$id/")({
    component: PortfolioPage,
});

function PortfolioPage() {
    const { id } = Route.useParams();

    const { data: portfolio } = useFetchPortfolioById(id);

    return (
        <>
            <div>{portfolio?.id}</div>
            <div>{portfolio?.name}</div>
            <div>{portfolio?.value}</div>
        </>
    );
}
