import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';


const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: '**',
        redirectTo: '../404'
      }
    ]
  }
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports:[RouterModule]
})
export class AuthRoutingModule { }
