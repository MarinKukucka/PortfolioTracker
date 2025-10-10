import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/_authorization/Login")({
    component: Login,
});

function Login() {
    return <>This is login</>;
}
