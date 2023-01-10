import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Solicitud } from 'src/app/Interfaces/Solicitud';
import { environment } from 'src/enviroments/enviroments';

@Injectable({
  providedIn: 'root'
})
export class SolicitudService {
  private baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  Agregar(solicitud: Solicitud) {
    return this.http.post<Solicitud>(`${this.baseUrl}/api/Solicitudes`, solicitud);
  }

  Actualizar(solicitud: Solicitud) {
    return this.http.put<boolean>(`${this.baseUrl}/api/Solicitudes`, solicitud);
  }


  GetallSolicitud() {
    return this.http.get<Solicitud[]>(`${this.baseUrl}/api/Solicitudes`);
  }

  GetSolicitud(id: number) {
    return this.http.get<Solicitud>(`${this.baseUrl}/api/Solicitudes/${id}`);
  }

  GetSolicitudesByArea(id: number) {
    return this.http.get<Solicitud[]>(`${this.baseUrl}/api/Solicitudes/GetSolicitudesByArea/${id}`);
  }

  GetSolicitudByArea(id: number, areas:string) {
    return this.http.get<Solicitud>(`${this.baseUrl}/api/Solicitudes/GetSolicitudByArea/${id}/${areas}`);
  }

  Despachar(id: number) {
    return this.http.put<boolean>(`${this.baseUrl}/api/Solicitudes/UpdateSolicitudesDespacho/?id=${id}`, id);
  }
}
