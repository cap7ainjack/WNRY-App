import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { ShopHomeComponent } from './shop-home/shop-home.component';

import { AuthGuard } from '../auth.guard';
import { CartComponent } from './shopping-cart/shopping-card.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
 // tslint:disable:indent
  {
    path: 'shop',
      component: ShopHomeComponent,

      children: [
       { path: '', component: ShopHomeComponent }
      // { path: 'settings',  component: SettingsComponent },
      ]
    },

    { path: 'cart', component: CartComponent },
]);

