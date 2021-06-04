import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { FormRegisterComponent } from './form-register/form-register.component';
import { AcercaDeComponent } from './acerca-de/acerca-de.component';

const routes: Routes = [

{
  path: 'Registro',
  component: FormRegisterComponent
},

{
  path: 'AcercaDe',
  component: AcercaDeComponent
}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
