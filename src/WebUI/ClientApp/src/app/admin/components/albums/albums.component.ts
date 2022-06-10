import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { AlbumDto, AlbumsClient } from 'src/app/web-api-client';
import { map } from 'rxjs/operators';
import { Observable, Subject } from 'rxjs';
import { ConvertImageToBase64AndByteArray } from 'src/Helpers/Converters/ImageToBase64AndArrayBuffer';
import { ConfirmationService } from 'primeng/api';
import { MessageServiceService } from 'src/sharedServices/message-service.service';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  providers : [ConfirmationService],
  styleUrls: ['./albums.component.scss']
})
export class AlbumsComponent implements OnInit {

  albums$! : Observable<any>;
  updateSubject$: Subject<any> = new Subject();


  constructor(private albumsClient:AlbumsClient,
    private confirmationService: ConfirmationService,
    private messageService : MessageServiceService
    ,private route:Router) { }

  ngOnInit(): void {
    this.findAllAlbums();
    this.updateSubject$.subscribe(()=> {
      console.log("event triggred")
      return this.findAllAlbums()
    });
  }

  findAllAlbums(){
    this.albums$ = this.albumsClient.findAll().pipe(map((data)=>{
      if(data){
        data.albums?.map( a => a.image = ConvertImageToBase64AndByteArray._arrayBufferToBase64(a.image))
        return data.albums
      }
      return [];
    }));
  }

  editAlbum(album:AlbumDto){
    this.route.navigate([`/admin/albums/edit/${album.id}`])
  }

  deleteAlbum(id:number){
    this.confirmationService.confirm({
      message: 'Are you sure that you want to perform this action?',
      accept: () => {
         this.albumsClient.delete(id).subscribe(result => {
          this.messageService.showSuccess("Artist Deleted successfully");
           this.updateSubject$.next();
         },error => {
            //Error Message
         })
      }
  });
  }

}
