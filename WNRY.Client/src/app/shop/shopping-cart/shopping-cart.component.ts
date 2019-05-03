import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CartItem } from '../../shared/models';
import { ProductService } from '../../shared/services/product.service';

@Component({
	templateUrl: 'shopping-cart.component.html',
	styleUrls: ['./shopping-cart.component.scss']
})

export class CartComponent implements OnInit {

	items: CartItem[] = [];
	total = 0;

	displayedColumns: string[] = ['picture', 'name', 'quantity', 'price', 'clear'];

	constructor(
		private activatedRoute: ActivatedRoute,
		private productService: ProductService
	) { }

	ngOnInit() {
		this.activatedRoute.params.subscribe(params => {
			let id = params['id'];
			if (id) { // TODO only else case works now
				let item: CartItem = {
					product: null, // this.productService.find(id),
					quantity: 1
				};
				if (localStorage.getItem('cart') == null) {
					let cart: any = [];
					cart.push(JSON.stringify(item));
					localStorage.setItem('cart', JSON.stringify(cart));
				} else {
					let cart: any = JSON.parse(localStorage.getItem('cart'));
					let index = -1;
					for (let i = 0; i < cart.length; i++) {
						let parsedItem: any = JSON.parse(cart[i]);
						if (parsedItem.product.id === id) {
							index = i;
							break;
						}
					}
					if (index === -1) {
						cart.push(JSON.stringify(item));
						localStorage.setItem('cart', JSON.stringify(cart));
					} else {
						let itemToStore: any = JSON.parse(cart[index]);
						itemToStore.quantity += 1;
						cart[index] = JSON.stringify(itemToStore);
						localStorage.setItem('cart', JSON.stringify(cart));
					}
				}
				this.loadCart();
			} else {
				this.loadCart();
			}
		});
	}

	loadCart(): void {
		this.total = 0;
		this.items = [];
		let cart = JSON.parse(localStorage.getItem('cart'));

		if (cart) {
			for (let i = 0; i < cart.length; i++) {
				let item = JSON.parse(cart[i]);
				this.items.push({
					product: item.product,
					quantity: item.quantity
				});
				this.total += item.product.price * item.quantity;
			}
		}
	}

	removeItem(id: string): void {
		this.productService.removeItem(id);
		this.loadCart();
	}

	addProduct(id: string) {
		let cart: any = JSON.parse(localStorage.getItem('cart'))
		for (let i = 0; i < cart.length; i++) {
			let item: CartItem = JSON.parse(cart[i]);
			if (item.product.id === id) {
				item.quantity += 1;
				cart[i] = JSON.stringify(item);
				break;
			}
		}
		localStorage.setItem('cart', JSON.stringify(cart));
		this.loadCart();
	}

	substractProduct(id: string) {
		let cart: any = JSON.parse(localStorage.getItem('cart'))
		for (let i = 0; i < cart.length; i++) {
			let item: CartItem = JSON.parse(cart[i]);
			if (item.product.id === id) {
				if (item.quantity > 1) {
					item.quantity -= 1;
					cart[i] = JSON.stringify(item);
				}
				break;
			}
		}
		localStorage.setItem('cart', JSON.stringify(cart));
		this.loadCart();
	}
}
