import { Component } from '@angular/core';
import { NavController, NavParams, ModalController, AlertController, LoadingController } from 'ionic-angular';
import { BooksProvider } from '../../providers/book/book';
import { NotebookProvider } from '../../providers/Notebook/Notebook';
import { ImagepopupPage } from '../Imagepopup/Imagepopup';
import { AudiopopupPage } from '../Audiopopup/Audiopopup';
import { VideopopupPage } from '../Videopopup/Videopopup';
import { SavepagedataPage } from '../modals/Savepagedata/Savepagedata';
import { HelpPage } from '../modals/Help/Help';
import { FriendsProvider } from '../../providers/Friends/Friends';
import { File } from 'ionic-native';
import { GlobalProvider } from '../../providers/globalvariable/GlobalUserId';
import { config } from '../../app/config';

/*
  Generated class for the add_notebook_page page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
  selector: 'page-add_notebook',
  templateUrl: 'add-notebook.html'
})
export class AddNotebookPage {

  Pid: any;
  pageType: any;
  data: any;
  id = 0;
  pageno: any;
  subjectname: any;
  hdnImageData: any;
  file: File;
  imgsrc: any;
  pageid: any;
  PageImage: any;
  imagesrc: any;
  audiosrc: any;
  videosrc: any;
  PageNumber: any;
  img: any;
  url = config.apiUrl;
  Loggedinuserid: any;


  constructor(public navCtrl: NavController, public globalvariable: GlobalProvider, public FriendsServices: FriendsProvider, public navParams: NavParams, public BooksServiceProvider: BooksProvider, public NotebookServicesProvider: NotebookProvider, public modalCtrl: ModalController, public alertCtrl: AlertController, public loadingCtrl: LoadingController) {
    this.id = navParams.get('id');
    if (navParams.get('pageid') == undefined || navParams.get('pageid') == "" || navParams.get('pageid') == null) {
      this.pageid = 0;
    }
    else {
      this.pageid = navParams.get('pageid');
      // alert("Pageid" + this.pageid);
    }
    this.imagesrc = localStorage.getItem('Player_Image');
    this.pageType = 'Text';
    this.GetPageContent_ByPageId();
    

    this.Loggedinuserid = globalvariable.LoggedInUserId;
  }

  ionViewDidLoad() {
  //  console.log('ionViewDidLoad add_notebookPage');
   
  }

  setPageType() {

  }

  abc() {
    var ht = ((document.getElementById("childEditor") as HTMLDivElement).innerHTML);
    var num1 = ((document.getElementById("screendata") as HTMLInputElement).value);
  //  console.log(num1);
  //  console.log(ht);
  }

  GetPageContent_ByPageId()
  {
    this.BooksServiceProvider.GetPageContent_ByPageId(parseInt(this.pageid)).then(success => {
      if (success.IsSuccess == true) {
        if (success.ResponseData.length > 0) {
          this.data = JSON.parse(success.ResponseData);
          this.Pid = this.data[0].Id;
          this.PageNumber = this.data[0].PageNumber;
          if (this.data[0].PageType == 'Text') {
            this.pageType = 'Text';
            var d = this.data[0].PageImage;
            (document.getElementById("editorDiv1") as HTMLElement).innerHTML = d;
           // document.getElementById("editorDiv").innerHTML = d;
          }
          else if (this.data[0].PageType == 'Audio') {
            this.pageType = 'Audio';
            this.audiosrc = this.data[0].PageImage;
          }
          else if (this.data[0].PageType == 'Image') {
            this.pageType = 'Image';
            this.imagesrc = this.data[0].PageImage;
          }
          else if (this.pageType == 'Video') {
            this.pageType = 'Video';
            this.videosrc = this.data[0].PageImage;
          }
        }
      }
      else
      {
        this.Pid = 0;
      }
      this.Notesbook_Pages(this.id);
    });
  }

  Notesbook_Pages(id) {
    this.BooksServiceProvider.Notesbook_Pages(id).then(success => {     
        if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
          if (parseInt(this.Pid) == 0)
          {
            this.pageno = this.data[0].LastPage + 1;
          }
          else
          {
            this.pageno = this.PageNumber;
          }    
          this.subjectname = this.data[0].SubjectName;
        }
     
    });
  }

  pageimageupload(imageData, filename) {
    this.NotebookServicesProvider.pageimageupload(imageData, filename).then(success => {
      if (success.ResponseData.length > 0) {
        this.data = JSON.parse(success.ResponseData);
      }
    });
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

  change() {
    if (this.pageType == "Text") {
      var htmlcontent = "";
      var screenshot = "";
      var src = "";
      screenshot = ((document.getElementById("screendata") as HTMLInputElement).value);
      var base64ImageContent = screenshot.replace(/^data:image\/(png|jpg);base64,/, "");
      var blob = this.base64ToBlob(base64ImageContent, 'image/png');
      var filename = "Page_ScreenShot.png";
      this.BooksServiceProvider.uploadpic(blob, filename, this.pageType).then(success => {
       // console.log(success);
        this.Addpage(success);
      }, (error) => {
        let alert = this.alertCtrl.create({
          title: '"Error in upload screenshot."',
          buttons: ['OK']
        });
        alert.present();
    //    console.log(error);
      });
    }
    else if (this.pageType == "Video") {
      let video = window.localStorage.getItem("videoscreensrc");
      this.Addpage(video);
    }
    else { this.Addpage("") }
  }


  Addpage(screenshot) {
    var htmlcontent = "";
    var datahtml = "";
    var chapter = "";
    var src = "";
    if (this.pageType == "Text") {
      datahtml = ((document.getElementById("capture") as HTMLDivElement).innerHTML);
      htmlcontent = "<div>" + chapter + "</div><div class='childEditor' style='height:100%'>" + datahtml + "</div>";
    }
    else if (this.pageType == "Audio") {
      src = window.localStorage.getItem("audiosrc");
    }
    else if (this.pageType == "Image") {
       src = window.localStorage.getItem("imagesrc");
    }
    else if (this.pageType == "Video") {
      src = window.localStorage.getItem("submitvideosrc");
    }

    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    var student = {
      Id: this.Pid,
      NotebookId: this.id,
      PageNumber: this.pageno,
      Content: htmlcontent,
    }
    this.NotebookServicesProvider.AddNotebookpages(student, screenshot, this.pageType, src).then(success => {
      if (success.IsSuccess == true)
      {
      this.hdnImageData = success;
      loading.dismiss();
      window.localStorage.setItem('imagesrc', '');
      window.localStorage.setItem('submitvideosrc', '');
        window.localStorage.setItem('audiosrc', '');
        //this.FriendsServices.FriendsList(this.Loggedinuserid).then(result => {

        //});

        let alert = this.alertCtrl.create({
          title: '"Page Added successfully"',
          buttons: ['OK']
      
      });
        alert.present();
      }
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: '"Error in Adding."',
        buttons: ['OK']
      });
      alert.present();
    //  console.log(error);
    });

  }

  Savetextdata() {
    this.navCtrl.push(SavepagedataPage);
  }

  openImgPopup() {
    let myModal = this.modalCtrl.create(ImagepopupPage);
    myModal.present();
  }

  openaudioPopup() {
    let myModal = this.modalCtrl.create(AudiopopupPage);
    myModal.present();
  }

  openVideoPopup() {
    let myModal = this.modalCtrl.create(VideopopupPage);
    myModal.present();
  }

  help()
  {
    this.navCtrl.push(HelpPage);
  }

}



