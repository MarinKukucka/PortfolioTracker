import { Menu, Switch, type MenuProps } from "antd";

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
