import { useAuth0, type Auth0ContextInterface } from "@auth0/auth0-react";
import { createRootRouteWithContext } from "@tanstack/react-router";
import AppLayout from "../components/layout/AppLayout/AppLayout";
import PublicLayout from "../components/layout/PublicLayout/PublicLayout";

type RouterContext = {
    auth: Auth0ContextInterface;
};

export const Route = createRootRouteWithContext<RouterContext>()({
    component: RootComponent,
});

function RootComponent() {
    const { isAuthenticated } = useAuth0();

    return isAuthenticated ? <AppLayout /> : <PublicLayout />;
}
