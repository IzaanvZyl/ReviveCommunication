import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReportingService {

  private SERVER_URL = 'https://localhost:44390';
  constructor( private Http: HttpClient,
    ) { }


  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }
  getHomecellAttendance(){

    //return this.Http.get<any[]>('https://localhost:44362/api/Report/GetReportData?CategoryID='+CategoryID)
    return this.Http.get<any[]>(this.SERVER_URL +'/api/GenerateReport/getHomecellAttendance', this.httpOptions)
    .pipe(map(result => result));

  }
  getChurchAttendance(){

    //return this.Http.get<any[]>('https://localhost:44362/api/Report/GetReportData?CategoryID='+CategoryID)
    return this.Http.get<any[]>(this.SERVER_URL +'/api/GenerateReport/getChurchAttendance', this.httpOptions)
    .pipe(map(result => result));

  }

  getOverview(){

    //return this.Http.get<any[]>('https://localhost:44362/api/Report/GetReportData?CategoryID='+CategoryID)
    return this.Http.get<any[]>(this.SERVER_URL +'/api/GenerateReport/getOverview', this.httpOptions)
    .pipe(map(result => result));

  }
  getDiscData(){

    //return this.Http.get<any[]>('https://localhost:44362/api/Report/GetReportData?CategoryID='+CategoryID)
    return this.Http.get<any[]>(this.SERVER_URL +'/api/GenerateReport/getDiscipleshipReport', this.httpOptions)
    .pipe(map(result => result));

  }
  getZoneGrowth(){

    //return this.Http.get<any[]>('https://localhost:44362/api/Report/GetReportData?CategoryID='+CategoryID)
    return this.Http.get<any[]>(this.SERVER_URL +'/api/GenerateReport/getZoneGrowth', this.httpOptions)
    .pipe(map(result => result));

  }
}
