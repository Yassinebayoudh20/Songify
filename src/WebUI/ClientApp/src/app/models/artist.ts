export class Artist {
  id: number | undefined;
  name?: string;
  musicType? : string;
  photo?: string;

  constructor(data: any = null) {
    if (data) {
      this.id = data.id;
      this.name = data.name;
      this.musicType = data.musicType
      this.photo = data.photo;
    }
  }
}
