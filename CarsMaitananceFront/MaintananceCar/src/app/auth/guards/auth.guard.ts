import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanLoad {
  constructor(private authservice: AuthService, private router: Router) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.authservice.Verificar().pipe(
      tap(res => {
        console.log(route, state)

        console.log(this.authservice.auth)
        let url = route.url[0].path
        if(route.url.length >1)
        {
          url = route.url[0].path + '/' + route.url[1].path
        }
        if (url != "mantenimiento") {
          if (!this.authservice.verificarModulo(url)) {
            alert("No estas autorizado para acceder a este modulo")
            this.router.navigate(['/404']);
          }
        }


        if (!res) {
          this.router.navigate(['/auth/login'])
        }
      })
    );
  }

  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return this.authservice.Verificar().pipe(
      tap(res => {
        console.log(route, segments)

        if (!res) {
          this.router.navigate(['/auth/login']);
        }
      })
    );




  }
}
