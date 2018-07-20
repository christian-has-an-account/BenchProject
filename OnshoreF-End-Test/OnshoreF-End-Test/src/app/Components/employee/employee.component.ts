import {Component, OnInit} from '@angular/core';
import {Employee} from '../../../Models';
import {EmployeeService} from '../../../Services/Employee-Service/Employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
/** Employee component*/
export class EmployeeComponent implements OnInit {
  employees: Employee[];

  constructor(private empService: EmployeeService) {}

  ngOnInit(): void {
    this.getEmployees();
  }

  getEmployees(): void {}
}
