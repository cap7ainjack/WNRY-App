import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';

import { ConfigService } from '../../shared/utils/config.service';

import { BaseService } from '../../shared/services/base.service';

import { Observable } from 'rxjs';
import { CartItem } from '../models/cart-item';
import { CartContent } from '../models/cart-content';


@Injectable()

export class CheckoutService extends BaseService {

		baseUrl = '';

		constructor(private http: HttpClient, private configService: ConfigService) {
				super();
				this.baseUrl = configService.getApiURI();
		}

		public getRegions(): Observable<any> {
		return this.http.get('');
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
