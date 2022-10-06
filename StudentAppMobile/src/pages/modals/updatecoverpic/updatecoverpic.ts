import { Component } from '@angular/core';
import { NavController, NavParams, AlertController, LoadingController, ViewController } from 'ionic-angular';
import { ImageUploadProvider } from '../../../providers/image-upload/image-upload';
/*
  Generated class for the updatecoverpic page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
  selector: 'page-updatecoverpic',
  templateUrl: 'updatecoverpic.html'
})
export class updatecoverpicPage {

  playerImg: any;
  file: File;

  constructor(public navCtrl: NavController, public viewCtrl: ViewController, public navParams: NavParams, public alertCtrl: AlertController, public imageuploadService: ImageUploadProvider, public loadingCtrl: LoadingController)
  {

  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad updatecoverpicPage');
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
    this.file = $event.target.files[0];
    window.localStorage.setItem('coverimagename', $event.target.files[0].name);
    this.readThis($event.target);
  }

  readThis(inputValue: any): void {
    var file: File = inputValue.files[0];
    var myReader: FileReader = new FileReader();
    myReader.onloadend = (e) => {
      this.playerImg = myReader.result;
      localStorage.setItem("coverimage", myReader.result);
    }
    myReader.readAsDataURL(file);
  }

  change() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let filename = window.localStorage.getItem('coverimagename');
    if (this.file != null && filename != "") {
      this.imageuploadService.Updateprofile(this.file, filename).then(success => {
        console.log(success);
        loading.dismiss();
        let userid = window.localStorage.getItem('Userid');
        this.imageuploadService.UpdateCoverPic(userid, success).then(success => {
          let alert = this.alertCtrl.create({
            title: '"Cover Image Updated Successfully"',
            buttons: ['OK']
          });
          alert.present();
          this.navCtrl.pop();
        });
      },
        (error) => {
          loading.dismiss();
          let alert = this.alertCtrl.create({
            title: '"Error in uploading File"',
            buttons: ['OK']
          });
          alert.present();
          console.log(error);

        });
    }
    else
    {
      let alert = this.alertCtrl.create({
        title: '"Please select a file !"',
        buttons: ['OK']
      });
      alert.present();
    }

  }

  dismiss() {
    this.viewCtrl.dismiss();
  }


}
