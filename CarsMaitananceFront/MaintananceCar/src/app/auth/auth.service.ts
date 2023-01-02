import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap, of, map } from 'rxjs';
import { Usuarios } from '../Interfaces/usuarios';
import { JsonPipe } from '@angular/common';
import { ConstantPool } from '@angular/compiler';
import { environment } from 'src/enviroments/enviroments';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = environment.baseUrl;
  private _user = <Usuarios>{};
  constructor(private http: HttpClient) { }
  get auth() {
    return { ...this._user }
  }

  login(usuario: Usuarios): Observable<boolean> {
    this._user = usuario;
    this.RefreshToken(usuario).subscribe(token => { })
    return this.http.get<Usuarios>(`${this.baseUrl}/api/usuarios/${usuario.user}/${usuario.clave}`)
      .pipe(
        map(auth => {
          this._user = auth;
          localStorage.removeItem("user");
          localStorage.setItem('user', JSON.stringify(auth));
          return auth.usuarioID > 0;
        })
      )
  }

  Verificar(): Observable<boolean> {
    const id = localStorage.getItem('token');
    if (!id) {
      return of(false);
    }

    this._user = JSON.parse(localStorage.getItem('user') ?? "");

    if (!this._user.user) {
      return of(false);
    }

    return this.http.get<Usuarios>(`${this.baseUrl}/api/usuarios/${this._user.user}/${this._user.clave}`)
      .pipe(
        map(auth => {
          this._user = auth;
          return auth.usuarioID > 0;
        })
      )
  }


  logout() {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    this._user = <Usuarios>{};
  }

  RefreshToken(usuario: Usuarios): Observable<string> {
    return this.http.post<string>(`${this.baseUrl}/security/createToken`, usuario)
      .pipe(
        tap(tap => {
          localStorage.removeItem("token");
          localStorage.setItem('token', tap);
        }));
  }
}
