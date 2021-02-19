import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ContactsComponent } from './contacts/contacts.component';

import { HomeComponent }  from './home/home.component';

const appRoutes: Routes = [
	{ path: '', component: HomeComponent },
	{ path: 'contacts', component: ContactsComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
