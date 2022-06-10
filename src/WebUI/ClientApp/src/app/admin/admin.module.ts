import { SharedModule } from './../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { ArtistsComponent } from './components/artist/artists.component';
import { ArtistFormComponent } from './components/artist/form/artist-form.component';
import {ReactiveFormsModule } from '@angular/forms';
import { AlbumsComponent } from './components/albums/albums.component';
import { AlbumFormComponent } from './components/albums/form/album-form.component';


@NgModule({
  declarations: [
    AdminComponent,
    ArtistsComponent,
    ArtistFormComponent,
    AlbumsComponent,
    AlbumFormComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class AdminModule { }
