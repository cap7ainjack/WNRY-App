import { TextAndValueBox } from '../text-and-value-box';

export interface Order {
    email: string;

    name: string;

    phone: string;

    password: string;

    address: Address;

    invoice: boolean;

    description: string;

    products: OrderProduct[];
};

export interface OrderProduct{
    id: string;

    quantity: number;
}

export interface Address {
    addressLine: string;

    city: string;

    region: TextAndValueBox;

    zipCode: string;

    country: string;
};
