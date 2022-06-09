import { Component, OnInit } from '@angular/core';
import { MenuItem , PrimeIcons } from 'primeng/api';
import { faCoffee } from '@fortawesome/free-solid-svg-icons';
import { AuthorizeService } from 'src/api-authorization/services/authorize.service';



@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss'],
})
export class NavMenuComponent implements OnInit {
   items!: MenuItem[];
   isUserAdminAndAuthenticated! : boolean;

   constructor(private authorize: AuthorizeService){ }

  ngOnInit(): void {

    this.items = [
      {
          label: 'Admin Management',
          icon : "pi pi-sliders-h",
          items: [
              {label: 'Artists' , icon : "pi pi-star-fill" , routerLink : ['admin/artists'],items:[
                {label : 'Add' , icon : "pi pi-plus-circle" , routerLink : ['admin/artists/new']}
              ]},
              {label: 'Songs' , icon : "pi pi-play" },
              {label: 'Albums' , icon : "pi pi-book" },
          ]
      },
  ];
  }
}
