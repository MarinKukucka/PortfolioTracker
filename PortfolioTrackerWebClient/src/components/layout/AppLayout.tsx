import { Outlet } from "@tanstack/react-router";
import { useState } from "react";
import { theme as antdTheme, ConfigProvider, Layout as AntLayout } from "antd";
import Sider from "antd/es/layout/Sider";
import SiderMenu from "./SiderMenu";
import { useAuth0 } from "@auth0/auth0-react";

const { Content } = AntLayout;

interface Props {
    children?: React.ReactNode;
}

function AppLayout({ children }: Props) {
    const { user, isLoading } = useAuth0();

    const [selectedKey, setSelectedKey] = useState("home");
    const [darkMode, setDarkMode] = useState(false);

    const theme = {
        algorithm: darkMode
            ? antdTheme.darkAlgorithm
            : antdTheme.defaultAlgorithm,
    };

    if (isLoading) {
        return <div>Loading...</div>;
    }

    return (
        <ConfigProvider theme={theme}>
            <AntLayout style={{ minHeight: "100vh" }}>
                <Sider>
                    <SiderMenu
                        selectedKey={selectedKey}
                        setSelectedKey={setSelectedKey}
                        darkMode={darkMode}
                        setDarkMode={setDarkMode}
                    />
                </Sider>
                <Content>
                    <div>{user?.name}</div>
                    {user?.email}
                    {children}
                    <Outlet />
                </Content>
            </AntLayout>
            <Outlet />
        </ConfigProvider>
    );
}

export default AppLayout;
