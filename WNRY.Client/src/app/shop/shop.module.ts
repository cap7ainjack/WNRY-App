import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule }        from '@angular/forms';
import { SharedModule }       from '../shared/modules/shared.module';

import { routing }  from './shop.routing';
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
import {MatFormFieldModule} from '@angular/material/form-field'
import {MatSelectModule} from '@angular/material/select';

import { AuthGuard } from '../auth.guard';

import {MatCardModule} from '@angular/material/card';

import { LayoutModule } from '@angular/cdk/layout';
import { CartComponent } from './shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { CheckoutService } from './services/checkout.service';

@NgModule({
	imports: [
		CommonModule,
		FormsModule,
		ReactiveFormsModule,
		routing,
				SharedModule,
				MatCardModule,
				MatGridListModule,
				MatButtonModule,
				MatDialogModule,
				MatInputModule,
				MatIconModule,
				MatTableModule,
				MatFormFieldModule,
				MatSelectModule,
				LayoutModule
	],
	declarations: [
		ShopHomeComponent,
		ProductGridComponent,
		BuyProductDialogComponent,
		CartComponent,
		CheckoutComponent
		/* RootComponent, HomeComponent, SettingsComponent */
	],
	exports:      [ ],
	providers:    [ CheckoutService ],
	entryComponents: [BuyProductDialogComponent]
})
export class ShopModule { }
