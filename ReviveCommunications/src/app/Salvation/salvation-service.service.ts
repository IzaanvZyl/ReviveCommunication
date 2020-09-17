import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalvationServiceService {
  constructor( private http: HttpClient) {}

  addNewSalvation(newSalvation)
  {
    this.http.post('https://localhost:44390/api/Salvation/addSalvationInformation', newSalvation).subscribe(x => {
      console.log(x)
    })
  }

  getSalvation(): Observable<any>{
    return this.http.get('https://localhost:44390/api/FollowUp/getSalvation');
  }

  getSalvationProgress(): Observable<any>{
    return this.http.get('https://localhost:44390/api/FollowUp/getSalvationProgress');
  }


  FollowUpCompleted(SalInfo: any)
  {
    console.log(SalInfo);
    this.http.post('https://localhost:44390/api/FollowUp/CompletedSalvationFollowUp', SalInfo).subscribe(x => {
      console.log(x)
    })
  }

  FollowUpNoAnswer(Salinfo)
  {
    this.http.post('https://localhost:44390/api/FollowUp/SalvationFollowUpNoAnswer', Salinfo).subscribe(x => {
      console.log(x)
    })
  }

  FollowUpCompletedMember(MemberInfo: any)
  {
    console.log(MemberInfo);
    this.http.post('https://localhost:44390/api/FollowUp/UpdateMembersServeFollowUp', MemberInfo).subscribe(x => {
      console.log(x)
    })
  }

  FollowUpNoAnswerMember(MemberInfo)
  {
    this.http.post('https://localhost:44390/api/FollowUp/UpdateMembersServeNoAnswer', MemberInfo).subscribe(x => {
      console.log(x)
    })
  }

  getMembersServe(): Observable<any>{
    return this.http.get('https://localhost:44390/api/FollowUp/getMembersWantingToServe');
  }
}



