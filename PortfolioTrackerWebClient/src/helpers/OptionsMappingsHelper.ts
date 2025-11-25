import type { OptionDTO } from "../config/commonTypes";
import { TransactionType } from "../config/enums";

export interface SelectOption {
    label: string;
    value: number | string;
}

export const formatSelectOptions = (options: OptionDTO[]): SelectOption[] => {
    return options.map(option => ({
        label: option.name,
        value: option.id,
    }))
}

export const getTransactionTypeOptions = () => {
    return Object.entries(TransactionType)
        .filter(([, value]) => typeof value === "number")
        .map(([key, value]) => ({
            key: key,
            label: key,
            value: value,
        }));
}
        