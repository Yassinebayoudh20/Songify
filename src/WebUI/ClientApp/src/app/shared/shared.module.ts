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




@NgModule({
  declarations: [
    NavMenuComponent,
    LoginMenuComponent
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
    InputTextModule,
    ButtonModule,
    CardModule,
    ConfirmDialogModule,
    ToastModule
    
  ]
})
export class SharedModule { }
