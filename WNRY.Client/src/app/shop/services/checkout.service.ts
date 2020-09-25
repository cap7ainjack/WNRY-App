import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ConfigService } from '../../shared/utils/config.service';
import { BaseService } from '../../shared/services/base.service';
import { CartContent, Order } from '../../shared/models';


@Injectable()

export class CheckoutService extends BaseService {

	baseUrl = '';

	constructor(private http: HttpClient, private configService: ConfigService) {
		super();
		this.baseUrl = configService.getApiURI();
	}

	public getRegions(): Observable<any> { // export to shared service
		return this.http.get(this.baseUrl + '/Regions');
	}

	public placeOrder(value: Order): Observable<any> {
		if (value !== undefined && value !== null) {
			let orderWithProducts = this.addProductsToTheOrder(value);
			return this.http.post(this.baseUrl + '/Order', orderWithProducts);
		}
	}

	private addProductsToTheOrder(order: Order): Order {
		let cart = JSON.parse(localStorage.getItem('cart'));
		if (cart) {
			order.products = [];
			for (let i = 0; i < cart.length; i++) {
				let item = JSON.parse(cart[i]);
				order.products.push({
					id: item.product.id,
					quantity: item.quantity
				});
				//	this.total += item.product.price * item.quantity;
			}
		}

		return order;
	}

	loadCart(): CartContent {
		const cartContent: CartContent = { items: [], total: 0 };
		cartContent.total = 0;
		cartContent.items = [];

		let cart = JSON.parse(localStorage.getItem('cart'));

		if (cart) {
			for (let i = 0; i < cart.length; i++) {
				let item = JSON.parse(cart[i]);
				cartContent.items.push({
					product: item.product,
					quantity: item.quantity
				});
				cartContent.total += item.product.price * item.quantity;
			}
		}

		return cartContent;
	}
}
