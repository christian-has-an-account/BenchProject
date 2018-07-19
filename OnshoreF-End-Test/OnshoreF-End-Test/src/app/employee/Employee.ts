import { Role } from '../roles/Role';
import { EmployeeType } from '../employee-type/EmployeeType';
import { Client } from '../client/client';
import { Team } from '../team/Team';


export class Employee {
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

//export interface Client {
//  clientID: number;
//  clientName: string;
//}

//export interface EmployeeType {
//  typeID: number;
//  typeName: string;
//}

//export interface Role {
//  roleID: number;
//  roleName: string;
//}

//export interface Team {
//  teamID: number;
//  teamName: string;
//  client: Client;
//}
