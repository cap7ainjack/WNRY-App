import { CartItem } from './cart-item';

export interface CartContent {
	items: CartItem[],
	total: number
}
