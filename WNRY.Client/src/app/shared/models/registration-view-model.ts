import { TextAndValueBox } from '.';

export interface RegisterWithAddressViewModel {
		email: string;

		phone: string;

		name: string;

		password: string;

		address: AddressViewModel;
}

export interface AddressViewModel {
		region: TextAndValueBox;

		city: string;

		zipCode: string;

		addressLine: string;
}
