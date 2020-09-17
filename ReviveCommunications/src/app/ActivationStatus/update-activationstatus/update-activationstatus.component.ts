import { Component, OnInit } from '@angular/core';
import { NbSidebarService, NbMenuItem, NbToastrService } from '@nebular/theme';
//import { LeaderOption } from 'src/app/model/leaderoptions';
import { NbDialogService } from '@nebular/theme';
import { ViewMemberDialogComponent } from 'src/app/Person/view-member-dialog/view-member-dialog.component';
import { IMembers } from 'src/app/model/members';
import { ActivationstatusService } from 'src/app/Services/activationstatus.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
import { LoginComponent } from 'src/app/login/login/login.component';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-update-activationstatus',
  templateUrl: './update-activationstatus.component.html',
  styleUrls: ['./update-activationstatus.component.scss']
})
export class UpdateActivationstatusComponent implements OnInit {
  checked = false;
  members: any;
  updateMember;

  Person:any;
  session:any;

  constructor(private toastrService: NbToastrService, 
              private activationService: ActivationstatusService, 
              private dialogService: NbDialogService,
              private formBuilder: FormBuilder,
              private router: Router ,
              private sidebarService: NbSidebarService,
              private loginService : LoginService) 
              {
                this.updateMember = this.formBuilder.group(
                {
                  UpdateActivation: "",
                  PersonID: ""
                }
                );
              }
              
  toggle() {
    this.sidebarService.toggle(true);
    return false;
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



  ngOnInit(): void {
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
  
   this.activationService.getRequests()
   .subscribe
   (
     data => {
       this.members = data;
       console.log(this.members);
     }
   ); 
  }

  open() {
    this.dialogService.open(ViewMemberDialogComponent, {
      context: {

      },
    });
  }  

  showToast(position, status) {

    if (this.checked = true)
    {
      this.toastrService.show(
        status || 'Success',
        `Member activation successfully updated .`,
        { position, status});
    }
    else
    {
      this.toastrService.show(
        status || 'Danger',
        `Member not found`,
        { position, status});
    }

    
  }

  showErrorToast(position, status) {

    this.toastrService.show(
      status || 'Danger',
      `Member not found`,
      { position, status});
  }

  onSubmit(form)
  {
    console.log(form);

    this.activationService.updateActivationStatus(form);

    this.router.navigateByUrl("/UpdateActivationstatus")
  }

}


