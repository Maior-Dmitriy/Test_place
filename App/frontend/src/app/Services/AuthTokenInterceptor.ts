import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpParams } from '@angular/common/http';
import { SignInModel } from '../Models/SignInModel';


@Injectable()
export class AuthTokenInterceptorService implements HttpInterceptor {
  constructor() { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    const userData: SignInModel = JSON.parse(localStorage.getItem('userData'));
    const token: string = userData?.accessToken;

    if (token) {
      const modifiedReq = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
      return next.handle(modifiedReq);
    }
    return next.handle(req)
  }
}