import "./App.css";
import { createRouter, RouterProvider } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen";
import { useAuth0 } from "@auth0/auth0-react";
import { useEffect, useRef } from "react";
import {
    setupAuthInterceptor,
    setupAuthResponseInterceptor,
} from "./api/apiClient";
import { useCreateOrUpdateUserMutation } from "./api/users/users";
import axios from "axios";

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
    const prevAuthRef = useRef<boolean>(auth.isAuthenticated);
    const calledRef = useRef<boolean>(false);

    const { mutateAsync: createOrUpdateUser } = useCreateOrUpdateUserMutation();

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

    useEffect(() => {
        async function callApiAfterLogin() {
            try {
                const userInfoRes = await axios.get(
                    `https://${import.meta.env.VITE_AUTH0_DOMAIN}/userinfo`,
                    {
                        headers: {
                            Authorization: `Bearer ${await auth.getAccessTokenSilently()}`,
                        },
                    }
                );

                console.log(userInfoRes);

                await createOrUpdateUser({
                    email: userInfoRes.data.email,
                    name: userInfoRes.data.name,
                });
            } catch (err) {
                console.error("Error with calling API on login: ", err);
            }
        }

        if (auth.isLoading) return;

        if (
            !prevAuthRef.current &&
            auth.isAuthenticated &&
            !calledRef.current
        ) {
            calledRef.current = true;

            callApiAfterLogin();
        }

        prevAuthRef.current = auth.isAuthenticated;
    }, [auth, createOrUpdateUser]);

    return <RouterProvider context={{ auth }} router={router} />;
}

export default App;
