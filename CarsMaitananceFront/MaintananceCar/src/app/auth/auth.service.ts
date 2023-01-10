import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap, of, map } from 'rxjs';
import { Usuarios } from '../Interfaces/usuarios';
import { JsonPipe } from '@angular/common';
import { ConstantPool } from '@angular/compiler';
import { environment } from 'src/enviroments/enviroments';
import * as CryptoJS from 'crypto-js';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baseUrl: string = environment.baseUrl;
  private key: string = environment.SecretKeyToken;
  private _user = <Usuarios>{};
  constructor(private http: HttpClient) { }
  get auth() {
    return { ...this._user }
  }

  login(usuario: Usuarios): Observable<boolean> {
    this._user = usuario;
    //  this.RefreshToken(usuario).subscribe(token => { })
    return this.http.get<Usuarios>(`${this.baseUrl}/api/usuarios/${usuario.user}/${usuario.clave}`)
      .pipe(
        map(auth => {
          this._user = auth;
          localStorage.removeItem("user");
          let encript = CryptoJS.AES.encrypt(JSON.stringify(this._user), this.key).toString();
          localStorage.setItem('user', encript);
          return auth.usuarioID > 0;
        })
      )
  }

  Verificar(): Observable<boolean> {
    const id = this.Decrypt('token');
    if (!id) {
      return of(false);
    }
    this._user = this.Decrypt('user');

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
          let encript = CryptoJS.AES.encrypt(JSON.stringify(tap), this.key).toString();
          localStorage.setItem('token', encript);
        }));
  }

  Decrypt(value: string) {
    let valor = localStorage.getItem(value) ?? '';
    if (valor) {
      let encripta = CryptoJS.AES.decrypt(valor, this.key);
      var decryptedData = JSON.parse(encripta.toString(CryptoJS.enc.Utf8));
      return decryptedData;
    }
    return '';
  }

  verificarModulo(modulo: string) {
    let user = this.auth;
    let value: boolean = false;

    try {
      user.rol.pefilesRoles.forEach(perfilRol => {
        perfilRol.perfil.perfilModuloDetalle.forEach(moduloDetalle => {
          if (moduloDetalle.modulos.nombre === modulo) {
            value = true;
            throw new Error('');
          }
          else {
            value = false;
          }
        })
      });
    }
    catch (err) {
      return value;
    }

    return value;
  }
}
