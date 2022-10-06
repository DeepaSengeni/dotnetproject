import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController, ToastController, Content } from 'ionic-angular';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

import { NotebookProvider } from '../../providers/Notebook/Notebook';
import { LocationInfoProvider } from '../../providers/location-info/location-info';
import { Home } from '../home/home';



/*
  Generated class for the NotebookForm page.

  See http://ionicframework.com/docs/v2/components/#navigation for more info on
  Ionic pages and navigation.
*/
@Component({
    selector: 'page-NotebookForm',
    templateUrl: 'NotebookForm.html'
})
export class NotebookFormPage {

  notebookForm: FormGroup;
  SubjectList: any;
  bookid: any;
  editdetails: any;
  Change: any;
  content: any;

  constructor(public navCtrl: NavController, public formBuilder: FormBuilder, public loadingCtrl: LoadingController, public Notebookservices: NotebookProvider, public navParams: NavParams, public alertCtrl: AlertController, public locationInfoService: LocationInfoProvider, public toastctrl: ToastController) {
    this.bookid = navParams.get('bookid');
    if (this.bookid != undefined)
    {
      this.GetDetails();
   
    }
    this.content = "Create Notebook";
    this.Change = false;
    this.notebookForm = formBuilder.group({
      date: ['', Validators.compose([Validators.required])],
      monetary: [''],
      inType: ['0'],
      visibleToAll: [''],
      SubjectID: [''],
      headline: [''],
    });
    this.GetSubjectList();
  
  }

  AddSubject()
  {
    this.Change = true;
   
  }
  Cancel()
  {
    this.Change = false;
       
  }

  notebookSave(value: any,Id): void
  {
    if (Id == "" || Id == undefined) {
      if (this.notebookForm.valid) {
        let loading = this.loadingCtrl.create({
          content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
        });
        //loading.present();      
        var notebookdteails = {
          NewSubject: value.headline,
          SubjectName: value.SubjectID,
          StartDate: value.date,
          Visible_Hidden: value.visibleToAll,
          MonetoryAdvantages: value.monetary,
          Innovation_Investment: value.inType,
          UserId: window.localStorage.getItem('Userid'),
        };
        var jsonnotebookData = JSON.stringify(notebookdteails);
        //loading.present();
        this.Notebookservices.Notebookadd(jsonnotebookData).then(success => {
          loading.dismiss();
          if (success.IsSuccess === true) {
            let toast = this.toastctrl.create({
              message: 'Book added successfully',
              duration: 3000,
              position: 'bottom'
            });
            toast.present();
            this.navCtrl.setRoot(Home);
          }
          else {
            let alert = this.alertCtrl.create({
              title: '"Failed to add New Book"',
              buttons: ['OK']
            });
          }
          console.log(success);
        },
          (error) => {
            loading.dismiss();
            let alert = this.alertCtrl.create({
              title: 'Failed',
              //subTitle: error,
              buttons: ['OK']
            });
            alert.present();
            console.log(error);// Error getting the data   
          });
      }
    }
    else
    {
      this.UpdateBook(value, Id);
    }
  }

  GetSubjectList() {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.locationInfoService.GetallSubjectlist().then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.SubjectList = JSON.parse(success.ResponseData);
      }
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
  }

  GetDetails()
  {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    let UserId = window.localStorage.getItem('Userid');
    this.Notebookservices.NotebookLoad_ByNotebookId(parseInt(this.bookid), parseInt(UserId)).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.editdetails = JSON.parse(success.ResponseData);
        console.log(this.editdetails);
        this.notebookForm.setValue({
          date: this.editdetails[0].StartDate,
          monetary: this.editdetails[0].MonetoryAdvantages ,
          inType: this.editdetails[0].Innovation_Investment ,
          visibleToAll: this.editdetails[0].Visible_Hidden,
          SubjectID: this.editdetails[0].SubjectId,
          headline:""
         
        });

      }
      this.content = "Update NoteBook";
    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
    });
  }

  UpdateBook(value, Id)
  {
    //  var headvalue = "";
    if (this.Change == true) {
      value.SubjectID = "";
    }
    else
    {
      value.headline="";
    }

    if (this.notebookForm.valid) {
      let loading = this.loadingCtrl.create({
        content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
      });
      //loading.present();      
      var notebookdteails = {
        NewSubject: value.headline,
        SubjectName: value.SubjectID,
        StartDate: value.date,
        Visible_Hidden: value.visibleToAll,
        MonetoryAdvantages: value.monetary,
        Innovation_Investment: value.inType,
        BookId: this.bookid,
        UserId: window.localStorage.getItem('Userid'),
      };
      var jsonnotebookData = JSON.stringify(notebookdteails);
      //loading.present();
      this.Notebookservices.NotebookUpdate(jsonnotebookData).then(success => {
        loading.dismiss();
        if (success.IsSuccess === true) {
          let toast = this.toastctrl.create({
            message: 'Book Updated successfully',
            duration: 3000,
            position: 'bottom'
          });
          toast.present();
          this.navCtrl.setRoot(Home);
        }
        else {
          let alert = this.alertCtrl.create({
            title: '"Failed to add New Book"',
            buttons: ['OK']
          });
        }
        console.log(success);
      },
        (error) => {
          loading.dismiss();
          let alert = this.alertCtrl.create({
            title: 'Failed',
            //subTitle: error,
            buttons: ['OK']
          });
          alert.present();
          console.log(error);// Error getting the data   
        });
    }
  }
  
}
