import { createFileRoute, redirect } from "@tanstack/react-router";

export const Route = createFileRoute("/_authorizedRoutes")({
    beforeLoad: ({ context }) => {
        if (!context.auth.isAuthenticated) {
            throw redirect({ to: "/" });
        }
    },
});
