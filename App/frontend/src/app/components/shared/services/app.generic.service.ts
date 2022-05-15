import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { ResourceModel } from "../models/resource.model";
import { WebApiReturn } from "../models/webapireturn.model";



@Injectable({
  providedIn: 'root'
})


export abstract class AppGenericeService<T extends ResourceModel<T>> {
  private webApiReturn!: Observable<WebApiReturn>;
  private apiUrl!: string


  // public tConstructor: { new(m: Partial<T>, ...args: unknown[]): T };
  public apiServiceBase!: string;
  public apiEndpoint!: string;
  public apiController!: string;


  constructor(
    private httpClient: HttpClient
  ) {}


  // public get(): Observable<T[]> {

  //   this.webApiReturn = this.httpClient
  //     .get<WebApiReturn>(`${this.apiUrl}`)
  //   return this.webApiReturn.pipe(map((result) => result.data));
  // }

  public getAll(page: number = 1, size: number = 10, sort: string = 'description',order: true | false, search: string = '',endpoint: string = ''):
    // Observable<{ pagination: SystemPagination; webApiReturn: WebApiReturn }> 
    Observable<WebApiReturn>
    {

      this.apiEndpoint = endpoint;
      return  this.webApiReturn = this.httpClient
      .get<WebApiReturn>(`${this.apiServiceBase}${this.apiController}${this.apiEndpoint}`
      ,{
         params: {
           page: page,
           size: size,
           sort,
           order,
           search
           }
      });    
  }
 

  

  public getById(id: string,endpoint: string=''): Observable<WebApiReturn> {
    this.apiEndpoint = endpoint;
    return this.httpClient
      .get<WebApiReturn>(`${this.apiServiceBase}${this.apiController}${this.apiEndpoint}${id}`)
  }

  public create(resource:T,endpoint: string=''): Observable<WebApiReturn>{
    this.apiEndpoint = endpoint;
    return this.webApiReturn = this.httpClient
      .post<WebApiReturn>(`${this.apiServiceBase}${this.apiController}${this.apiEndpoint}`,resource)
  }

  public update(resource:T,endpoint: string=''): Observable<WebApiReturn>{
    this.apiEndpoint = endpoint;
    return this.webApiReturn = this.httpClient
      .put<WebApiReturn>(`${this.apiServiceBase}${this.apiController}${this.apiEndpoint}`, resource)
  }

   public delete(id: string,endpoint: string =''): Observable<WebApiReturn> {
     this.apiEndpoint = endpoint; 
     return this.httpClient.delete<WebApiReturn>(`${this.apiServiceBase}${this.apiController}${this.apiEndpoint}${id}`);
   }
}