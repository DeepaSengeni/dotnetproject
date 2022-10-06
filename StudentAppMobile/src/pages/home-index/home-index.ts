import { Component } from '@angular/core';
import { NavController, NavParams, LoadingController, AlertController } from 'ionic-angular';
import { SendMessagePage } from '../../pages/modals/SendMessage/SendMessage';
import { FriendsPage } from '../Friends/Friends';
import { config } from '../../app/config';
import { BooksProvider } from '../../providers/book/book';
import { QuestionProvider } from '../../providers/question/question';
import { AnswerProvider } from '../../providers/answer/answer';
import { AddNotebookPage } from '../add-notebook/add-notebook';
import { LayoutPage } from '../layout/layout';
import { AdvertisementProvider } from '../../providers/Advertisement/Advertisement';
import { TabForProfileFriendPage } from '../TabForProfileFriend/TabForProfileFriend';


declare var MathEditor: any;

@Component({
    selector: 'page-home_index',
    templateUrl: 'home-index.html'
})
export class HomeIndexPage {

  userID: any;
  pageID: any;
  BookID: any;
  questionData: any;
  QuestionsList: any;
  questionId: any;
  questionStatus: any;
  AnswersList: any;
  replyAnswerId: any;
  ReplyToAnswersList: any;
  likes: any;
  views: any;
  imageData: any;
  pagecontentdata: any;
  pageno: any;
  startdate: any;
  subjectname: any;
  bookownerid: any;
  edit: any;
  Addata: any;
  AdId: any;
  Adimage: any
  Adheading: any;
  Addescription: any;
  AdUrl: any;
  AdMobileno: any;
  url = config.apiUrl;
  viewad: any;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    public alertCtrl: AlertController,
    public questionService: QuestionProvider,
    public answerService: AnswerProvider,
    public BooksService: BooksProvider,
    public AdService: AdvertisementProvider,


  ) {
    var t = document.getElementById('demo');
    this.BookID = navParams.get('Bookid');
    this.pageID = navParams.get('pageId');
    //this.BookID = "220108";
    //this.pageID = "240374";
    this.userID  = window.localStorage.getItem('Userid');
    this.questionData = "";
    this.questionId = 0;
    this.questionStatus = 0;
    this.replyAnswerId = 0;
    this.likes = 0;
    this.views = 0;
    this.edit = false;
    this.viewad = true;
    this.insertView('view');
  }

  ionViewDidLoad() {
    localStorage.setItem("userId", this.userID);
    localStorage.setItem("pageId", this.pageID);
    this.GetQuestionsByPageId(this.pageID);
    this.GetAnswersByPageId(this.pageID);
    this.GetReplyToAnswersByPageId(this.pageID);
  
  }
  ionViewDidEnter() {
    var myEditor = new MathEditor('demo');
    myEditor.buttons = ["fraction", "square_root", "cube_root", "root", 'superscript', 'subscript', 'multiplication', 'division', 'plus_minus', 'pi', 'degree', 'not_equal', 'greater_equal', 'less_equal', 'greater_than', 'less_than', 'angle', 'parallel_to', 'perpendicular', 'triangle', 'parallelogram'];["fraction", "square_root", "cube_root", "root", 'superscript', 'subscript', 'multiplication', 'division', 'plus_minus', 'pi', 'degree', 'not_equal', 'greater_equal', 'less_equal', 'greater_than', 'less_than', 'angle', 'parallel_to', 'perpendicular', 'triangle', 'parallelogram'];
    myEditor.setTemplate('floating-toolbar');
  }

  insertView(action) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();  
    this.BooksService.insertpageclick(this.pageID, this.userID, action).then(success => {
      loading.dismiss();
      console.log(success.ResponseData);
      if (success.ResponseData.length > 0) {
        var data = JSON.parse(success.ResponseData);
        this.views = data[0].views;
        this.likes = data[0].likes;
      }
      else {
      }
      console.log(success);
      this.pagecontent();
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        buttons: ['OK']
      });
      alert.present();
      console.log(error);
    });
  }

  pagecontent()
  {
    this.BooksService.PageContentByPageId(this.pageID).then(success => {
 //     console.log(success);
      if (success.IsSuccess == true) {
        this.pagecontentdata = JSON.parse(success.ResponseData);
        this.pageno = this.pagecontentdata[0].PageNumber;
        var date = this.pagecontentdata[0].StartDate.split('T');
        this.startdate = date[0];
        this.subjectname = this.pagecontentdata[0].SubjectName;
        this.bookownerid = this.pagecontentdata[0].UserId;
        if (this.userID == this.bookownerid) {
          this.edit = true;
        }
      }
      else
      {
        let alert = this.alertCtrl.create({
          title: 'Not Found',
          message: 'Sorry page not found',
          buttons: [
            {
              text: 'Ok',
              role: 'cancel',
              handler: () => {
                this.navCtrl.pop();
             //   console.log('Cancel clicked');
              }
            }
          ]
        });
        alert.present();
      }
    });
  }

  GetQuestionsByPageId(e) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.questionService.GetQuestionsByPageId(e).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.QuestionsList = JSON.parse(success.ResponseData);
     ///   console.log(this.QuestionsList);
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

  GetAnswersByPageId(e) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.questionService.GetAnswersByPageId(e).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.AnswersList = JSON.parse(success.ResponseData);
       // console.log(this.QuestionsList);
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
             
  GetReplyToAnswersByPageId(e) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.questionService.GetReplyToAnswersByPageId(e).then(success => {
      loading.dismiss();
      if (success.ResponseData.length > 0) {
        this.ReplyToAnswersList = JSON.parse(success.ResponseData);
     //   console.log(this.QuestionsList);
      }

    }, (error) => {
      let alert = this.alertCtrl.create({
        title: 'Service Error',
        subTitle: error,
        buttons: ['Continue']
      });
      alert.present();
      });
    this.AdLoadOnpage();
  }

  filterAnswersOfQuestions(id) {
    if (this.AnswersList != null && this.AnswersList != undefined && this.AnswersList.length > 0) {
      return this.AnswersList.filter(x => x.QuestionId == id);
    }
    else {
      return null;
    }
  }

  filterReplyToAnswersOfQuestions(id) {
    if (this.ReplyToAnswersList != null && this.ReplyToAnswersList != undefined && this.ReplyToAnswersList.length > 0) {
      return this.ReplyToAnswersList.filter(x => x.QuestionId == id);
    }
    else {
      return null;
    }
  }

  Reply(id) {
    this.questionStatus = 1;
    this.questionId = id;
    var div = (document.getElementById("editor") as HTMLDivElement);
    div.focus();
  }

  ReplyToAnswer(id, replyAnswerId) {
    this.questionStatus = 2;
    this.questionId = id;
    this.replyAnswerId = replyAnswerId;
    var div = (document.getElementById("editor") as HTMLDivElement);
    div.focus();
  }

  SubmitData() {
  
    if (this.questionStatus == 1) {      
      this.questionStatus == 0;
      this.SaveReply(this.questionId)
    }
    else if (this.questionStatus == 2) {
      this.questionStatus == 0;
      this.SaveReplyToAnswer(this.questionId, this.replyAnswerId)
    }
    else {    
      this.SaveQuestion();
    }
  
  }

  SaveQuestion() {

    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();

    var htmlData = ((document.getElementById("editor") as HTMLDivElement).innerHTML);

    this.questionService.SaveQuestion(this.userID, this.pageID, htmlData).then(success => {
      loading.dismiss();
      if (success.IsSuccess === true) {
        this.questionData = '';
        (document.getElementById("editor") as HTMLDivElement).innerHTML = '';
        this.GetQuestionsByPageId(this.pageID);
        this.GetAnswersByPageId(this.pageID);
      }
      else {
      }
    //  console.log(success);            
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
     // console.log(error);
    });

  }

  SaveReply(id) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    var htmlData = ((document.getElementById("editor") as HTMLDivElement).innerHTML);
    this.answerService.SaveReply(this.userID, htmlData, id, 0).then(success => {
      loading.dismiss();
      if (success.IsSuccess === true) {
        this.questionData = '';
        (document.getElementById("editor") as HTMLDivElement).innerHTML = '';
        this.GetQuestionsByPageId(this.pageID);
        this.GetAnswersByPageId(this.pageID);
      }
      else {
      }
     // console.log(success);
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
    //  console.log(error);
    });
  }

  SaveReplyToAnswer(id, replyAnswerId) {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    var htmlData = ((document.getElementById("editor") as HTMLDivElement).innerHTML);
    this.answerService.SaveReply(this.userID, htmlData, id, replyAnswerId).then(success => {
      loading.dismiss();
      if (success.IsSuccess === true) {
        this.questionData = '';
        (document.getElementById("editor") as HTMLDivElement).innerHTML = '';
        this.GetQuestionsByPageId(this.pageID);
        this.GetAnswersByPageId(this.pageID);
      }
      else {

      }
  //    console.log(success);
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
   //   console.log(error);
    });
  }

  insertLike()
  {
    let loading = this.loadingCtrl.create({
      content: '<div class="custom-spinner-container"><div class="custom-spinner-box"></div>Loading...</div>'
    });
    //loading.present();
    this.BooksService.insertpageclick(this.pageID, this.userID,'like').then(success => {
      loading.dismiss();
   //   console.log(success.ResponseData);
      if (success.ResponseData.length > 0) {
        var data = JSON.parse(success.ResponseData);
        this.likes = data[0].likes;
      }
      else {

      }
 //     console.log(success);
    }, (error) => {
      loading.dismiss();
      let alert = this.alertCtrl.create({
        title: 'Error',
        //subTitle: error,
        buttons: ['OK']
      });
      alert.present();
    //  console.log(error);
    });
  }

  Sendmessage()
  {
    this.navCtrl.push(SendMessagePage, { pageId: this.pageID, Bookid: this.BookID });
  }

  Editpage()
  {
    this.navCtrl.push(AddNotebookPage, { id:this.BookID, pageid:this.pageID });
  }

  SendInvitation()
  {
    this.navCtrl.push(FriendsPage,{ PageId: this.pageID })
  }

  AdLoadOnpage() {
    this.AdService.LoadAd(this.userID).then(success => {
      if (success.IsSuccess == true)
      {
        this.viewad = false;
        this.Addata = JSON.parse(success.ResponseData);
        this.Adimage = this.Addata[0].FileUploaded;
        this.AdMobileno = this.Addata[0].MobileNumber;
        this.Adheading = this.Addata[0].Headline;
        this.Addescription = this.Addata[0].Description;
        this.AdUrl = this.Addata[0].UrlAddress;
        this.AdId = this.Addata[0].adcreationId;
      }

    },
      (error) => {
        let alert = this.alertCtrl.create({
          title: 'Error',
          buttons: ['OK']
        });
        alert.present();
    //    console.log(error);
      });

  }

  clickonads()
  {
    this.AdService.clickonAd(this.AdId, this.userID, this.BookID).then(success => {
      if (success.IsSuccess == true) {
      //  console.log("Click");
      }
      else
      {
      //  console.log("fail");
      }
    },
      (error) => {
        let alert = this.alertCtrl.create({
          title: 'Error',
          buttons: ['OK']
        });
        alert.present();
     //   console.log(error);
      });
  }

  profile(Id)
  {
    this.navCtrl.push(TabForProfileFriendPage, { id: Id });
  }


}
