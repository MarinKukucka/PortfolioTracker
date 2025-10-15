import { Link, Outlet } from "@tanstack/react-router";
import { Layout as AntdLayout, Button, Typography } from "antd";
import { Content, Footer, Header } from "antd/es/layout/layout";
import logo from "../../assets/logo.png";
import { useAuth0 } from "@auth0/auth0-react";

const { Title } = Typography;

function PublicLayout() {
    const { loginWithRedirect } = useAuth0();
    return (
        <AntdLayout>
            <Header
                style={{
                    position: "sticky",
                    top: 0,
                    zIndex: 1,
                    width: "100%",
                    height: 80,
                    display: "flex",
                    justifyContent: "space-between",
                    padding: "0 400px",
                }}
            >
                <Link
                    to="/"
                    style={{
                        display: "flex",
                        alignItems: "center",
                    }}
                >
                    <img src={logo} height={80} />
                    <Title
                        level={3}
                        style={{
                            color: "white",
                            margin: 0,
                        }}
                    >
                        Portfolio Tracker
                    </Title>
                </Link>
                <div style={{ display: "flex", gap: 40 }}>
                    <div
                        style={{
                            display: "flex",
                            gap: 40,
                            alignItems: "center",
                        }}
                    >
                        <Link to="/" style={{ color: "white" }}>
                            Features
                        </Link>
                        <Link to="/" style={{ color: "white" }}>
                            Pricing
                        </Link>
                        <Link to="/" style={{ color: "white" }}>
                            About us
                        </Link>
                    </div>
                    <div
                        style={{
                            display: "flex",
                            gap: 20,
                            alignItems: "center",
                        }}
                    >
                        <Button onClick={() => loginWithRedirect()}>
                            Log in
                        </Button>
                        <Button type="primary">Sign up</Button>
                    </div>
                </div>
            </Header>
            <Content>
                <Outlet />
            </Content>
            <Footer style={{ textAlign: "center" }}>
                Portfolio Tracker ©2024 Created by Marin Kukučka
            </Footer>
        </AntdLayout>
    );
}

export default PublicLayout;
