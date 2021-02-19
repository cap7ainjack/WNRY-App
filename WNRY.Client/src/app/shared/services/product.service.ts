import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable } from 'rxjs';

import { ConfigService } from '../../shared/utils/config.service';
import { BaseService } from '../../shared/services/base.service';

import { CartItem } from '../../shared/models';

@Injectable()

export class ProductService extends BaseService {

    // tslint:disable: indent
    baseUrl = '';
    private storageCountSubj = new Subject<number>();

    constructor(private http: HttpClient, private configService: ConfigService) {
        super();
        this.baseUrl = configService.getApiURI();
    }

    watchStorage(): Observable<any> {
        return this.storageCountSubj.asObservable();
    }

    removeItem(id: string): void {
        let cart: any[] = JSON.parse(localStorage.getItem('cart'))

        for (let i = 0; i < cart.length; i++) {
            let item: CartItem = JSON.parse(cart[i]);
            if (item.product.id === id) {
                cart.splice(i, 1);
                break;
            }
        }
        localStorage.setItem('cart', JSON.stringify(cart));
        this.storageCountSubj.next(this.calcCartTotalItems());
    }

    addSameProduct(id: string) {
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

        let totalItemsCount = this.calcCartTotalItems();
        this.storageCountSubj.next(totalItemsCount);
    }

    substractSameProduct(id: string) {
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

        let totalItemsCount = this.calcCartTotalItems();
        this.storageCountSubj.next(totalItemsCount);
    }

    addNewItemToCart(itemToAdd: CartItem) {
        let cart = [];
        if (itemToAdd) {
            if (localStorage.getItem('cart') == null) {
                cart.push(JSON.stringify(itemToAdd));
                localStorage.setItem('cart', JSON.stringify(cart));
            } else {
                cart = JSON.parse(localStorage.getItem('cart'));
                let index = -1;
                for (let i = 0; i < cart.length; i++) {
                    let parsedItem: any = JSON.parse(cart[i]);
                    if (parsedItem.product.id === itemToAdd.product.id) {
                        index = i;
                        break;
                    }
                }
                if (index === -1) {
                    cart.push(JSON.stringify(itemToAdd));
                    localStorage.setItem('cart', JSON.stringify(cart));
                } else {
                    let itemToStore: any = JSON.parse(cart[index]);
                    itemToStore.quantity += itemToAdd.quantity;
                    cart[index] = JSON.stringify(itemToStore);
                    localStorage.setItem('cart', JSON.stringify(cart));
                }
            }
        }

        let totalItemsCount = this.calcCartTotalItems();
        this.storageCountSubj.next(totalItemsCount);
    }

    loadProducts() {
        return this.http.get(this.baseUrl + '/Products');
    }

    calcCartTotalItems() {
        let cartt = JSON.parse(localStorage.getItem('cart'));
        let totalItemsCount = 0;
        for (let i = 0; i < cartt.length; i++) {
            let parsedItem: any = JSON.parse(cartt[i]);
            totalItemsCount += parsedItem.quantity;
        }

        return totalItemsCount;
    }
}
