import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteCreateComponent } from './components/cliente/cliente-create/cliente-create.component';
import { ClienteCrudComponent } from './components/cliente/cliente-crud/cliente-crud.component';

const routes: Routes = [
  {
    path:'',
    component:ClienteCrudComponent

  },
  {
    path:'create',
    component:ClienteCreateComponent

  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
