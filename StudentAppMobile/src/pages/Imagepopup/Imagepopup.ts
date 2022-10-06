import { Component, ElementRef, ViewChild } from '@angular/core';
import { NavController, NavParams, ViewController, AlertController, LoadingController } from 'ionic-angular';
import { BooksProvider } from '../../providers/book/book';

/*
  Generated class for the Imagepopup page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-Imagepopup',
    templateUrl: 'Imagepopup.html'
})
export class ImagepopupPage {
  imagesrc: any;
  playerImg: any;
  file = File;

  @ViewChild('fileInp') fileInput: ElementRef;
  constructor(public navCtrl: NavController, public navParams: NavParams, public loadingCtrl: LoadingController, public viewCtrl: ViewController, public BooksServiceProvider: BooksProvider, public alertCtrl: AlertController) { }

    ionViewDidLoad() {
        console.log('ionViewDidLoad ImagepopupPage');
    }


  Closemodel()
 {
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
  
  changeListener($event): void {
    window.localStorage.setItem('imagefilesrcone', $event.target.files[0].name);
    this.readThis($event.target);
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
 //   alert();
    var htmlcontent = "";
    var screenshot = "";
    var src = "";
    //screenshot = localStorage.getItem("Player_Image");
    screenshot = ((document.getElementById("screendata") as HTMLInputElement).value);
 //   window.localStorage.setItem("imagedataimg", screenshot);
    var base64ImageContent = screenshot.replace(/^data:image\/(png|jpg);base64,/, "");
    var blob = this.base64ToBlob(base64ImageContent, 'image/png');
    var filename = window.localStorage.getItem('imagefilesrcone');
    var PageType = "Image";
    this.BooksServiceProvider.uploadpic(blob, filename, PageType).then(success => {
  //    console.log(success);
      window.localStorage.setItem('imagesrc', success);
      window.localStorage.setItem('imagefilesrcone', '');
      this.navCtrl.pop();
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: '"Error in upload screenshot."',
        buttons: ['OK']
      });
      alert.present();
    //  console.log(error);
    });
  }



}
