import { Link } from "@tanstack/react-router";
import { Header } from "antd/es/layout/layout";
import logo from "../../assets/logo.png";
import { Button, Typography } from "antd";
import { useAuth0 } from "@auth0/auth0-react";
import styles from "./HeaderMenu.module.css";

const { Title } = Typography;

function HeaderMenu() {
    const { loginWithRedirect } = useAuth0();

    return (
        <Header className={styles.container}>
            <Link to="/" className={styles.logoLink}>
                <img src={logo} height={80} />
                <Title level={3} className={styles.title}>
                    Portfolio Tracker
                </Title>
            </Link>
            <div className={styles.menuContainer}>
                <div className={styles.linksContainer}>
                    <Link to="/" className={styles.link}>
                        Features
                    </Link>
                    <Link to="/" className={styles.link}>
                        Pricing
                    </Link>
                    <Link to="/" className={styles.link}>
                        About us
                    </Link>
                </div>
                <div className={styles.authButtonsContainer}>
                    <Button onClick={() => loginWithRedirect()}>Log in</Button>
                    <Button type="primary">Sign up</Button>
                </div>
            </div>
        </Header>
    );
}

export default HeaderMenu;
