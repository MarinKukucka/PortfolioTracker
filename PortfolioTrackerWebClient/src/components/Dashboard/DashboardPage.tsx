import {
    Layout,
    Menu,
    Card,
    Statistic,
    Typography,
    Row,
    Col,
    Switch,
} from "antd";
import { PieChartOutlined, WalletOutlined } from "@ant-design/icons";

const { Header, Content, Sider } = Layout;

interface Props {
    darkMode: boolean;
    setDarkMode: (value: boolean) => void;
}

function DashboardPage({ darkMode, setDarkMode }: Props) {
    return (
        <Layout style={{ minHeight: "100vh" }}>
            <Sider breakpoint="lg" collapsedWidth="0">
                <div
                    style={{
                        padding: 16,
                        textAlign: "center",
                        color: "white",
                        fontWeight: "bold",
                    }}
                >
                    💰 PortfolioTracker
                </div>
                <Menu
                    theme="dark"
                    mode="inline"
                    items={[
                        {
                            key: "1",
                            icon: <PieChartOutlined />,
                            label: "Dashboard",
                        },
                        {
                            key: "2",
                            icon: <WalletOutlined />,
                            label: "Portfolios",
                        },
                        {
                            key: "3",
                            icon: (
                                <Switch
                                    checkedChildren="🌙"
                                    unCheckedChildren="☀️"
                                    checked={darkMode}
                                    onChange={setDarkMode}
                                />
                            ),
                        },
                    ]}
                />
            </Sider>
            <Layout>
                <Header
                    style={{
                        background: "transparent",
                        color: "white",
                        padding: 16,
                    }}
                >
                    <Typography.Title
                        level={3}
                        style={{ color: "white", margin: 0 }}
                    >
                        Dashboard Overview
                    </Typography.Title>
                </Header>
                <Content style={{ margin: "24px 16px" }}>
                    <Row gutter={[16, 16]}>
                        <Col span={6}>
                            <Card>
                                <Statistic
                                    title="Total Value"
                                    value={25320}
                                    prefix="$"
                                />
                            </Card>
                        </Col>
                        <Col span={6}>
                            <Card>
                                <Statistic
                                    title="Change (24h)"
                                    value={1.25}
                                    suffix="%"
                                    precision={2}
                                />
                            </Card>
                        </Col>
                    </Row>
                </Content>
            </Layout>
        </Layout>
    );
}

export default DashboardPage;
