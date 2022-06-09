import { FormComponent } from './form/form.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistsComponent } from './artists.component';

const routes: Routes = [
  {path : '' , component : ArtistsComponent},
  {path : 'new' , component : FormComponent},
  {path : 'edit/:id' , component : FormComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArtistRoutingModule { }