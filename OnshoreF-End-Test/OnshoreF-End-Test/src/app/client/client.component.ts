import { Component, OnInit } from '@angular/core';

import { Client } from './client';
import { ClientService } from '../../Services/Client-Service/client.service';
import { ClientResponse } from 'http';

@Component({
    selector: 'app-client',
    templateUrl: './client.component.html',
    styleUrls: ['./client.component.css']
})
/** Client component*/
export class ClientComponent implements OnInit {
    clients: Client[];

    constructor( private clientService: ClientService ) {  }

    ngOnInit(){
        this.getClients();
    }

    getClients(): void {
        this.clientService.getClients()
        .subscribe(clients => this.clients = clients)
    }



    /*add(name: string):void{
        name = name.trim();
        if(!name){
            return;
        }

    }*/
}
