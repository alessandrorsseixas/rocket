import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResourceModel } from '../models/resource.model';

@Injectable({
  providedIn: 'root'
})
export class AppJsonserverService<T extends ResourceModel<T>> {
  private apiUrl!: string


  // public tConstructor: { new(m: Partial<T>, ...args: unknown[]): T };
  public apiServiceBase!: string;
  public apiEndpoint!: string;
  public apiController!: string;


  constructor(
    private httpClient: HttpClient
  ) {}

  public get(endpoint: string=''): Observable<T[]> {
    this.apiEndpoint = endpoint;
    return  this.httpClient
      .get<T[]>(`${this.apiServiceBase}${this.apiController}${this.apiEndpoint}`)
  }

}
