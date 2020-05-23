import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { UserService } from '../shared/services/user.service';
import { ProductService } from '../shared/services/product.service';

@Component({
	selector: 'app-header',
	templateUrl: './header.component.html',
	styleUrls: ['./header.component.scss']
})

export class HeaderComponent implements OnInit, OnDestroy {

	status: boolean;
	subscription: Subscription;
	navClass = 'navbar';

	productsInCart = 0;

	constructor(private userService: UserService, private productService: ProductService) {
	}

	logout() {
		this.userService.logout();
	}

	ngOnInit() {
		this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);

		this.productsInCart = this.productService.getCartProductsCount();
		this.productService.watchStorage().subscribe(count => {
			if (count !== null && count !== undefined) {
				this.productsInCart = count;
			}
		})
	}

	ngOnDestroy() {
		if (this.subscription) {
			this.subscription.unsubscribe();
		}
	}

	burgerMenu(event) {
		// console.log(event.path[1].id);
		// console.log(event);

		if (this.navClass === 'navbar') {
			this.navClass += ' responsive'
		} else {
			this.navClass = 'navbar'
		}
	}
}
