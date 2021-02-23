import { Injectable } from '@angular/core';
import { CustomBreakpointNames } from '../models/custom-breakpoint-names';

@Injectable({
    providedIn: 'root'
})

export class BreakpointsService {
    breakpoints: object = {
       // '(max-width: 220px)': CustomBreakpointNames.extraSmall,
        '(max-width: 880px)': CustomBreakpointNames.small,
        '(max-width: 1250px)': CustomBreakpointNames.medium,
        '(max-width: 1640px)': CustomBreakpointNames.large,
        '(min-width: 1641px)': CustomBreakpointNames.extraLarge
    };

    getBreakpoints(): string[] {
        return Object.keys(this.breakpoints);
    }

    getBreakpointName(breakpointValue): string {
        return this.breakpoints[breakpointValue];
    }

    constructor() {
    }
}