import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder, ControlValueAccessor } from '@angular/forms';
import { MatCheckboxChange } from '@angular/material';
import { take } from 'rxjs/operators';
import { Router } from '@angular/router';

import { CheckoutService } from '../services/checkout.service';
import { FormsHelperService } from '../../shared/services/forms.helper.service';
import { UserService } from '../../shared/services/user.service';
import { Order, TextAndValueBox } from '../../shared/models';
import { ProductService } from '../../shared/services/product.service';

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
	shippingPrice = 0;

	initialValue = '';
	form: FormGroup;
	showInvalidFormMessage = false;

	constructor(
		fb: FormBuilder,
		private service: CheckoutService,
		private userService: UserService,
		private productsService: ProductService,
		private router: Router,
		private formHelper: FormsHelperService) {
		this.form = fb.group({ // TODO: Interface
			email: new FormControl('', [Validators.required, Validators.email]),
			name: new FormControl('', [Validators.required]),
			phone: new FormControl('', [Validators.required]),
			password: new FormControl('', [Validators.minLength(6)]),
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
				bulstat: new FormControl(''),
				vat: new FormControl(''),
				mol: new FormControl(''),
				address: new FormControl(''),
			}),
			description: new FormControl('')
		});
	}

	getErrorMessage(formControlName: string) {
		return this.formHelper.getErrorMessage(formControlName);

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
			console.log(cartContent.items);
			let totalItems = this.productsService.calcCartTotalItems();
			this.shippingPrice = this.service.calculateShipping(cartContent.weight, totalItems);
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

	proceedOrder() {
		if (this.form.valid) {
			this.showInvalidFormMessage = false;
			console.log('VALID');
			let order: Order = this.form.value;
			order.shipping = this.shippingPrice;
			this.service.placeOrder(order)
				.pipe(take(1))
				.subscribe(
					result => {
						console.log(result);
						this.router.navigateByUrl('/complete');
					},
					error => {
						console.log(error);
					});
		} else {
			this.scrollToTop();
			this.showInvalidFormMessage = true;
			this.formHelper.markFormGroupTouched(this.form);
			console.log('INvalid')
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

	/**
	 * Calls window function which will scroll to the top of the page
	 */
	private scrollToTop() {
		(function smoothscroll() {
			const currentScroll = document.documentElement.scrollTop || document.body.scrollTop;
			if (currentScroll > 0) {
				window.requestAnimationFrame(smoothscroll);
				window.scrollTo(0, currentScroll - (currentScroll / 8));
			}
		})();
	}
}
