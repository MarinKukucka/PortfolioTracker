import { Outlet } from "@tanstack/react-router";

function PublicLayout() {
    return (
        <div>
            {/* Centriranje kartice za login i slično */}
            <Outlet />
        </div>
    );
}

export default PublicLayout;
