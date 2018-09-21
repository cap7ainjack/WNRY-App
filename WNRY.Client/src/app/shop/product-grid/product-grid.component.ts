import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { BuyProductDialogComponent } from '../buy-product-dialog/buy-product-dialog.component';
import { ProductData } from '../models/product-data';

@Component({
	selector: 'product-grid',
	templateUrl: './product-grid.component.html',
	styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent implements OnInit {
	@Input('products') products: any;

	constructor(public dialog: MatDialog) {}

	ngOnInit() {
	}

	buyProduct(item: ProductData) {
		const dialogRef = this.dialog.open(BuyProductDialogComponent, {
			maxHeight: '700px',
			maxWidth: '800px',
			data: {name: item.name, id: item.id, img: item.img, price: item.price }
		});

		dialogRef.afterClosed().subscribe(result => {
			console.log('The dialog was closed');
			console.log(result);
		});
	}
}
