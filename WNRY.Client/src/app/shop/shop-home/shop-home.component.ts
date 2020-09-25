import { Component, OnInit } from '@angular/core';
import { ProductData } from '../../shared/models/product-data';
import { take } from 'rxjs/operators';
import { ProductService } from '../../shared/services/product.service';


@Component({
	selector: 'shop-home',
	templateUrl: './shop-home.component.html',
	styleUrls: ['./shop-home.component.scss']
})
export class ShopHomeComponent implements OnInit {

	constructor(private productService: ProductService) { }

	/* 	productsToDisplay = [
			{ id: '123', name: 'Merlot', price: 11, img: 'https://i.ibb.co/ckmdNgN/5.jpg' },
			{ id: '234', name: 'Cabernet Sauvignon', price: 11, img: 'https://i.ibb.co/1bdMmvp/cabernet-resized.jpg"' },
			{ id: '345', name: 'Rose', price: 9, img: 'https://i.ibb.co/gghGqWM/rose-resized.jpg' },
			{ id: '456', name: 'Chardonnay', price: 9, img: 'https://i.ibb.co/sbgkKjH/Chardonnay-resized.jpg' }
		] */

	productsToDisplay: ProductData[] = [];

	ngOnInit() {
		this.productService.loadProducts()
			.pipe(take(1))
			.subscribe(
				(result: ProductData[]) => {
					if (result) {
						this.productsToDisplay = result;
					}
					console.log(result);

				},
				error => {
					console.log(error);
				});
	}
}
