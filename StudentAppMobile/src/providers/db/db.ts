import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { SQLite } from 'ionic-native'

@Injectable()
export class db {

  private storage: SQLite;
  private isOpen: boolean = false;

  constructor() {
   // alert('Hello db Provider');
    if (!this.isOpen) {
   //   alert("open")
        this.storage = new SQLite();
      this.storage.openDatabase({ name: "Notetor31Oct2018.db", location: "default" }).then((successdb) => {
      //  alert("db create " + JSON.stringify(successdb));
        this.storage.executeSql("CREATE TABLE IF NOT EXISTS Login_User_Details (id INTEGER PRIMARY KEY,UserId INTEGER, Firstname TEXT,Lastname TEXT,Profilepic TEXT, Coverpic TEXT,CoutryId INTEGER,StateId INTEGER,CityId INTEGER,Email TEXT,Password TEXT)", []).then((successtable) => {
         // alert("table create " + JSON.stringify(successtable));
          }, (errortable) => { /*alert("table create error " + JSON.stringify(errortable)) */});
          this.isOpen = true;
        }, (errordb) => {/* alert("db create error " + JSON.stringify(errordb))*/ });
      }
    }

  public Getpreinserteddata() {
  //   alert("run App Mode");
    return new Promise((resolve, reject) => {
      this.storage.executeSql("SELECT * FROM Login_User_Details", []).then((data) => {
        //     alert("run app data"+JSON.stringify(data));
        let NewData = [];
        if (data.rows.length > 0) {
          for (let i = 0; i < data.rows.length; i++) {
            NewData.push({
              id: data.rows.item(i).id,
              UserId: data.rows.item(i).UserId,
              Firstname: data.rows.item(i).Firstname,
              Lastname: data.rows.item(i).Lastname,
              Profilepic: data.rows.item(i).Profilepic,
              Coverpic: data.rows.item(i).Coverpic,
              CoutryId: data.rows.item(i).CoutryId,
              StateId: data.rows.item(i).StateId,
              CityId: data.rows.item(i).CityId,
              Email: data.rows.item(i).Email,
              Password: data.rows.item(i).Password
            });
          }
        }
        //  alert("Get :"+JSON.stringify(NewData));
        resolve(NewData);
      }, (error) => {
        //alert("Error code No data" + JSON.stringify(error));
        reject(error);
      });
    });
  }

  public LoginUserDetail(UserId, Firstname, Lastname, Profilepic, Coverpic, CoutryId, StateId, CityId, Email, Password ) {
    return new Promise((resolve, reject) => {
      this.storage.executeSql("DELETE FROM Login_User_Details", []).then((data) => {
        var query = "INSERT INTO Login_User_Details (id, UserId, Firstname, Lastname, Profilepic, Coverpic,CoutryId ,StateId ,CityId ,Email ,Password ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        this.storage.executeSql(query, [1, UserId, Firstname, Lastname, Profilepic, Coverpic, CoutryId, StateId, CityId, Email, Password]).then(succ => {
          //alert("DB details inserted");
        }, error1 => { /*alert(JSON.stringify(error1))*/ });
        resolve(data);
      }, (error) => {
        reject(error);
      });
    });
  }
  public LogoutUser() {
    return new Promise((resove, reject) => {
      this.storage.executeSql("DELETE FROM Login_User_Details", []).then((deleteddata) => {

      }, error => { reject(error)});
    })
  }



 
}
