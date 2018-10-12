import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { BuyProductDialogComponent } from '../buy-product-dialog/buy-product-dialog.component';
import { ProductData } from '../models/product-data';
import {
	BreakpointObserver,
	Breakpoints,
	BreakpointState
} from '@angular/cdk/layout';

@Component({
	selector: 'product-grid',
	templateUrl: './product-grid.component.html',
	styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent implements OnInit {
	@Input('products') products: any;

	columnsToShow = 1;

	matcher: MediaQueryList;

	constructor(public dialog: MatDialog, public breakpointObserver: BreakpointObserver) { }

	ngOnInit() {
		this.breakpointObserver
			.observe([Breakpoints.Medium, Breakpoints.Small, Breakpoints.XSmall, Breakpoints.Large, Breakpoints.XLarge])
			.subscribe((state: BreakpointState) => {
				console.log(state.breakpoints)
				if (state.matches) {
					if (state.breakpoints[Breakpoints.Large] || state.breakpoints[Breakpoints.XLarge]) {
						this.columnsToShow = 3;
					}
					if (state.breakpoints[Breakpoints.Medium]) {
						this.columnsToShow = 3;
					}
					if (state.breakpoints[Breakpoints.Small]) {
						this.columnsToShow = 2;
					}
					if (state.breakpoints[Breakpoints.XSmall]) {
						this.columnsToShow = 1;
					}
				}
			});
	}

	buyProduct(item: ProductData) {
		const dialogRef = this.dialog.open(BuyProductDialogComponent, {
			maxHeight: '700px',
			maxWidth: '800px',
			data: { name: item.name, id: item.id, img: item.img, price: item.price }
		});

		dialogRef.afterClosed().subscribe(result => {
			console.log('The dialog was closed');
			console.log(result);
		});
	}
}
