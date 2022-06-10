import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorizeGuard } from 'src/api-authorization/guards/authorize.guard';
import { AlbumsComponent } from './components/albums/albums.component';
import { AlbumFormComponent } from './components/albums/form/album-form.component';
import { ArtistsComponent } from './components/artist/artists.component';
import { ArtistFormComponent } from './components/artist/form/artist-form.component';

const routes: Routes = [
  {path : 'admin/artists' , component : ArtistsComponent ,canActivate : [AuthorizeGuard]},
  {path : 'admin/artists/new' , component : ArtistFormComponent,canActivate : [AuthorizeGuard]},
  {path : 'admin/artists/edit/:id' , component : ArtistFormComponent,canActivate : [AuthorizeGuard]},
  {path : 'admin/albums' , component : AlbumsComponent,canActivate : [AuthorizeGuard]},
  {path : 'admin/albums/new' , component : AlbumFormComponent,canActivate : [AuthorizeGuard]},
  {path : 'admin/albums/edit/:id' , component : AlbumFormComponent,canActivate : [AuthorizeGuard]},

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
