import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MainPageComponent } from './Components/main-page.component/main-page.component';
import { HeaderComponent } from './Components/header.component/header.component';
import { AuthComponent } from './Components/auth.component/auth.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatRadioModule} from '@angular/material/radio';
import { AuthService } from './Services/AuthService';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TestListComponent  } from './Components/test-list.component/test-list.component';
import { AuthTokenInterceptorService } from './Services/AuthTokenInterceptor';
import { TestService } from './Services/TestService';
import { TestItemComponent } from './Components/test-list.component/test-item.component/test-item.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    HeaderComponent,
    AuthComponent,
    TestListComponent,
    TestItemComponent   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatIconModule,
    FormsModule, 
    ReactiveFormsModule,
    MatButtonModule,
    MatCheckboxModule
  ],
  providers: [
    AuthService,
    TestService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthTokenInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
