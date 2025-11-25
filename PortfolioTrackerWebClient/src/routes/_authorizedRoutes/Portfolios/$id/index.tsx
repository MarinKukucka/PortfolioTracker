import { createFileRoute } from "@tanstack/react-router";
import { useFetchPortfolioById } from "../../../../api/portfolios/portfolios";
import styles from "./index.module.css";
import PortfolioHeader from "../../../../components/portfolio/PortfolioHeader";
import { Button, Form, InputNumber, Modal, Select, Spin } from "antd";
import PortfolioAssets from "../../../../components/portfolio/PortfolioAssets";
import { useCallback, useState } from "react";
import { useAddTransactionMutation } from "../../../../api/transactions/transactions";
import type { AddTransactionCommand } from "../../../../api/transactions/transactionTypes";
import FormButtons from "../../../../components/form/FormButtons";
import { getTransactionTypeOptions } from "../../../../helpers/OptionsMappingsHelper";
import { useFetchAssetOptions } from "../../../../api/assets/assets";

export const Route = createFileRoute("/_authorizedRoutes/Portfolios/$id/")({
    component: PortfolioPage,
});

function PortfolioPage() {
    const [isModalOpen, setIsModalOpen] = useState(false);

    const { id } = Route.useParams();

    const { data: portfolio } = useFetchPortfolioById(id);
    const { data: assetOptions } = useFetchAssetOptions();

    const { mutateAsync: addTransaction, isPending } =
        useAddTransactionMutation();

    const transactionTypeOptions = getTransactionTypeOptions();

    const onSubmit = useCallback(
        async (command: AddTransactionCommand) => {
            try {
                command.totalPrice = command.quantity * command.unitPrice;
                await addTransaction(command);

                setIsModalOpen(false);
            } catch {
                setIsModalOpen(false);
            }
        },
        [addTransaction]
    );

    if (portfolio === null || portfolio === undefined) {
        return <Spin />;
    }

    return (
        <>
            <div className={styles.container}>
                <PortfolioHeader value={portfolio.value} />
                <PortfolioAssets assets={portfolio.assets} />

                <Button onClick={() => setIsModalOpen(true)}>
                    Add transaction
                </Button>
            </div>

            <Modal
                open={isModalOpen}
                footer={null}
                onCancel={() => setIsModalOpen(false)}
            >
                <Form
                    onFinish={onSubmit}
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 16 }}
                >
                    <Form.Item
                        label="Asset"
                        name="assetId"
                        rules={[{ required: true }]}
                    >
                        <Select
                            showSearch
                            filterOption={(input, option) =>
                                (option?.label ?? "")
                                    .toLowerCase()
                                    .includes(input.toLowerCase())
                            }
                            options={assetOptions}
                            placeholder="Select asset"
                        />
                    </Form.Item>
                    <Form.Item
                        label="Type"
                        name="type"
                        rules={[{ required: true }]}
                    >
                        <Select
                            options={transactionTypeOptions}
                            placeholder="Select transaction type"
                        />
                    </Form.Item>
                    <Form.Item
                        label="Quantity"
                        name="quantity"
                        rules={[{ required: true }]}
                    >
                        <InputNumber />
                    </Form.Item>
                    <Form.Item
                        label="Unit price"
                        name="unitPrice"
                        rules={[{ required: true }]}
                    >
                        <InputNumber />
                    </Form.Item>
                    <Form.Item
                        name="portfolioId"
                        initialValue={id}
                        hidden
                    ></Form.Item>
                    <FormButtons disabled={isPending} />
                </Form>
            </Modal>
        </>
    );
}
