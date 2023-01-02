import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Clientes } from 'src/app/Interfaces/Clientes';
import { environment } from 'src/enviroments/enviroments';
@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  private baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  BuscarCliente(valor:string)
  {
    return this.http.get<Clientes>(`${this.baseUrl}/api/Clientes/GetClienteByCedula/{id}?ClienteID=${valor}`);
  }

  Agregar(cliente:Clientes)
  {
    return this.http.post<Clientes>(`${this.baseUrl}/api/Clientes`,cliente);
  }
}
