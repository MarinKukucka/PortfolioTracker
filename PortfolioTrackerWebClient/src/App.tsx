import "./App.css";
import { createRouter, RouterProvider } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen";
import { useAuth0 } from "@auth0/auth0-react";

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

    return <RouterProvider context={{ auth }} router={router} />;
}

export default App;
