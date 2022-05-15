import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Portes } from '../models/porte.model';
import { WebApiReturn } from '../models/webapireturn.model';
import { AppGenericeService } from './app.generic.service';

@Injectable({
  providedIn: 'root'
})
export class PorteService {

  constructor(private http: HttpClient,private appGeneric:AppGenericeService<Portes>) { 

      appGeneric.apiServiceBase='http://localhost:3001/';
      appGeneric.apiController='portes'
  }

  public get(): Observable<WebApiReturn> {
    
    return this.appGeneric.get('');
  }
}
