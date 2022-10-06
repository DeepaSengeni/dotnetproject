import { NgModule, ErrorHandler } from '@angular/core';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { Transfer } from 'ionic-native';
import { MyApp } from './app.component';

import { SignIn } from '../pages/sign-in/sign-in';
import { Home } from '../pages/home/home';
import { AddBook } from '../pages/add-book/add-book';
import { Account } from '../pages/account/account';
import { SampleModalPagePage } from '../pages/SampleModalPage/SampleModalPage';
import { NotebookFormPage } from '../pages/NotebookForm/NotebookForm';
import { NotebookPageDetailsPage } from '../pages/NotebookPageDetails/NotebookPageDetails';
import { ProfilePage } from '../pages/Profile/Profile';
import { FriendsPage } from '../pages/Friends/Friends';
import { NoteBookListPage } from '../pages/NoteBookList/NoteBookList'
import { TabForProfileFriendPage } from '../pages/TabForProfileFriend/TabForProfileFriend';
import { NotebookDetailsPage } from '../pages/NotebookDetails/NotebookDetails';
import { Filterandsearch } from '../pages/Filterandsearch/Filterandsearch';
import { EditprofileForm } from '../pages/EditprofileForm/EditprofileForm';
import { AdCreateForm } from '../pages/AdCreateForm/AdCreateForm';
import { AddNotebookPage } from '../pages/add-notebook/add-notebook';
import { ImagepopupPage } from '../pages/Imagepopup/Imagepopup';
import { ImagesavepopupPage } from '../pages/Imagesavepopup/Imagesavepopup';
import { AudiopopupPage } from '../pages/Audiopopup/Audiopopup';
import { VideopopupPage } from '../pages/Videopopup/Videopopup';
import { HomeIndexPage } from '../pages/home-index/home-index';
import { LayoutPage } from '../pages/layout/layout';
import { NotificationModalPage } from '../pages/modals/notification-modal/notification-modal';
import { updateprfilepicPage } from '../pages/modals/updateprfilepic/updateprfilepic';
import { updatecoverpicPage } from '../pages/modals/updatecoverpic/updatecoverpic';
import { SendMessagePage } from '../pages/modals/SendMessage/SendMessage';
import { FaqPage } from '../pages/modals/Faq/Faq';
import { FriendrequestNotificationPage} from '../pages/modals/FriendrequestNotification/FriendrequestNotification';
import { DataNotificationPage} from '../pages/modals/DataNotification/DataNotification';
import { LogoutPage } from '../pages/logout/logout';
import { PaymentPage } from '../pages/payment/payment';
import { PaypalPage } from '../pages/paypal/paypal';
import { HelpPage } from '../pages/modals/Help/Help';
import { GlobalProvider } from '../providers/globalvariable/GlobalUserId';
import { PayPalpay } from '../providers/PaypalPayment/PayPal';

import { AuthenticationProvider } from '../providers/authentication/authentication';
import { LocationInfoProvider } from '../providers/location-info/location-info';
import { ImageUploadProvider } from '../providers/image-upload/image-upload';
import { OTPProvider } from '../providers/otp/otp';
import { BooksProvider } from '../providers/book/book';
import { NotebookProvider } from '../providers/Notebook/Notebook';
import { UsersInfoProvider } from '../providers/Users/UsersInfo';
import { db } from '../providers/db/db';
import { FriendsProvider } from '../providers/Friends/Friends';
import { CommonProvider } from '../providers/Common/common';
import { AdvertisementProvider } from '../providers/Advertisement/Advertisement';
import { AccountsettingProvider } from '../providers/AccountSetting/Accountsetting';
import { QuestionProvider } from '../providers/question/question';
import { AnswerProvider } from '../providers/answer/answer';
import { Findfriend } from '../pages/modals/Findfriend/Findfriend';
import { SettingPage } from '../pages/Setting/Setting';








@NgModule({
  declarations: [
    MyApp,
    SignIn,
    Home,
    AddBook,
    Account,
    SampleModalPagePage,
    NotebookFormPage,
    NotebookPageDetailsPage,
    NotebookDetailsPage,
    ProfilePage,
    FriendsPage,
    Filterandsearch,
    NoteBookListPage,
    TabForProfileFriendPage,
    EditprofileForm,
    AdCreateForm,
    AddNotebookPage,
    ImagepopupPage,
    ImagesavepopupPage,
    AudiopopupPage,
    VideopopupPage,
    HomeIndexPage,
    LayoutPage,
    NotificationModalPage,
    updateprfilepicPage, 
    SendMessagePage,
    LogoutPage,
    updatecoverpicPage,
    FaqPage,
    FriendrequestNotificationPage,
    DataNotificationPage,
    PaymentPage,
    PaypalPage,
    HelpPage,
    Findfriend,
    SettingPage
   

  ],
  imports: [

    IonicModule.forRoot(MyApp)

  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    SignIn,
    Home,
    AddBook,
    Account,
    SampleModalPagePage,
    NotebookFormPage,
    NotebookDetailsPage,
    NotebookPageDetailsPage,
    ProfilePage,
    FriendsPage,
    NoteBookListPage,
    Filterandsearch,
    TabForProfileFriendPage,
    EditprofileForm,
    AdCreateForm,
    AddNotebookPage,
    ImagepopupPage,
    ImagesavepopupPage,
    AudiopopupPage,
    VideopopupPage,
    HomeIndexPage,
    LayoutPage,
    NotificationModalPage,
    updateprfilepicPage,
    SendMessagePage,
    LogoutPage,
    updatecoverpicPage,
    FaqPage,
    FriendrequestNotificationPage,
    DataNotificationPage,
    PaymentPage,
    PaypalPage,
    HelpPage,
    Findfriend,
    SettingPage

  ],
  providers: [AuthenticationProvider, GlobalProvider, LocationInfoProvider, ImageUploadProvider, OTPProvider, BooksProvider, NotebookProvider, UsersInfoProvider, db, FriendsProvider, CommonProvider, AdvertisementProvider, AccountsettingProvider, QuestionProvider, AnswerProvider, PayPalpay, { provide: ErrorHandler, useClass: IonicErrorHandler }]
})
export class AppModule { }
