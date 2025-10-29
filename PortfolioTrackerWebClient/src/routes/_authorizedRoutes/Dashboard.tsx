import { createFileRoute } from "@tanstack/react-router";
import {
    useCreatePortfolioMutation,
    useFetchPortfolios,
} from "../../api/portfolios/portfolios";
import { Button, Form, Input, Modal } from "antd";
import { useCallback, useState } from "react";
import type { CreatePortfolioCommand } from "../../api/portfolios/portfolioTypes";
import FormButtons from "../../components/form/FormButtons";
import PortfolioList from "../../components/portfolio/PortfolioList";
import styles from "./Dashboard.module.css";

export const Route = createFileRoute("/_authorizedRoutes/Dashboard")({
    component: RouteComponent,
});

function RouteComponent() {
    const [isCreateModalOpen, setIsCreateModalOpen] = useState(false);

    const { data: portfolios } = useFetchPortfolios();

    const { mutateAsync: createPortfolio, isPending: isCreatePending } =
        useCreatePortfolioMutation();

    const onSubmit = useCallback(
        async (command: CreatePortfolioCommand) => {
            try {
                await createPortfolio(command);

                setIsCreateModalOpen(false);
            } catch {
                setIsCreateModalOpen(false);
            }
        },
        [createPortfolio]
    );

    return (
        <>
            <Button onClick={() => setIsCreateModalOpen(true)}>
                Add portfolio
            </Button>
            <div className={styles.listContainer}>
                {portfolios && portfolios?.length !== 0 && (
                    <PortfolioList portfolios={portfolios} />
                )}
            </div>

            <Modal
                open={isCreateModalOpen}
                footer={null}
                onCancel={() => setIsCreateModalOpen(false)}
            >
                <Form
                    onFinish={onSubmit}
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 16 }}
                >
                    <Form.Item
                        label="Name"
                        name="name"
                        rules={[{ required: true }]}
                    >
                        <Input />
                    </Form.Item>
                    <Form.Item label="Description" name="description">
                        <Input.TextArea />
                    </Form.Item>
                    <FormButtons disabled={isCreatePending} />
                </Form>
            </Modal>
        </>
    );
}
