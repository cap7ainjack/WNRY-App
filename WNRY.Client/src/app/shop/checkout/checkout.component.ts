import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { CheckoutService } from '../services/checkout.service';

@Component({
	selector: 'checkout',
	templateUrl: './checkout.component.html',
	styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit, OnChanges {
	public total = 0;




	initialValue = '';
	form: FormGroup;
	// formControl = 'contact-details';

	constructor(fb: FormBuilder, private service: CheckoutService) {
		this.form = fb.group({
			email: new FormControl('', [Validators.required, Validators.email]),
			name: new FormControl('', [Validators.required]),
			phone: new FormControl('', [Validators.required]),
		});
	}

	ngOnChanges(changes: SimpleChanges) {
		if (changes) {
			if (changes['inital']) {
				// this.initialValue = this.initial;
			}
		}
	}


	getErrorMessage() {
		return this.form.controls['email'].hasError('email') ? 'Невалиден ел. адрес' : '';

		/* return this.form.controls['email'].hasError('required') ? 'You must enter a value' :
						this.form.controls['email'].hasError('email') ? 'Not a valid email' :
							''; */
	}

	ngOnInit() {
		const cartContent = this.service.loadCart();
		if (cartContent && cartContent.total > 0) {
			this.total = cartContent.total;
		}
	}
}
