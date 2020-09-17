import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ReportZoneGrowthService {

  readonly rootURL = "https://localhost:44390/api"
  constructor(private http: HttpClient, private router: Router) { }

  AddZoneGrowth(NewZG)
  {
    return this.http.post<any>(this.rootURL+'/Feedback/ReportZoneGrowth', NewZG).subscribe(data=>{
      window.location.reload()
    });
  }
}