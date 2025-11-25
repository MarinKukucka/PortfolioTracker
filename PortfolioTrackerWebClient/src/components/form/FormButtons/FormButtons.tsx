import { SaveOutlined } from "@ant-design/icons";
import { Button, Row } from "antd";
import styles from "./FormButtons.module.css";

interface Props {
    disabled: boolean;
}

function FormButtons({ disabled }: Props) {
    return (
        <Row className={styles.container}>
            <Button type="primary" htmlType="submit" disabled={disabled}>
                <SaveOutlined />
                Create
            </Button>
        </Row>
    );
}

export default FormButtons;
