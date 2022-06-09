import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { Component, OnInit } from '@angular/core';
import { AlbumsClient, ArtistListVm, ArtistsClient } from '../../../web-api-client';
import {ConfirmationService} from 'primeng/api';
import {MessageService} from 'primeng/api';
import { map } from 'rxjs/operators';
import { ConvertImageToBase64FromByteArray } from 'src/Helpers/Converters/byteArrayToBase64';
import { MessageServiceService } from 'src/sharedServices/message-service.service';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  providers : [ConfirmationService],
  styleUrls: ['./artists.component.scss']
})
export class ArtistsComponent implements OnInit {

  artists$! : Observable<any>;
  updateSubject$: Subject<any> = new Subject();

  constructor(private artists : ArtistsClient,
     private router : Router,
     private confirmationService: ConfirmationService,
     private messageService : MessageServiceService) { }

  ngOnInit(): void {
    this.findAllArtists();
    this.updateSubject$.subscribe(()=> {
      console.log("event triggred")
      return this.findAllArtists()
    });
  }

  findAllArtists(){
    this.artists$ = this.artists.findAll().pipe(
      map(data => {
        data.artists?.map(a => a.photo  = ConvertImageToBase64FromByteArray._arrayBufferToBase64(a.photo))
        return data.artists
      })
    );
  }

  editArtist(editArtist : any){
    this.router.navigate([`admin/artists/edit/${editArtist.id}`]);
  }

  deleteArtist(id:number){
    this.confirmationService.confirm({
      message: 'Are you sure that you want to perform this action?',
      accept: () => {
         this.artists.delete(id).subscribe(result => {
          this.messageService.showSuccess("Artist Deleted successfully");
           this.updateSubject$.next();
         },error => {
            //Error Message
         })
      }
  });
  }



}
