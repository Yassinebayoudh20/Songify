import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { ArtistRoutingModule } from './artist-routing.module';
import { ArtistsComponent } from './artists.component';

import {CardModule} from 'primeng/card';
import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import { FormComponent } from './form/form.component';
import {FileUploadModule} from 'primeng/fileupload';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ToastModule} from 'primeng/toast';



@NgModule({
  declarations: [
    ArtistsComponent,
    FormComponent
  ],
  imports: [
    CommonModule,
    ArtistRoutingModule,
    ReactiveFormsModule,
    CardModule,
    InputTextModule,
    FileUploadModule,
    ButtonModule,
    ConfirmDialogModule,
    ToastModule
  ]
})
export class ArtistModule { }
