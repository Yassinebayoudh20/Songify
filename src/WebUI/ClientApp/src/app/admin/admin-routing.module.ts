import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ArtistsComponent } from './components/artist/artists.component';
import { ArtistFormComponent } from './components/artist/form/artist-form.component';

const routes: Routes = [
  {path : 'admin/artists' , component : ArtistsComponent},
  {path : 'admin/artists/new' , component : ArtistFormComponent},
  {path : 'admin/artists/edit/:id' , component : ArtistFormComponent},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
