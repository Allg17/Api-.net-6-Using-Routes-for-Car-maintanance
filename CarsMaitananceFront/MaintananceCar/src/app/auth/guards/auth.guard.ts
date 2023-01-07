import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanLoad, Route, Router, RouterStateSnapshot, UrlSegment, UrlTree } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate,  CanLoad {
  constructor(private authservice: AuthService, private router: Router) { }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.authservice.Verificar().pipe(
      tap(res => {
        console.log(route,state)
        if (!res) {
          this.router.navigate(['/auth/login']);
        }
      })
    );
  }
  canLoad(
    route: Route,
    segments: UrlSegment[]): Observable<boolean> | Promise<boolean> | boolean {
    return this.authservice.Verificar().pipe(
      tap(res => {
        console.log(route,segments)
        if (!res) {
          this.router.navigate(['/auth/login']);
        }
      })
    );

  }
}
