import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/modules/shared.module';

import { routing } from './shop.routing';
/*
import { RootComponent } from './root/root.component';
import { HomeComponent } from './home/home.component';
import { DashboardService } from './services/dashboard.service';
 */

import { ShopHomeComponent } from './shop-home/shop-home.component';
import { ProductGridComponent } from './product-grid/product-grid.component';
import { BuyProductDialogComponent } from './buy-product-dialog/buy-product-dialog.component';

import { MatGridListModule } from '@angular/material/grid-list';
import { MatButtonModule } from '@angular/material/button'
import { MatDialogModule } from '@angular/material/dialog'
import { MatInputModule } from '@angular/material/input'
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table'
import { MatFormFieldModule } from '@angular/material/form-field'
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox'

import { AuthGuard } from '../auth.guard';

import { MatCardModule } from '@angular/material/card';

import { LayoutModule } from '@angular/cdk/layout';
import { CartComponent } from './shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutService } from './services/checkout.service';
import { ProductService } from '../shared/services/product.service';

import { LayoutService } from '../shared/services/layout.service';

import { FormsHelperService } from '../shared/services/forms.helper.service';
import { CompletedOrderComponent } from './completed-order/completed-order.component';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		routing,
		MatCardModule,
		MatGridListModule,
		MatButtonModule,
		MatDialogModule,
		MatInputModule,
		MatIconModule,
		MatTableModule,
		MatFormFieldModule,
		MatSelectModule,
		MatCheckboxModule,
		LayoutModule,
		SharedModule
	],
	declarations: [
		ShopHomeComponent,
		ProductGridComponent,
		BuyProductDialogComponent,
		CartComponent,
		CheckoutComponent,
		CompletedOrderComponent
		/* RootComponent, HomeComponent, SettingsComponent */
	],
	exports: [],
	providers: [CheckoutService, ProductService, FormsHelperService, LayoutService],
	entryComponents: [BuyProductDialogComponent]
})
export class ShopModule { }
