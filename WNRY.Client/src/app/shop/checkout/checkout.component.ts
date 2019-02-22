import { Component, OnInit, SimpleChanges, OnChanges } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder, ControlValueAccessor } from '@angular/forms';
import { CheckoutService } from '../services/checkout.service';
import { take } from 'rxjs/operators';

@Component({
	selector: 'checkout',
	templateUrl: './checkout.component.html',
	styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit, OnChanges, ControlValueAccessor {

	public total = 0;
	hidePassword = true;
	regions: [] = []; // add interface

	initialValue = '';
	form: FormGroup;
	// formControl = 'contact-details';

	constructor(fb: FormBuilder, private service: CheckoutService) {
		this.form = fb.group({
			email: new FormControl('', [Validators.required, Validators.email]),
			name: new FormControl('', [Validators.required]),
			phone: new FormControl('', [Validators.required]),
			password: new FormControl(''),
			region: new FormControl(null, [Validators.required]),
			city: new FormControl('', [Validators.required]),
			addressLine: new FormControl('', [Validators.required]),
			zipCode: new FormControl('', [Validators.required]),
			country: new FormControl('', [Validators.required]),
			registerUser: new FormControl(false),
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

		 return this.form.controls['email'].hasError('required') ? 'You must enter a value' :
						this.form.controls['email'].hasError('email') ? 'Not a valid email' :
							'';
	}

	ngOnInit() {
		const cartContent = this.service.loadCart();
		if (cartContent && cartContent.total > 0) {
			this.total = cartContent.total;
		}

		this.form.controls['country'].patchValue('България')
	}

	onSelectorOpen() {
		if (this.regions.length === 0) {
			this.service.getRegions()
			.pipe(take(1))
			.subscribe(
				result => {
					console.log(result);
					this.regions = result;
				},
				error => {
					console.log(error);
				}
			);
		}
	}

	writeValue(value: any): void {
		if (value) {
			this.form.patchValue(value);
		}
	}
	registerOnChange(fn: any): void {
		this.form.valueChanges.subscribe(values => {
			fn(values);
		});
	}
	registerOnTouched(fn: any): void {
		throw new Error('Method not implemented.');
	}
}
