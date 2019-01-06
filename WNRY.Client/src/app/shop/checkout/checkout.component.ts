import { Component, OnInit  } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { CheckoutService } from '../services/checkout.service';

@Component({
	selector: 'checkout',
	templateUrl: './checkout.component.html',
	styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
	public total = 0;

	email = new FormControl('', [Validators.required, Validators.email]);

	constructor(private service: CheckoutService) { }

	getErrorMessage() {
		return this.email.hasError('required') ? 'You must enter a value' :
			this.email.hasError('email') ? 'Not a valid email' :
				'';
	}

	ngOnInit() {
		const cartContent = this.service.loadCart();
		if (cartContent && cartContent.total > 0) {
			this.total = cartContent.total;
		}
	}
}
