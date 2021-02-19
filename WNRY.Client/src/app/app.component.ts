import { Component, HostListener } from '@angular/core';
import { CartContent } from './shared/models/cart-content';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})
export class AppComponent {

	title = 'app';
	@HostListener("window:beforeunload", ["$event"])
	clearLocalStorage(event) {
		const cartContent = [];
		localStorage.setItem('cart', JSON.stringify(cartContent));
	}

}
