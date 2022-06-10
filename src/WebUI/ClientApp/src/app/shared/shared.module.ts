import {RouterModule} from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';

//NgPrime Modules
import {MenubarModule} from 'primeng/menubar';
import {InputTextModule} from 'primeng/inputtext';
import {ButtonModule} from 'primeng/button';
import {CardModule} from 'primeng/card';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {ToastModule} from 'primeng/toast';
import { LoginMenuComponent } from './components/login-menu/login-menu.component';
import { FileUploadComponent } from './components/file-upload/file-upload.component';




@NgModule({
  declarations: [
    NavMenuComponent,
    LoginMenuComponent,
    FileUploadComponent
  ],
  imports: [
    RouterModule,
    CommonModule,
    MenubarModule,
    InputTextModule,
    ButtonModule,
  ],
  exports:[
    NavMenuComponent,
    FileUploadComponent,
    InputTextModule,
    ButtonModule,
    CardModule,
    ConfirmDialogModule,
    ToastModule
    
  ]
})
export class SharedModule { }
