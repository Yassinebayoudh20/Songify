import { Router, ActivatedRoute } from '@angular/router';
import {
  ArtistsClient,
  CreateArtistCommand,
  ArtistDto,
  UpdateArtistCommand,
} from '../../../../web-api-client';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { map } from 'rxjs/operators';
import { ConvertImageToBase64AndByteArray } from 'src/Helpers/Converters/ImageToBase64AndArrayBuffer';

export class ArtistForm {
  id: number | undefined;
  name?: string;
  musicType?: string;
  photo?: string;

  static formToArtistModel(form: FormGroup) {
    var artist = new ArtistDto();
    artist.id = form.get('id')?.value;
    artist.name = form.get('name')?.value;
    artist.musicType = form.get('musicType')?.value;
    artist.photo = form.get('photo')?.value;
    return artist;
  }

  static artisModelToForm(artist: ArtistDto | undefined) {
    let instance = new this();
    instance.id = artist?.id;
    instance.name = artist?.name;
    instance.musicType = artist?.musicType;
    instance.photo = artist?.photo;
    return instance;
  }
}

@Component({
  selector: 'app-form',
  templateUrl: './artist-form.component.html',
  styleUrls: ['./artist-form.component.scss'],
})
export class ArtistFormComponent implements OnInit {
  artistForm!: FormGroup;
  pageTitle!: string;
  buttonText!: string;
  model!: ArtistForm;

  constructor(
    private artistService: ArtistsClient,
    private activatedRouter: ActivatedRoute,
    private router: Router,
  ) {
    this.artistForm = new FormGroup({
      name: new FormControl('', Validators.required),
      file: new FormControl(null),
      photo: new FormControl([]),
      musicType: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
    this.buttonText = id ? 'Update' : 'Save';
    this.pageTitle = id ? 'Update Artist' : 'Add new Artist';
    if (id) {
      this.getArtist(id);
    }
  }

  //Form Getters
  get name() {
    return this.artistForm.get('name');
  }
  get musicType() {
    return this.artistForm.get('musicType');
  }
  get file() {
    return this.artistForm.get('file');
  }
  get photo() {
    return this.artistForm.get('photo');
  }

  onSubmit() {
    let id = this.activatedRouter.snapshot.paramMap.get('id');
    //Here I am trying to Convert back the Photo to ArrayBuffer in order to send it to the server
    //this.artistForm.patchValue({'photo' : ConvertImageToBase64AndByteArray._base64ToarrayBuffer(this.model.photo)})
    let artist = ArtistForm.formToArtistModel(this.artistForm);
    if (id) {
      artist.id = Number(id);
      let artistCommand = new UpdateArtistCommand(artist);

      this.artistService.update(Number(id), artistCommand).subscribe(
        (response) => {
          this.router.navigate(['admin/artists']);
        },
        (error) => {
          console.error('Something went wrong', error);
        }
      );
    } else {
      let artistCommand = new CreateArtistCommand(artist);
      this.artistService.create(artistCommand).subscribe(
        (response) => {
          this.router.navigate(['admin/artists']);
        },
        (error) => {
          console.error('Something went wrong', error);
        }
      );
    }
  }

  patchValueForImage($event : any){
    this.artistForm.patchValue({ 'photo' : $event });
  }

  getArtist(id: any) {
    this.artistService
      .findById(id)
      .pipe(
        map((data) => {
          return data.artist;
        })
      )
      .subscribe((response) => {
       this.model = ArtistForm.artisModelToForm(response);
       this.model.photo = ConvertImageToBase64AndByteArray._arrayBufferToBase64(this.model.photo);
       this.artistForm.patchValue({
         'name' : this.model.name,
         'musicType' : this.model.musicType,
         'photo' : this.model.photo
       })
      });
  }
}
