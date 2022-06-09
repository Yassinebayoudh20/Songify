import { Router, ActivatedRoute } from '@angular/router';
import {
  ArtistsClient,
  CreateArtistCommand,
  ArtistDto,
  UpdateArtistCommand,
} from './../../web-api-client';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Artist } from 'src/app/models/artist';
import { map } from 'rxjs/operators';
import { ConvertImageToBase64FromByteArray } from 'src/Helpers/Converters/byteArrayToBase64';

export class ArtistForm {
  id: number | undefined;
  name?: string;
  musicType?: string;
  photo?: string;

  static formToArtistModel(form: FormGroup) {
    var artist = new Artist();
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
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss'],
})
export class FormComponent implements OnInit {
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
    let artist = ArtistForm.formToArtistModel(this.artistForm);
    
    if (id) {
      artist.id = Number(id);
      let artistCommand = new UpdateArtistCommand(artist);


      this.artistService.update(Number(id), artistCommand).subscribe(
        (response) => {
          this.router.navigate(['artists']);
        },
        (error) => {
          console.error('Something went wrong', error);
        }
      );
    } else {
      let artistCommand = new CreateArtistCommand(artist);
      this.artistService.create(artistCommand).subscribe(
        (response) => {
          this.router.navigate(['artists']);
        },
        (error) => {
          console.error('Something went wrong', error);
        }
      );
    }
  }

  async uploadFile(files: any) {
    if (files.length === 0) { return; }
    let fileToUpload = <File>files[0];
    const buffer = await fileToUpload.arrayBuffer();
    let byteArray = Array.from(new Uint8Array(buffer));
    this.artistForm.patchValue({ 'photo' : byteArray });
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
       this.model.photo = ConvertImageToBase64FromByteArray._arrayBufferToBase64(this.model.photo);
       this.artistForm.patchValue({
         'name' : this.model.name,
         'musicType' : this.model.musicType,
         'photo' : this.model.photo
       })
      });
  }
}
