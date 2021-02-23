import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import {
	BreakpointObserver,
	Breakpoints,
	BreakpointState
} from '@angular/cdk/layout';

import { BuyProductDialogComponent } from '../buy-product-dialog/buy-product-dialog.component';
import { ProductService } from '../../shared/services/product.service';
import { LayoutService } from '../../shared/services/layout.service';
import { ProductData, CartItem } from '../../shared/models';
import { CustomBreakpointNames } from '../../shared/models/custom-breakpoint-names';


@Component({
	selector: 'product-grid',
	templateUrl: './product-grid.component.html',
	styleUrls: ['../shop-component.scss']
})
export class ProductGridComponent implements OnInit {
	@Input('products') products: ProductData[];

	columnsToShow = 0;

	matcher: MediaQueryList;

	constructor(public dialog: MatDialog, public breakpointObserver: BreakpointObserver, private productService: ProductService, private layoutService: LayoutService) {
		/* 		this.breakpointObserver
					.observe([Breakpoints.Medium, Breakpoints.Small, Breakpoints.XSmall, Breakpoints.Large, Breakpoints.XLarge])
					.subscribe((state: BreakpointState) => {
						if (state.matches) {
							if (state.breakpoints[Breakpoints.] || state.breakpoints[Breakpoints.XLarge]) {
								this.columnsToShow = 4;
							}
							else if (state.breakpoints[Breakpoints.Medium]) {
								this.columnsToShow = 3;
							} else if (state.breakpoints[Breakpoints.Small]) {
								this.columnsToShow = 2;
							} else if (state.breakpoints[Breakpoints.XSmall]) {
								this.columnsToShow = 1;
							}
						}
					}); */

					this.layoutService.subscribeToLayoutChanges().subscribe(observerResponse => {
						// You will have all matched breakpoints in observerResponse
						if (this.layoutService.isBreakpointActive(CustomBreakpointNames.extraLarge)) {
							this.columnsToShow = 4;
						}
						if (this.layoutService.isBreakpointActive(CustomBreakpointNames.large)) {
							this.columnsToShow = 3;
						}
						if (this.layoutService.isBreakpointActive(CustomBreakpointNames.medium)) {
							this.columnsToShow = 2;
						}
						if (this.layoutService.isBreakpointActive(CustomBreakpointNames.small)) {
							this.columnsToShow = 1;
						}
					});
	}

	ngOnInit() {

	}

	addToCart(item: ProductData) {
		const dialogRef = this.dialog.open(BuyProductDialogComponent, {
			maxHeight: '700px',
			maxWidth: '800px',
			data: { name: item.displayName, id: item.id, photoUrl: item.photoUrl, price: item.price }
		});

		dialogRef.afterClosed().subscribe((itemToAdd: CartItem) => { // TODO: Clear local storage cart item at some point
			if (itemToAdd) {
				this.productService.addNewItemToCart(itemToAdd);
			}
		});
	}
}
