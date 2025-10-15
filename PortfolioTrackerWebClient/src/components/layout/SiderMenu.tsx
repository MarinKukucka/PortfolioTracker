import { useAuth0 } from "@auth0/auth0-react";
import { Button, Menu, Switch, type MenuProps } from "antd";

type MenuItem = Required<MenuProps>["items"][number];

interface Props {
    selectedKey: string;
    setSelectedKey: (key: string) => void;
    darkMode: boolean;
    setDarkMode: (darkMode: boolean) => void;
}

function SiderMenu({
    selectedKey,
    setSelectedKey,
    darkMode,
    setDarkMode,
}: Props) {
    const { logout } = useAuth0();

    const items: MenuItem[] = [
        {
            key: "themeMode",
            label: (
                <Switch
                    checkedChildren={"MOON"}
                    unCheckedChildren={"SUN"}
                    onChange={() => setDarkMode(!darkMode)}
                />
            ),
        },
        {
            key: "logout",
            label: (
                <Button
                    onClick={() =>
                        logout({
                            logoutParams: { returnTo: window.location.origin },
                        })
                    }
                >
                    Log out
                </Button>
            ),
        },
    ];

    return (
        <Menu
            onClick={({ key }) => setSelectedKey(key)}
            selectedKeys={[selectedKey]}
            mode="vertical"
            items={items}
        />
    );
}

export default SiderMenu;
