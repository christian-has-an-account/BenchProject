import {Component, OnInit} from '@angular/core';

import {Team} from '../../../Models/index';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
/** Team component*/
export class TeamComponent {
  teams = Team[];
  constructor() {}
}
