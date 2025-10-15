import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_authorizedRoutes/Dashboard")({
    component: RouteComponent,
});

function RouteComponent() {
    return <div>Hello "/_authorizedRoutes/Dashboard"!</div>;
}
