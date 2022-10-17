import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { BehaviorSubject, catchError, Observable, tap, throwError } from 'rxjs';
import { SignInModel } from '../Models/SignInModel';
import { LoginModel } from '../Models/LoginModel';
import { environment } from 'src/environments/environment';
import { UserModel } from '../Models/UserModel';

@Injectable()
export class AuthService {

  public userSub = new BehaviorSubject<UserModel>(null);
  private tokenExpirationTimer: any;
  public isAuth: boolean = false;

  constructor(private http: HttpClient, private router: Router) {

  }

  public login(email: string, password: string): Observable<SignInModel> {
    let loginModel = new LoginModel(email, password);

    return this.http.post<SignInModel>(environment.API_BASE_URL + '/api/auth/login', loginModel)
      .pipe(
        catchError(erorr => throwError(erorr.message)),
        tap(response => {

          const user = new UserModel(response.userId, response.user.email, response.user.roles, response.user.tests);
          this.userSub.next(user);

          const timeNow: number = new Date().getTime();
          const expirationDuration: number = new Date(response.expires).getTime() - timeNow;

          this.autoLogout(expirationDuration);

          localStorage.setItem('userData', JSON.stringify(response));
          this.isAuth = true;
        })
      );
  }

  public autoLogin(): void {
    const userData: SignInModel = JSON.parse(localStorage.getItem('userData'));

    if (!userData) {
      return;
    }

    const loadedUser = new UserModel(userData.userId, userData.user.email, userData.user.roles, userData.user.tests);

    if (userData.expires) {

      this.userSub.next(loadedUser);

      const timeNow: number = new Date().getTime();
      const expirationDuration = new Date(userData.expires).getTime() - timeNow;
      this.autoLogout(expirationDuration);

      this.isAuth = true;
    }
  }

  public logout(): void {
    this.userSub.next(null);
    this.router.navigate(['/auth']);
    localStorage.removeItem('userData');

    if (this.tokenExpirationTimer) {
      clearTimeout(this.tokenExpirationTimer);
    }
    this.tokenExpirationTimer = null;
    this.isAuth = false;
  }

  private autoLogout(expirationDuration: number): void {
    this.tokenExpirationTimer = setTimeout(() => {
      this.logout();
    }, expirationDuration);
  }
}