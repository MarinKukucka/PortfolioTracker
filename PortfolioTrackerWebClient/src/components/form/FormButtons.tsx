import { SaveOutlined } from "@ant-design/icons";
import { Button, Row } from "antd";

interface Props {
    disabled: boolean;
}

function FormButtons({ disabled }: Props) {
    return (
        <Row
            style={{
                display: "flex",
                flexDirection: "row",
                justifyContent: "flex-end",
            }}
        >
            <Button type="primary" htmlType="submit" disabled={disabled}>
                <SaveOutlined />
                Create
            </Button>
        </Row>
    );
}

export default FormButtons;
