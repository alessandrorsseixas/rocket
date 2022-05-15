import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente.model';
import { WebApiReturn } from '../models/webapireturn.model';
import { AppGenericeService } from './app.generic.service';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  constructor(private http: HttpClient,private appGeneric:AppGenericeService<Cliente>) { 

    appGeneric.apiServiceBase='https://localhost:44380/v1/';
    appGeneric.apiController='clientes/'
  }

  public getAll(page: number = 1, size: number = 10, sort: string = 'nome',order: true | false, search: string = ''):
    // Observable<{ pagination: SystemPagination; webApiReturn: WebApiReturn }> 
    Observable<WebApiReturn>
  {
    return  this.appGeneric.getAll(1,10,'nome',true,'','list-clientes');
  }

  public getById(id: string,endpoint: string=''): Observable<WebApiReturn> {
   
    return this.appGeneric.getById('');
  }

  public create(resource: Partial<Cliente> & { toJson: () => Cliente}): Observable<WebApiReturn>{
    return this.appGeneric.create(resource,'add-cliente')
  }

  public update(resource: Partial<Cliente> & { toJson: () => Cliente}): Observable<WebApiReturn>{
    return this.appGeneric.update(resource,'update-cliente')
  }

   public delete(id: string): Observable<WebApiReturn> {
    return this.appGeneric.delete(id,'');
   }
}
