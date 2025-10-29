import { Outlet } from "@tanstack/react-router";
import { Layout as AntdLayout } from "antd";
import { Content, Footer } from "antd/es/layout/layout";
import HeaderMenu from "./HeaderMenu";
import styles from "./PublicLayout.module.css";

function PublicLayout() {
    return (
        <AntdLayout>
            <HeaderMenu />
            <Content>
                <Outlet />
            </Content>
            <Footer className={styles.footerContainer}>
                Portfolio Tracker ©2024 Created by Marin Kukučka
            </Footer>
        </AntdLayout>
    );
}

export default PublicLayout;
