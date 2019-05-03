import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder, ControlValueAccessor } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material';

import { CheckoutService } from '../services/checkout.service';
import { take } from 'rxjs/operators';
import { UserService } from '../../shared/services/user.service';
import { TextAndValueBox } from '../../shared/models';


@Component({
	selector: 'checkout',
	templateUrl: './checkout.component.html',
	styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit, ControlValueAccessor {

	public total = 0;
	hidePassword = true;
	regions: TextAndValueBox[] = [];
	registerUser = false;
	invoice = false;
	delivery = 5;

	initialValue = '';
	form: FormGroup;

	constructor(fb: FormBuilder, private service: CheckoutService, private userService: UserService) {
		this.form = fb.group({ // TODO: Interface
			email: new FormControl('', [Validators.required, Validators.email]),
			name: new FormControl('', [Validators.required]),
			phone: new FormControl('', [Validators.required]),
			password: new FormControl(''),
			address: fb.group({
				region: new FormControl('', [Validators.required]),
				city: new FormControl('', [Validators.required]),
				addressLine: new FormControl('', [Validators.required]),
				zipCode: new FormControl('', [Validators.required]),
				country: new FormControl({ value: 'Bulgaria', disabled: true }, Validators.required),
			}),
			invoice: new FormControl(''),
			invoiceDetails: fb.group({
				companyName: new FormControl(''),
				eik: new FormControl(''),
				dds: new FormControl(''),
				mol: new FormControl(''),
				address: new FormControl(''),
			}),
			description: new FormControl('')
		});
	}

	getErrorMessage() {
		return this.form.controls['email'].hasError('email') ? 'Невалиден ел. адрес' : '';

		/* return this.form.controls['email'].hasError('required') ? 'You must enter a value' :
					   this.form.controls['email'].hasError('email') ? 'Not a valid email' :
						   ''; */
	}

	createAccount(event: MatCheckboxChange) {
		if (event) {
			this.registerUser = event.checked;
		}
	}

	createInvoice(event: MatCheckboxChange) {
		if (event) {
			this.invoice = event.checked;
		}
	}

	ngOnInit() {
		const cartContent = this.service.loadCart();
		if (cartContent && cartContent.total > 0) {
			this.total = cartContent.total;
		}
		// this.form.controls['country'].patchValue('България')
	}

	register() {
		if (this.form.valid && this.form.controls['password'] && this.form.controls['password'].value !== '') {
			this.userService.registerWithDetails(this.form.value)
				.pipe(take(1))
				.subscribe(
					result => {
						console.log(result);
					},
					error => {
						console.log(error);
					}
				);
		}
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
