import { Component, OnInit } from '@angular/core';

import { Observable, of } from 'rxjs';
import { EmployeeType } from '../../../Models';



@Component( {
    selector: 'app-employee-type',
    templateUrl: './employee-type.component.html',
    styleUrls: ['./employee-type.component.css']
  }
)

export class EmployeeTypeComponent impliments OnInit {

    employeeType = EmployeeType[];

    constructor(); {

    }

    // tslint:disable-next-line:no-unused-expression
    ngOnInit(): void {
      this.employeeType = this.getEmployeesTypes(),
      };
    }

    // tslint:disable-next-line:no-unused-expression
    getEmployeesTypes(): Observable<EmployeeType[] > {

    };

  }
