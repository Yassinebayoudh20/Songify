import { Component, Input, OnInit, Output , EventEmitter } from '@angular/core';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {

  @Output() ImageByteArray = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  async uploadFile(files:any){
    if (files.length === 0) { return; }
    let fileToUpload = <File>files[0];
    const buffer = await fileToUpload.arrayBuffer();
    let byteArray = Array.from(new Uint8Array(buffer));
    this.ImageByteArray.emit(byteArray)
  }

}
