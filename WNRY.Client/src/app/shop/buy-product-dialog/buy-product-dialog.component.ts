import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ProductData } from '../models/product-data';
import { CartItem } from '../models/cart-item';


@Component({
	selector: 'buy-product-dialog',
	templateUrl: './buy-product-dialog.component.html',
	styleUrls: ['./buy-product-dialog.component.scss', '../shop-component.scss']
})
export class BuyProductDialogComponent {
	productQuantity = 1;
	cartItem: CartItem = {
		product: null,
		quantity: 0
	};

	constructor(
		public dialogRef: MatDialogRef<BuyProductDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: ProductData) {
			this.cartItem.product = data;
		}

	onNoClick(): void {
		this.dialogRef.close();
	}

	checkValue() {
		if (this.productQuantity < 1) {
			this.productQuantity = 1;
		}
		this.cartItem.quantity = this.productQuantity;
	}
}
