import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './Components/auth.component/auth.component';
import { MainPageComponent } from './Components/main-page.component/main-page.component';
import { AuthGuard } from './Services/AuthGurd';

const routes: Routes = [
  { path: '', redirectTo: '/auth', pathMatch: 'full' },
  { path:'auth', component: AuthComponent },
  { path:'tests', component: MainPageComponent, canActivate: [AuthGuard] },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
