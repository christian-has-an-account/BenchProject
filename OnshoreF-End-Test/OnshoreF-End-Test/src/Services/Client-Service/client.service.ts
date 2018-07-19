import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../messaging.service'

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Client } from '../../app/client/client';


// Variables
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
public let i = 0;


@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private clientURL = 'localhost.com:53023/api' // url for in-Dev API

  constructor(
    private http: HttpClient,
    private messageService: MessageService
    ) {

  }

  getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(this.clientURL + '/Employees')
      .pipe(
        tap(clients => this.log('Fetched Clients'),
        catchError(this.handleError('getClients', []))
      );
  }








  //Applies To Below...
  /*
Copyright 2017-2018 Google Inc. All Rights Reserved.
Use of this source code is governed by an MIT-style license that
can be found in the LICENSE file at http://angular.io/license
*/
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a ClientService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`ClientService: ${message}`);
  }

}
