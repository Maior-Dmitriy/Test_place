import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SignInModel } from '../../Models/SignInModel';
import { AuthService } from '../../Services/AuthService';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent implements OnInit {

  public id: number;
  public authForm: FormGroup;
  public hide: boolean = true;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.initForm();
  }

  private initForm(): void {
    this.authForm = new FormGroup({
      'email': new FormControl(null, [Validators.required, Validators.email]),
      'password': new FormControl(null, [Validators.required])
    });
  }

  public onSubmit(): void {

    console.log(this.authForm.value['email']);
    
    if (this.authForm.valid) {
      const email = this.authForm.value['email'];
      const password = this.authForm.value['password'];

      let authObs: Observable<SignInModel> = this.authService.login(email, password);

      authObs.subscribe(
        resData => {
          this.router.navigate(['/tests']);
        },
        errorMessage => {
          console.log(errorMessage);
        }
      );

      this.authForm.reset();
    }
  }
}
