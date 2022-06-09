import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthorizeGuard } from '../api-authorization/guards/authorize.guard';
import { TokenComponent } from './token/token.component';

export const routes: Routes = [
  { path: 'token', component: TokenComponent, canActivate: [AuthorizeGuard] },
  {path : 'admin' , loadChildren : () => import("./admin/admin.module").then(m => m.AdminModule) , canActivate : [AuthorizeGuard]},
  {path : '' , loadChildren : () => import("./public/public.module").then(m => m.PublicModule)}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
