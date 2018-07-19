import { Component } from "@angular/core";
import { Employee } from "./Employee";

@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.css"]
})
/** Employee component*/
export class EmployeeComponent implements OnInit {
  employees: Employee[];

  constructor(private empService: "") {}

  ngOnInit(): void {}

  getEmployees(): void {}
}
