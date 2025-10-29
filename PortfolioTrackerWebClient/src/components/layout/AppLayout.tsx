import { Outlet } from "@tanstack/react-router";
import { useState } from "react";
import { theme as antdTheme, ConfigProvider, Layout as AntLayout } from "antd";
import Sider from "antd/es/layout/Sider";
import SiderMenu from "./SiderMenu";
import { useAuth0 } from "@auth0/auth0-react";
import styles from "./AppLayout.module.css";

const { Content } = AntLayout;

function AppLayout() {
    const { isLoading } = useAuth0();

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
            <AntLayout className={styles.container}>
                <Sider>
                    <SiderMenu
                        selectedKey={selectedKey}
                        setSelectedKey={setSelectedKey}
                        darkMode={darkMode}
                        setDarkMode={setDarkMode}
                    />
                </Sider>
                <Content>
                    <Outlet />
                </Content>
            </AntLayout>
        </ConfigProvider>
    );
}

export default AppLayout;
