import { Component, OnInit } from '@angular/core';
import { NbSidebarService, NbToastrService, NbDialogService, NbMenuItem } from '@nebular/theme';
import { KidsChurchService } from 'src/app/Services/kids-church.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SignOutChildDialogComponent } from 'src/app/KidsChurch/sign-out-child-dialog/sign-out-child-dialog.component';
import { SignedOutChildDialogComponent } from 'src/app/KidsChurch/signed-out-child-dialog/signed-out-child-dialog.component';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-sign-out-child',
  templateUrl: './sign-out-child.component.html',
  styleUrls: ['./sign-out-child.component.scss']
})
export class SignOutChildComponent implements OnInit {

  ChildInfo: any;
  PersonID : any;
  childForm: any;

  constructor( private sidebarService: NbSidebarService,private formBuilder: FormBuilder,
                private toastrService: NbToastrService, 
                private kidsChurchhService : KidsChurchService, private router: Router,
                private dialogService: NbDialogService,
                private loginService: LoginService) 
                {
                  this.childForm = this.formBuilder.group({

                  ChildID: '',
                  Name: '',
                  Surname:'',
                  KidsChurchName: ''
                }
              )
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
  
    open() {
      this.dialogService.open(SignOutChildDialogComponent, {
        context: {
  
        },
      });
    }

    open2() {
      this.dialogService.open(SignedOutChildDialogComponent, {
        context: {
  
        },
      });
    }

    loading = false;

  toggleLoadingAnimation() {
    this.loading = true;
    setTimeout(() => this.loading = false, 3000);
  }
 Person:any;
	  session:any;
  ngOnInit(): void 
  {
   
  
  if(!localStorage.getItem("accessToken")){
      this.router.navigate(['']);
    }
    else{
      this.session ={"SessionID": localStorage.getItem("accessToken")}
      this.loginService.getUserDetails(this.session).subscribe(res =>{
        this.Person = res;
        this.PersonID = 18;
        this.kidsChurchhService.getChildByParentID(res).subscribe(data => {
            let ChildIDinfo = data["ChildID"];
            let ChildNameinfo = data["Name"] + " " + data["Surname"];
            let ChildKidsChurchNameinfo = data["KidsChurchName"];
          console.log(this.ChildInfo);
    
          this.childForm.controls.ChildID.setValue(ChildIDinfo);
          this.childForm.controls.Name.setValue(ChildNameinfo);
          this.childForm.controls.KidsChurchName.setValue(ChildKidsChurchNameinfo);
          });    
        console.log(this.Person)
      })
    }

   
  }

  onClick(child){
    this.kidsChurchhService.ChildSignOut(child).subscribe(x=>{
      this.showToast('top-right', 'success');
      this.router.navigate['/KidsChurch']
    });
  }

  checked = false;
  
  select(checked: boolean) {
    this.checked = checked;
  }

  toggle() {
    this.sidebarService.toggle(true);
    return false;
  }
  showToast(position, status) {
  
    this.toastrService.show(
      status || 'Success',
      `Child was signed-out successfully.`,
      { position, status});
  }

}
