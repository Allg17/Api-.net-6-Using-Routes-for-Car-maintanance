import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enviroments/enviroments';
import { Areas } from '../../Interfaces/Areas';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

  private baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  GetAreas()
  {
    return this.http.get<Areas[]>(`${this.baseUrl}/api/areas`);
  }

  BuscarBylimit(valor:string,limit:number)
  {
    return this.http.get<Areas[]>(`${this.baseUrl}/api/areas/GetAreas/${valor}/${limit}`);
  }
}
