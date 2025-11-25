import { Form, InputNumber, Select } from "antd";
import type { AddTransactionCommand } from "../../../api/transactions/transactionTypes";
import { useFetchAssetOptions } from "../../../api/assets/assets";
import { getTransactionTypeOptions } from "../../../helpers/OptionsMappingsHelper";
import FormButtons from "../../form/FormButtons/FormButtons";

interface Props {
    id: string;
    isPending: boolean;
    handleSubmit: (command: AddTransactionCommand) => Promise<void>;
}

function TransactionForm({ id, isPending, handleSubmit }: Props) {
    const { data: assetOptions } = useFetchAssetOptions();

    const transactionTypeOptions = getTransactionTypeOptions();

    return (
        <Form
            onFinish={handleSubmit}
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
            <Form.Item label="Type" name="type" rules={[{ required: true }]}>
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
            <Form.Item name="portfolioId" initialValue={id} hidden></Form.Item>
            <FormButtons disabled={isPending} />
        </Form>
    );
}

export default TransactionForm;
