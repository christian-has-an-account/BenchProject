import {Component, OnInit} from '@angular/core';

import {Role} from '../../../Models';

@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
/** Roles component*/
export class RolesComponent {
  roles = Role[];

  constructor() {}
}
