interface Props {
    value: number;
}

function PortfolioHeader({ value }: Props) {
    return <>{value} $</>;
}

export default PortfolioHeader;
