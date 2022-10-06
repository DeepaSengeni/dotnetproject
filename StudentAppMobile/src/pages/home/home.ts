import { Component } from '@angular/core';

import { NavController, NavParams, LoadingController, AlertController, ModalController, Searchbar } from 'ionic-angular';

//import { BooksProvider } from '../../providers/book/book';
import { NotebookProvider } from '../../providers/Notebook/Notebook';


import { SampleModalPagePage } from '../SampleModalPage/SampleModalPage';

import { NotebookFormPage } from '../NotebookForm/NotebookForm';
import { NotebookDetailsPage } from '../NotebookDetails/NotebookDetails';
import { Filterandsearch } from '../Filterandsearch/Filterandsearch';
import { NotebookPageDetailsPage } from '../NotebookPageDetails/NotebookPageDetails';

import { config } from '../../app/config';
import { ImagesavepopupPage } from '../Imagesavepopup/Imagesavepopup';


@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class Home {
  data: string[];
  bookLists: any = [];
  page =0;
  dLenght = 0;
  url = config.apiUrl;

  constructor(public navCtrl: NavController, public alertCtrl: AlertController, public loadingCtrl: LoadingController, public booksService: NotebookProvider, public modalCtrl: ModalController) {
    this.getNoteBooks();
    this.navCtrl = navCtrl
   
  }
  
  getNoteBooks() {
    this.booksService.NotesbookLoads(this.page).then(success => {
      this.dLenght = success.ResponseData.length
   //   console.log("success"+success);
      if (success.ResponseData.length > 0) {
        this.page = this.page + 1;
        this.data = JSON.parse(success.ResponseData);
        //console.log(this.data);
        for (let i = 0; i < this.data.length; i++) {
          this.bookLists.push(this.data[i]);
        }
      }
    });
  }

  doInfinite(infiniteScroll) {
   /// console.log('Begin async operation');
    this.booksService.NotesbookLoads(this.page).then(success => {
      this.dLenght = success.ResponseData.length
      if (success.ResponseData.length > 0) {
        this.page = this.page + 1;
        this.data = JSON.parse(success.ResponseData);
      //  console.log("HomePage :" + window.localStorage.getItem('username'));
       // console.log(this.data);
        if (this.data.length > 0) {
          setTimeout(() => {
            for (let i = 0; i < this.data.length; i++)
            {
              this.bookLists.push(this.data[i]);
            }
     //       console.log('Async operation has ended');
            infiniteScroll.complete();
          }, 1000);
        }
        else
        {
          infiniteScroll.complete();
        }
      }
    });
  }

  openModal()
  {
    this.navCtrl.push(Filterandsearch);
  }

  notebookdetail(value: any): void {
    this.navCtrl.push(NotebookPageDetailsPage, { id: value });
  }

  openAddPage() {
    this.navCtrl.push(NotebookFormPage)
  }

  FAQ(event: Event) {
    event.stopPropagation();

    alert('FAQ Coming soon...');
  }

  home(values: any) {
    this.navCtrl.push(NotebookDetailsPage, { id: values });
   
  }

}
