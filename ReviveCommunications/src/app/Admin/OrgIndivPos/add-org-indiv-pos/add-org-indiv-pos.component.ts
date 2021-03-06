import { OrgIndivPosService } from './../../../Services/org-indiv-pos.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, ValidatorFn, FormArray, FormControl, FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { NbToastrService, NbDialogService, NbMenuItem, NbSidebarService } from '@nebular/theme';
import { CancelConfirmOIPComponent } from '../cancel-confirm-oip/cancel-confirm-oip.component';
import { OrgIndivPos } from 'src/app/model/OrgIndivPos';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-add-org-indiv-pos',
  templateUrl: './add-org-indiv-pos.component.html',
  styleUrls: ['./add-org-indiv-pos.component.scss']
})
export class AddOrgIndivPosComponent implements OnInit {


  OrgIndivPosID;
  oip;
  Created: OrgIndivPos;
  Usecases;
  Goals;
  Positions: OrgIndivPos[];
  createdOrgIndivPos;
  duration = 3000;

  IndivPos;
  Use_Cases = [];
  Goal_Access =[];

  Person:any;
  session:any;

  form: FormGroup;
  //

  constructor(
    private OipService: OrgIndivPosService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private toastrService: NbToastrService,
    private dialogService: NbDialogService,
    private fb: FormBuilder,
    private sidebarService: NbSidebarService,
    private loginService: LoginService

  ) {

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


  changeSelection() {
    this.fetchSelectedUC()
    this.fetchSelectedGoals()
  }

  fetchSelectedUC() {
    this.Use_Cases = this.Usecases.filter((value, index) => {
      return value.isChecked
    });
  }

  fetchSelectedGoals() {
    this.Goal_Access = this.Goals.filter((value, index) => {
      return value.isChecked
    });
  }



   ngOnInit() {

    this.OrgIndivPosID = this.route.snapshot.paramMap.get('id');
    this.OipService.GetGoalsList().subscribe( x=>
      this.Goals = x);

    this.OipService.GetPositionName().subscribe( x =>
      this.Positions = x)

    this.OipService.GetUseCasesList().subscribe(x =>
      this.Usecases = x);
    
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

  }




  onSubmit(oip){
    console.log(oip)

    if(confirm('Are you sure you want to add an Organisational Individual Position?')){

      this.OipService.createOrgIndivPos(oip).subscribe(x =>{
        this.presentToast('top-right', 'success');
        this.router.navigate(['/ViewOrgIndivPos']);
      });
    }
  };

  async presentToast(position, status) {

    this.toastrService.show(
      'Success',
      'Organisaion Individual Position created successfully.',
      { position, status });
    }

    open() {
      this.dialogService.open(CancelConfirmOIPComponent, {
        context: {

        },
      });
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

}
