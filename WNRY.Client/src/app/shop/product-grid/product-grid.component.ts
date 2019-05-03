import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
	BreakpointObserver,
	Breakpoints,
	BreakpointState
} from '@angular/cdk/layout';

import { BuyProductDialogComponent } from '../buy-product-dialog/buy-product-dialog.component';
import { ProductService } from '../../shared/services/product.service';
import { ProductData, CartItem } from '../../shared/models';


@Component({
	selector: 'product-grid',
	templateUrl: './product-grid.component.html',
	styleUrls: ['../shop-component.scss']
})
export class ProductGridComponent implements OnInit {
	@Input('products') products: any;

	columnsToShow = 0;

	matcher: MediaQueryList;

	constructor(public dialog: MatDialog, public breakpointObserver: BreakpointObserver, private productService: ProductService) {
		this.breakpointObserver
			.observe([Breakpoints.Medium, Breakpoints.Small, Breakpoints.XSmall, Breakpoints.Large, Breakpoints.XLarge])
			.subscribe((state: BreakpointState) => {
				if (state.matches) {
					if (state.breakpoints[Breakpoints.Large] || state.breakpoints[Breakpoints.XLarge] || state.breakpoints[Breakpoints.Medium]) {
						this.columnsToShow = 3;
					} else if (state.breakpoints[Breakpoints.Small]) {
						this.columnsToShow = 2;
					} else if (state.breakpoints[Breakpoints.XSmall]) {
						this.columnsToShow = 1;
					}
				}
			});
	}

	ngOnInit() {

	}

	addToCart(item: ProductData) {
		const dialogRef = this.dialog.open(BuyProductDialogComponent, {
			maxHeight: '700px',
			maxWidth: '800px',
			data: { name: item.name, id: item.id, img: item.img, price: item.price }
		});

		dialogRef.afterClosed().subscribe((itemToAdd: CartItem) => { // TODO: Clear local storage cart item at some point
			if (itemToAdd) {
				this.productService.addItemToCart(itemToAdd);
			}
		});
	}
}
