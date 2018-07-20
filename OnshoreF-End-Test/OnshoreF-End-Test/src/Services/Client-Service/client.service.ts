import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoggerService } from '../logger.service';


import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Client } from '../../Models/client';

// Variables
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

// Injectable
@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private clientURL = 'api/Client'; // url for in-Dev API

  constructor(
    private http: HttpClient
  )

}

