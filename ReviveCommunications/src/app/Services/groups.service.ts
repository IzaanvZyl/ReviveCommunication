import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': "application/json",
    'Authorization': "token",
    'Access-Control-Allow-Origin': "*"
  })
}

@Injectable({
  providedIn: 'root'
})
export class GroupsService {

  group;
  selectedGroup: any;

  constructor(private http: HttpClient) { }

  getGroups(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getAllGroups')
  }

  getCity(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getAllCities')
  }

  getCountry(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getAllCountries')
  }

  getProvince(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getAllProvinces')
  }

  getSuburb(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getAllSuburbs')
  }

  addGroup(newGroup)
  {
    this.http.post('https://localhost:44390/api/Groups/addOrgGroup', newGroup, httpOptions).subscribe(c => {
      console.log(c)
    });
  }

  updateGroup(updateGroup)
  {
    this.http.post('https://localhost:44390/api/Groups/updateOrgGroup', updateGroup).subscribe(c => {
      console.log(c)
    });
  }

  getGroupTypes(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getAllGroupTypes')
  }

  getGroupByID(groupSelection: number)
  {
    return this.http.get('https://localhost:44390/api/Groups/getGroupID?OrgGroupID=' + groupSelection).subscribe(x =>
    {
      console.log(x)
    })
  }

  transferGroups(transfer)
  {
    this.http.post('https://localhost:44390/api/Groups/TransferGroups', transfer).subscribe(g => {
      console.log(g)
    })
  }

  getPersonGroups(): Observable<any>
  {
    return this.http.get('https://localhost:44390/api/Groups/getGroupByPerson')
  }

  setData(orggroup)
  {
  console.log(orggroup);
  this.selectedGroup = orggroup;
  }

  getData()
  {
  console.log(this.selectedGroup);
   return this.selectedGroup;
  }

}
