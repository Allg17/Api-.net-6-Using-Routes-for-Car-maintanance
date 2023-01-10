import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Recordatorio } from 'src/app/Interfaces/Recordatorio';
import { environment } from 'src/enviroments/enviroments';

@Injectable({
  providedIn: 'root'
})
export class RecordatorioService {

  private baseUrl: string = environment.baseUrl;
  constructor(private http: HttpClient) { }

  Agregar(recordatorio: Recordatorio) {
    return this.http.post<Recordatorio>(`${this.baseUrl}/api/Recordatorios`, recordatorio);
  }

  Getall() {
    return this.http.get<Recordatorio[]>(`${this.baseUrl}/api/Recordatorios`);
  }

  Actualizar(Recordatorio: Recordatorio) {
    return this.http.put<Recordatorio>(`${this.baseUrl}/api/Recordatorios`, Recordatorio);
  }


}
