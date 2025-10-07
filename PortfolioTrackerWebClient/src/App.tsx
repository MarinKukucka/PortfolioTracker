import { ConfigProvider } from "antd";
import "./App.css";
import DashboardPage from "./components/Dashboard/DashboardPage";
import { useState } from "react";
import { theme as antdTheme } from "antd";
import { useAuth0 } from "@auth0/auth0-react";
import LandingPage from "./components/LandingPage/LandingPage";

function App() {
    const { isAuthenticated } = useAuth0();
    const [darkMode, setDarkMode] = useState(true);

    const theme = {
        algorithm: darkMode
            ? antdTheme.darkAlgorithm
            : antdTheme.defaultAlgorithm,
    };

    return (
        <ConfigProvider theme={theme}>
            {isAuthenticated ? (
                <DashboardPage darkMode={darkMode} setDarkMode={setDarkMode} />
            ) : (
                <LandingPage />
            )}
        </ConfigProvider>
    );
}

export default App;
