import { Injectable } from "@angular/core";
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse
} from "@angular/common/http";
import { throwError, Observable, BehaviorSubject, of, finalize } from "rxjs";
import { catchError, filter, take, switchMap } from "rxjs/operators";
import { AuthService } from "../auth/auth.service";
import { environment } from "src/enviroments/enviroments";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  private AUTH_HEADER = "Authorization";

  private refreshTokenInProgress = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(
    null
  );

  constructor(private authService: AuthService) { }
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    if (!req.headers.has("Content-Type")) {
      req = req.clone({
        headers: req.headers.set("Content-Type", "application/json")
      });
    }

    req = this.addAuthenticationToken(req);

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error && error.status === 401) {

          if (this.refreshTokenInProgress) {

            return this.refreshTokenSubject.pipe(
              filter(result => result !== null),
              take(1),
              switchMap(() => next.handle(this.addAuthenticationToken(req)))
            );
          } else {
            this.refreshTokenInProgress = true;

            this.refreshTokenSubject.next(null);

            return this.refreshAccessToken().pipe(
              switchMap((success: boolean) => {
                this.refreshTokenSubject.next(success);
                return next.handle(this.addAuthenticationToken(req));
              }),

              finalize(() => (this.refreshTokenInProgress = false))
            );
          }
        } else {
          return throwError(error);
        }
      })
    ) as Observable<HttpEvent<any>>;
  }

  private refreshAccessToken(): Observable<any> {
    return of(this.authService.Decrypt('token'));
  }

  private addAuthenticationToken(request: HttpRequest<any>): HttpRequest<any> {


    let token: string = this.authService.Decrypt('token')
    if (!token) {
      this.authService.RefreshToken(this.authService.auth).subscribe((token) => { token = token; });
    }

    if (!request.url.match(environment.baseUrl + "/api")) {
      return request;
    }
    return request.clone({
      headers: request.headers.set(this.AUTH_HEADER, "Bearer " + token)
    });
  }
}