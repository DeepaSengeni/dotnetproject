import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavController, NavParams, ViewController, AlertController, LoadingController } from 'ionic-angular';
import { BooksProvider } from '../../providers/book/book';


/*
  Generated class for the Videopopup page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-Videopopup',
    templateUrl: 'Videopopup.html'
})
export class VideopopupPage {
  file = File;
  playerImg: any;
  videosrc: any;

  @ViewChild('fileInp') fileInput: ElementRef;
  constructor(public navCtrl: NavController,  public loadingCtrl: LoadingController, public navParams: NavParams, public viewCtrl: ViewController, public BooksServiceProvider: BooksProvider, public alertCtrl: AlertController) {
    this.playerImg = '';
  }

    ionViewDidLoad() {
        console.log('ionViewDidLoad VideopopupPage');
    }
  Closemodel() {
    this.viewCtrl.dismiss();
  }
 
  base64ToBlob(base64, mime) {
    mime = mime || '';
    var sliceSize = 1024;
    var byteChars = window.atob(base64);
    var byteArrays = [];

    for (var offset = 0, len = byteChars.length; offset < len; offset += sliceSize) {
      var slice = byteChars.slice(offset, offset + sliceSize);

      var byteNumbers = new Array(slice.length);
      for (var i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i);
      }
      var byteArray = new Uint8Array(byteNumbers);
      byteArrays.push(byteArray);
    }
    return new Blob(byteArrays, { type: mime });
  }

  uploadvideo($event): void {
    this.file = $event.target.files[0];
    console.log(this.file);
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.BooksServiceProvider.Videoupload(this.file).then(success => {
      console.log(success);
      // this.hdnImageData = success;
      this.videosrc = success;
      window.localStorage.setItem('submitvideosrc', this.videosrc);
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: '"Audio uploded successfully"',
        buttons: ['OK']
      });
      alert.present();
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: '"Error in uploading Audio"',
        buttons: ['OK']
      });
      alert.present();
      console.log(error);

    });
    this.readThis($event.target)
  }

  readThis(inputValue: any): void {
    var file: File = inputValue.files[0];
    var myReader: FileReader = new FileReader();
    myReader.onloadend = (e) => {
      this.playerImg = myReader.result;
      localStorage.setItem("Player_Image", myReader.result);
    }
    myReader.readAsDataURL(file);
  }

  change() {
      var htmlcontent = "";
      var screenshot = "";
      var src = "";
      screenshot = ((document.getElementById("screendata") as HTMLInputElement).value);
      var base64ImageContent = screenshot.replace(/^data:image\/(png|jpg);base64,/, "");
      var blob = this.base64ToBlob(base64ImageContent, 'image/png');
    var filename = "Page_ScreenShot.png";
    var pagetype = "Video";
    this.BooksServiceProvider.uploadpic(blob, filename, pagetype).then(success => {
        console.log(success);
        window.localStorage.setItem('videoscreensrc', success);
        this.navCtrl.pop();
      }, (error) => {
        let alert = this.alertCtrl.create({
          title: '"Error in upload screenshot."',
          buttons: ['OK']
        });
        alert.present();
        console.log(error);

      });
    }
  
}
