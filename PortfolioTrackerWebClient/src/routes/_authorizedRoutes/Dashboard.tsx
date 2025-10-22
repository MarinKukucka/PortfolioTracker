import { createFileRoute } from "@tanstack/react-router";
import { useFetchPortfolios } from "../../api/portfolios/portfolios";

export const Route = createFileRoute("/_authorizedRoutes/Dashboard")({
    component: RouteComponent,
});

function RouteComponent() {
    const { data: portfolios } = useFetchPortfolios();

    return (
        <>
            <div>Hello "/_authorizedRoutes/Dashboard"!</div>
            <div>
                {portfolios && portfolios?.length !== 0 ? (
                    portfolios.map((p) => p.id)
                ) : (
                    <>No portfolio</>
                )}
            </div>
        </>
    );
}
