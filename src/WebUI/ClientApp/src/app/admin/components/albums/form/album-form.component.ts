import { AlbumDto, ArtistDto, ArtistsClient, CreateAlbumCommand, UpdateAlbumCommand } from './../../../../web-api-client';
import { AlbumsClient } from 'src/app/web-api-client';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/operators';
import { ConvertImageToBase64AndByteArray } from 'src/Helpers/Converters/ImageToBase64AndArrayBuffer';
import { Observable } from 'rxjs';

export class AlbumForm {
  id: number | undefined;
  title?: string;
  artistId?: number;
  image?: string;

  static formToAlbumModel(form: FormGroup) {
    var album = new AlbumDto();
    album.id = form.get('id')?.value;
    album.title = form.get('title')?.value;
    album.artistId = form.get('artistId')?.value;
    album.image = form.get('image')?.value;
    return album;
  }

  static albumModelToForm(album: AlbumDto | undefined) {
    let instance = new this();
    instance.id = album?.id;
    instance.title = album?.title;
    instance.artistId = album?.artistId;
    instance.image = album?.image;
    return instance;
  }
}

@Component({
  selector: 'app-album-form',
  templateUrl: './album-form.component.html',
  styleUrls: ['./album-form.component.scss'],
})
export class AlbumFormComponent implements OnInit {
  albumForm!: FormGroup;
  pageTitle!: string;
  buttonText!: string;
  model!: AlbumForm;
  artists!: ArtistDto[] | undefined ;
  //artistId!: ArtistDto;

  constructor(
    private albumClient: AlbumsClient,
    private activatedRouter: ActivatedRoute,
    private artistClient : ArtistsClient,
    private router : Router
  ) {
    this.albumForm = new FormGroup({
      title: new FormControl('', Validators.required),
      file: new FormControl(null),
      image: new FormControl([]),
      artistId: new FormControl(null, Validators.required),
    });
  }

  ngOnInit(): void {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
    this.buttonText = id ? 'Update' : 'Save';
    this.pageTitle = id ? 'Update Album' : 'Add new Album';
    this.getArtists();
    if (id) {
      this.getAlbum(id);
    }
  }

  //Form Getters
  get title() {
    return this.albumForm.get('title');
  }
  get artist() {
    return this.albumForm.get('artist');
  }
  get file() {
    return this.albumForm.get('file');
  }
  get artistId() {
    return this.albumForm.get('artistId');
  }

  onSubmit() {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
  
    let album = AlbumForm.formToAlbumModel(this.albumForm);
 
    if (id) {
      album.id = Number(id);
      let albumCommand = new UpdateAlbumCommand(album);
      
      this.albumClient.update(Number(id), albumCommand).subscribe(
        (response) => {
          this.router.navigate(['admin/albums']);
        },
        (error) => {
          console.error('Something went wrong', error);
        }
      );
    } else {
      let albumCommand = new CreateAlbumCommand(album);
      this.albumClient.create(albumCommand).subscribe(
        (response) => {
          this.router.navigate(['admin/albums']);
        },
        (error) => {
          console.error('Something went wrong', error);
        }
      );
    }
  }

  patchValueForImage($event: any) {
    this.albumForm.patchValue({ image: $event });
  }

  getAlbum(id: any) {
    this.albumClient
      .findById(id)
      .pipe(
        map((data) => {
          return data.album;
        })
      )
      .subscribe((response) => {
        this.model = AlbumForm.albumModelToForm(response);
        if (this.model.image)
          this.model.image =
            ConvertImageToBase64AndByteArray._arrayBufferToBase64(
              this.model.image
            );
        this.albumForm.patchValue({
          title: this.model.title,
          artistId: this.model.artistId,
          photo: this.model.image,
        });
      });
  }

  getArtists(){
   this.artistClient.findAll().subscribe((result)=>{
     this.artists = result.artists  });
  }
}
