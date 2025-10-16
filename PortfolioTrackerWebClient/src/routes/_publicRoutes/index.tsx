import { createFileRoute } from "@tanstack/react-router";
import { useFetchUserByIdQuery } from "../../api/users/users";

export const Route = createFileRoute("/_publicRoutes/")({
    component: RouteComponent,
});

function RouteComponent() {
    const { data: user } = useFetchUserByIdQuery("1");

    return (
        <>
            <div>Hello "/_publicRoutes/"!</div>
            <div>{user?.id}</div>
            <div>{user?.email}</div>
            <div>{user?.displayName}</div>
        </>
    );
}
