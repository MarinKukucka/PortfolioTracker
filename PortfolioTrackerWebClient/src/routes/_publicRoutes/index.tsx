import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_publicRoutes/")({
    component: RouteComponent,
});

function RouteComponent() {
    return (
        <>
            <div>Hello "/_publicRoutes/"!</div>
        </>
    );
}
