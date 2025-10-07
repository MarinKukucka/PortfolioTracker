import { Button, Typography, Layout, Row, Col, Card } from "antd";
import {
    LineChartOutlined,
    WalletOutlined,
    BarChartOutlined,
} from "@ant-design/icons";

const { Title, Paragraph } = Typography;
const { Content, Footer } = Layout;

function LandingPage() {
    return (
        <Layout
            style={{
                minHeight: "100vh",
            }}
        >
            <Content style={{ padding: "80px 24px", textAlign: "center" }}>
                <Title>💰 PortfolioTracker</Title>
                <Paragraph
                    style={{
                        fontSize: "18px",
                        maxWidth: 600,
                        margin: "0 auto",
                    }}
                >
                    Track your crypto and stock investments in one place.
                    Analyze, visualize, and grow your portfolio — smarter.
                </Paragraph>
                <Button type="primary" size="large" style={{ marginTop: 24 }}>
                    Get Started
                </Button>

                {/* Features section */}
                <Row
                    gutter={[16, 16]}
                    style={{ marginTop: 80, justifyContent: "center" }}
                >
                    <Col xs={24} sm={12} md={8}>
                        <Card>
                            <WalletOutlined
                                style={{ fontSize: 36, color: "#1890ff" }}
                            />
                            <Title level={4} style={{ marginTop: 16 }}>
                                Multiple Portfolios
                            </Title>
                            <Paragraph>
                                Manage all your investments in one place.
                            </Paragraph>
                        </Card>
                    </Col>
                    <Col xs={24} sm={12} md={8}>
                        <Card>
                            <BarChartOutlined
                                style={{ fontSize: 36, color: "#52c41a" }}
                            />
                            <Title level={4} style={{ marginTop: 16 }}>
                                Smart Analytics
                            </Title>
                            <Paragraph>
                                Visualize your growth with charts and insights.
                            </Paragraph>
                        </Card>
                    </Col>
                    <Col xs={24} sm={12} md={8}>
                        <Card>
                            <LineChartOutlined
                                style={{ fontSize: 36, color: "#faad14" }}
                            />
                            <Title level={4} style={{ marginTop: 16 }}>
                                Real-Time Data
                            </Title>
                            <Paragraph>
                                Stay up to date with the latest market
                                movements.
                            </Paragraph>
                        </Card>
                    </Col>
                </Row>
            </Content>

            <Footer style={{ textAlign: "center", background: "transparent" }}>
                PortfolioTracker © {new Date().getFullYear()} — Made with ❤️
            </Footer>
        </Layout>
    );
}

export default LandingPage;
