import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/enviroments/enviroments';
import { Facturas } from '../../Interfaces/Facturas';

@Injectable({
  providedIn: 'root'
})
export class FacturarService {

  private baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  Agregar(factura: Facturas) {
    return this.http.post<Facturas>(`${this.baseUrl}/api/Facturas`, factura);
  }
  Actualizar(factura: Facturas) {
    return this.http.put<Facturas>(`${this.baseUrl}/api/Facturas`, factura);
  }
  Getallfacturas() {
    return this.http.get<Facturas[]>(`${this.baseUrl}/api/Facturas`);
  }

  get(id: number) {
    return this.http.get<Facturas>(`${this.baseUrl}/api/Facturas/${id}`);
  }


}
