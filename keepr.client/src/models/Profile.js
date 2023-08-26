import { Base } from "./Base.js"

export class Profile extends Base {
  constructor(data) {
    super(data);
    this.name = data.name;
    this.picture = data.picture;
    this.coverImg = data.coverImg;
  }
}