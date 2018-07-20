import {Employee, EmployeeType, Client, Team} from '.';

export class Report {
  reportingID: number;
  employeeID: number;
  clientID: number;
  teamID: number;
  startTime: string;
  completionTime: string;
  name: string;
  name2: string;
  date: string;
  quantity: number;
  textScriptExecutionOrders: number;
  textScriptCreationErrors: number;
  cardPoints: number;
  timeSpent: number;
  hoursComplete: number;
  hoursEstimated: number;
  email: string;
  task: string;
  client: Client;
  employee: Employee;
  team: Team;
}

export interface Client {
  clientID: number;
  clientName: string;
}

export interface Employee {
  employeeID: number;
  clientID2: number;
  clientID3: number;
  clientID4: number;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  client: Client;
  role: Role;
  team: Team;
  employeeType: EmployeeType;
  client2: Client;
  client3: Client;
  client4: Client;
}

export interface EmployeeType {
  typeID: number;
  typeName: string;
}

export interface Role {
  roleID: number;
  roleName: string;
}

export interface Team {
  teamID: number;
  teamName: string;
  client: Client;
}
