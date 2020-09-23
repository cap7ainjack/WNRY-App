import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable()

export class FormsHelperService {


    constructor() { }

    getErrorMessage(formControlName: string): string {
        console.log(formControlName);
        switch (formControlName) {
            case 'email':
                return 'Невалиден ел. адрес';
            case 'name':
                return 'Невалидно име';
            case 'password':
                return 'Mминимум 6 символа';
            default:
                return '';
        }
    }

    /**
  * Marks all controls in a form group as touched recursively (if any nested FormGroups)
  * @param formGroup - The form group to touch
  */
	markFormGroupTouched(formGroup: FormGroup) {
		if (formGroup && formGroup.controls) {
			(<any>Object).values(formGroup.controls).forEach(control => {
				control.markAsTouched();

				if (control.controls) {
					this.markFormGroupTouched(control);
				}
			});
		}
	}
}
