import { Component } from '@angular/core';
import { NavController, NavParams, ViewController, LoadingController, AlertController } from 'ionic-angular';
import { File } from 'ionic-native';
import { ImageUploadProvider } from '../../providers/image-upload/image-upload';

/*
  Generated class for the Audiopopup page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-Audiopopup',
    templateUrl: 'Audiopopup.html'
})
export class AudiopopupPage {
  file: File;
  audiosrc: any;

  constructor(public navCtrl: NavController, public navParams: NavParams, public viewCtrl: ViewController, public imageUploadService: ImageUploadProvider, public loadingCtrl: LoadingController, public alertCtrl: AlertController) { }

    ionViewDidLoad() {
      //  console.log('ionViewDidLoad AudiopopupPage');
    }
 Closemodel()
 {
    this.viewCtrl.dismiss();
  }

  changeListener($event) {
    this.file = $event.target.files[0];
   // console.log(this.file);
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.imageUploadService.Audioupload(this.file).then(success => {
  //    console.log(success);
      // this.hdnImageData = success;
      this.audiosrc = success;
      window.localStorage.setItem('audiosrc', this.audiosrc);
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
   //   console.log(error);

    });

  }

  Saveaudio()
  {
   // console.log("Save Button" + this.audiosrc);
  }
}
