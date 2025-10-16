import "./App.css";
import { createRouter, RouterProvider } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen";
import { useAuth0 } from "@auth0/auth0-react";
import { useEffect } from "react";
import {
    setupAuthInterceptor,
    setupAuthResponseInterceptor,
} from "./api/apiClient";

const router = createRouter({
    routeTree,
    context: { auth: undefined! },
    defaultNotFoundComponent: () => <div>Page not found</div>,
});

declare module "@tanstack/react-router" {
    interface Register {
        router: typeof router;
    }
}

function App() {
    const auth = useAuth0();

    useEffect(() => {
        if (!auth.getAccessTokenSilently) return;

        const ejectRequest = setupAuthInterceptor(auth.getAccessTokenSilently);

        const ejectResponse = setupAuthResponseInterceptor(
            // eslint-disable-next-line @typescript-eslint/no-explicit-any
            auth.getAccessTokenSilently as any
        );

        return () => {
            ejectRequest();
            ejectResponse();
        };
    }, [auth.getAccessTokenSilently]);

    return <RouterProvider context={{ auth }} router={router} />;
}

export default App;
