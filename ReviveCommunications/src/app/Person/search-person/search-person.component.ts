import { Component, OnInit, VERSION } from '@angular/core';
import { NbMenuItem, NbSidebarService } from '@nebular/theme';
//import { Ng2SmartTableModule, LocalDataSource } from 'ng2-smart-table';
import {Router} from '@angular/router';
import { Person } from 'src/app/model/person';
import { MembersService } from 'src/app/Services/members.service';
import { Observable, of } from 'rxjs';
import { ReactiveFormsModule } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { map, withLatestFrom, startWith, tap } from 'rxjs/operators';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-search-person',
  templateUrl: './search-person.component.html',
  styleUrls: ['./search-person.component.scss']
})

export class SearchPersonComponent implements OnInit {
//source: LocalDataSource;
person: any;
dataSaved = false;  
personForm: any;  
 allPerson: any[];  
  customerIdUpdate = null;  
  massage = null; 
filterPerson : any;
filteredItems: any[];
formGroup; 
Name;


 constructor(private sidebarService: NbSidebarService,
  private loginService:LoginService, private router : Router, private personService: MembersService, private formbuilder: FormBuilder) 
 {


    }


  
  Logout()
  {
    localStorage.removeItem("accessToken");
    this.router.navigate([""]);
  }
 
  items: NbMenuItem[] = [

    {
      title: 'Profile',
      icon: 'person-outline',
      children: [
        {
          title: 'Update Profile',
          icon: 'edit-outline',
           link: '/UpdatePerson'
        },
        {
          title: 'Financial Contribution',
          icon: 'credit-card-outline',
           link: '/FinancialContribution'
        },
      

      ],
    },
    {
      title: 'Manage Members',
      icon: 'people-outline',
      children: [
        {
          title: 'View Members',
          icon: 'eye-outline',
           link: '/Members'
        },
        {
          title: 'Activate Members',
          icon: 'person-done-outline',
           link: '/RequestReactivate'
        },
        {
          title: 'Deactivate Members',
          icon: 'person-remove-outline',
           link: '/RequestDeActivate'
        },
        {
          title: 'Transfer Groups',
          icon: 'swap-outline',
           link: '/GroupTransfer'
        },

      ],

    },
    {
      title: 'Message Members',
      icon: 'email-outline',
      children: [
        {
          title: 'Send Invitation',
          icon: 'arrow-right-outline',
           link: '/SendInvitation'

        },
        {
          title: 'Send Announcement',
          icon: 'arrow-right-outline',
           link: '/PostAnnouncement'
        },
        {
          title: 'Remove Announcement',
          icon: 'arrow-right-outline',
           link: '/RemoveAnnouncement'
        },
      ],

    },
     {
      title: 'Groups',
      icon: 'plus-circle-outline',
       link: '/Groups'
    },
     {
      title: 'Homecell notes',
      icon: 'file-add-outline',
       link: '/HomecellNotes'
    },
     {
      title: 'Kids Church',
      icon: 'home-outline',
       link: '/KidsChurch'

    },

    {
      title: 'Follow-up',
      icon: 'phone-outline',
      children: [
        {
          title: 'Salvation',
          icon: 'arrow-right-outline',
           link: '/FollowUpSalvation'

        },
        {
          title: 'Requests to Serve',
          icon: 'arrow-right-outline',
           link: '/FollowUpMembersWantingToServe'
        },
        {
          title: 'NMO',
          icon: 'arrow-right-outline',
           link: '/NMOFollowUp'
        },
        {
          title: 'Overseers',
          icon: 'arrow-right-outline',
           link: '#'
        },
        {
          title: 'Leaders',
          icon: 'arrow-right-outline',
           link: '/LeaderFollowUp'
        },
        {
          title: 'Members',
          icon: 'arrow-right-outline',
           link: '/MemberFollowUp'
        },
        {
          title: 'Discipleship',
          icon: 'arrow-right-outline',
           link: '/FollowUpDiscipleship'
        },
      ],

    },
    {
      title: 'Set Goals',
      icon: 'award-outline',
       link: '/SearchWeeklyGoal'

    },
    {
      title: 'Feedback',
      icon: 'bar-chart',
      children: [
        {
          title: 'Homecell Attendance',
          icon: 'arrow-right-outline',
           link: '/ReportOnHCAtt'

        },
        {
          title: 'Church Attendance',
          icon: 'arrow-right-outline',
           link: '/ReportOnChurchAtt'
        },
        {
          title: 'Structure Growth',
          icon: 'arrow-right-outline',
           link: '/ReportStructureGowth'
        },
        {
          title: 'New Member Orientation',
          icon: 'arrow-right-outline',
           link: '/NMOReport'
        },
        {
          title: 'Zone Growth',
          icon: 'arrow-right-outline',
           link: '/ZoneGrowth'
        },
        {
          title: 'Zone HC Attendance',
          icon: 'arrow-right-outline',
           link: '/ZoneHomecellAttendance'
        },
        {
          title: 'Zone Church Attendance',
          icon: 'arrow-right-outline',
           link: '/ZoneChurchAttendance'
        },

      ],

    },
    {
      title: 'Reports',
      icon: 'trending-up-outline',
      children: [
        {
          title: 'Zone Growth',
          icon: 'arrow-right-outline',
           link: '/ZoneGrowthReport'

        },
        {
          title: 'Overview Of Structure',
          icon: 'arrow-right-outline',
           link: '/OverviewStructureReport'
        },
        {
          title: 'Discipleship Progress',
          icon: 'arrow-right-outline',
           link: '/StructureDiscipleshipReport'
        },
      ],

    },
    {
      title: 'Admin',
      icon: 'settings-2-outline',
      children: [
        {
          title: 'Group Types',
          icon: 'arrow-right-outline',
          link: '#',
          children: [
            {
              title: 'Add Group Type',
              icon: 'arrow-right-outline',
              link: '/AddGroupType',
            },
            {
              title: 'Update Group Type',
              icon: 'arrow-right-outline',
              link: '/UpdateGroupType',
            }
          ],
        },
        {
          title: 'Discipleships',
          icon: 'arrow-right-outline',
           link: '/SearchDiscipleship'
        },
        {
          title: 'Structure Positions',
          icon: 'arrow-right-outline',
           link: '/ViewOrganisationalStructurePosition'
        },
        {
          title: 'Individual Positions',
          icon: 'arrow-right-outline',
           link: '/ViewOrgIndivPos'
        },
      ],

    },
    {
      title: 'Counselling',
      icon: 'smiling-face-outline',
      children: [
        {
          title: 'Request Counselling',
          icon: 'arrow-right-outline',
           link: '/AddCounselling'

        },
        {
          title: 'View Counselling Requests',
          icon: 'arrow-right-outline',
           link: '/ViewCounselling'
        },
   
      ],

    },
  ];
    assignCopy(){
      this.filteredItems = Object.assign([], this.allPerson);
   }
   filterItem(value){
      if(!value){
          this.assignCopy();
      } // when nothing has typed
      this.filteredItems = Object.assign([], this.allPerson).filter(
         item => item.name.toLowerCase().indexOf(value.toLowerCase()) > -1
      )
   }

 ToUpdatePerson(){

   this.router.navigate(['/update-person']);
}

setData(updatePers)
  {
    this.personService.setData(updatePers);
  }

/*
loadAllPersons(): void {
 this.personService.getAllPerson()
   .subscribe(
     data => {
       this.person = data;
       console.log(data);
     },
     error => {
       console.log(error);
     });
}*/

   onFormSubmit() {  
     this.dataSaved = false;  
     const customer = this.personForm.value;  
     //this.CreateCustomer(customer);  
    // this.customerForm.reset();  
   }  



 
Person:any;
  session:any;
ngOnInit()
{
  

if(!localStorage.getItem("accessToken")){
    this.router.navigate(['']);
  }
  else{
    this.session ={"SessionID": localStorage.getItem("accessToken")}
    this.loginService.getUserDetails(this.session).subscribe(res =>{
      this.Person = res;
      console.log(this.Person)
    })
  }
  this.personService.getAllPerson().subscribe
    (
      data => 
      {
        this.allPerson = data;
        this.assignCopy();//when you fetch collection from server.

        console.log(data)
      }
    )
}
toggle() {
  this.sidebarService.toggle(true);
  return false;
}

searchPerson()
{
  
}


 // second parameter specifying whether to perform 'AND' or 'OR' search
 // (meaning all columns should contain search query or at least one)
 // 'AND' by default, so changing to 'OR' by setting false here

}
