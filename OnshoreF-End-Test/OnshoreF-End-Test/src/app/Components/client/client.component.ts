import {Component, OnInit} from '@angular/core';

import {Client} from '../../../Models';
import {ClientService} from '../../../Services/Client-Service/client.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css']
})
/** Client component*/
export class ClientComponent implements OnInit {
  clients: Client[];

  constructor(private clientService: ClientService) {}

  ngOnInit() {
    this.getClients();
  }

  getClients(): void {
    this.clientService.getClients().subscribe();
    console.log('Clients Retrieved');
  }
}
