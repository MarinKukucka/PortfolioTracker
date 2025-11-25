import { createFileRoute } from "@tanstack/react-router";
import { useFetchPortfolioById } from "../../../../api/portfolios/portfolios";
import styles from "./index.module.css";
import PortfolioHeader from "../../../../components/portfolio/PortfolioHeader/PortfolioHeader";
import { Button, Modal, Spin } from "antd";
import PortfolioAssets from "../../../../components/portfolio/PortfolioAssets/PortfolioAssets";
import { useCallback, useState } from "react";
import type { AddTransactionCommand } from "../../../../api/transactions/transactionTypes";
import { useAddTransactionMutation } from "../../../../api/transactions/transactions";
import TransactionForm from "../../../../components/transaction/TransactionForm/TransactionForm";

export const Route = createFileRoute("/_authorizedRoutes/Portfolios/$id/")({
    component: PortfolioPage,
});

function PortfolioPage() {
    const [isModalOpen, setIsModalOpen] = useState(false);

    const { id } = Route.useParams();

    const { data: portfolio } = useFetchPortfolioById(id);

    const { mutateAsync: addTransaction, isPending } =
        useAddTransactionMutation();

    const handleSubmit = useCallback(
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
                <TransactionForm
                    id={id}
                    isPending={isPending}
                    handleSubmit={handleSubmit}
                />
            </Modal>
        </>
    );
}
