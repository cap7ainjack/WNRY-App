import { Component, OnInit  } from '@angular/core';


@Component({
	selector: 'shop-home',
	templateUrl: './shop-home.component.html',
	styleUrls: ['./shop-home.component.scss']
})
export class ShopHomeComponent implements OnInit  {

	productsToDisplay = [
		{ id: '123', name: 'Merlot', price: 11, img: 'https://i.ibb.co/ckmdNgN/5.jpg' },
		{ id: '234', name: 'Cabernet Sauvignon', price: 11, img: 'https://i.ibb.co/1bdMmvp/cabernet-resized.jpg"' },
		{ id: '345', name: 'Rose', price: 9, img: 'https://i.ibb.co/gghGqWM/rose-resized.jpg' },
		{ id: '456', name: 'Chardonnay', price: 9, img: 'https://i.ibb.co/sbgkKjH/Chardonnay-resized.jpg' }
	]

	ngOnInit() {

	}
}
