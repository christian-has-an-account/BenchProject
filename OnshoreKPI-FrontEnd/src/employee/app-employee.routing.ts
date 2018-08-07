//* Modules
import { RouterModule, Routes } from '@angular/router';

//* Components
import { EmployeeComponent } from '.././employee/employee/employee.component'

//! Route Declarations
const routes: Routes = [
  { path: 'Employee', component: EmployeeComponent, },
  { path: 'Clients', loadChildren: 'lazypath#ChildModule' },
  { path: '**', pathMatch: 'full', redirectTo: 'Employee' }
];

export const appRouting = RouterModule.forChild(routes, );