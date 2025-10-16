import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.tsx";
import { Auth0Provider } from "@auth0/auth0-react";
import { QueryClientProvider } from "@tanstack/react-query";
import { queryClient } from "./config/queryClient.ts";

createRoot(document.getElementById("root")!).render(
    <QueryClientProvider client={queryClient}>
        <Auth0Provider
            domain={import.meta.env.VITE_AUTH0_DOMAIN}
            clientId={import.meta.env.VITE_AUTH0_CLIENT_ID}
            authorizationParams={{
                redirect_uri:
                    import.meta.env.VITE_AUTH0_REDIRECT_URI ||
                    window.location.origin,
                audience: import.meta.env.VITE_AUTH0_AUDIENCE,
            }}
            cacheLocation="memory"
        >
            <App />
        </Auth0Provider>
    </QueryClientProvider>
);
