import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { GoalsServiceService } from 'src/app/Services/goals.service';
import { NbToastrService, NbDialogService, NbMenuItem, NbSidebarService } from '@nebular/theme';
import { DiscipleshipService } from '../../Services/discipleship.service';
import { Discipleship } from '../../model/Discipleship';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';
//import { CancelDialogComponent } from '../cancel-dialog/cancel-dialog.component';

@Component({
  selector: 'app-set-weekly-goal',
  templateUrl: './set-weekly-goal.component.html',
  styleUrls: ['./set-weekly-goal.component.scss']
})
export class SetWeeklyGoalComponent implements OnInit {
  HomecellAttendance: any;
  ZoneChurchAttendance: any;
  ChurchAttendance: any;
  ZoneHomecellAttendance: any;
  NewMemberOrientation: any;
  Discipleship: any;
  StructureGrowth: any;
  ZoneGrowth: any;

  setHomecellAttendance = true;
  setZoneChurchAttendance = false;
  setChurchAttendance = false;
  setZoneHomecellAttendance = false;
  setNewMemberOrientation = false;
  setDiscipleship = false;
  setStructureGrowth = false;
  setZoneGrowth = false;
  dataGet: any;
  HCAtt: boolean;
  CAtt: boolean;
  ZHCAtt: boolean;

  Person:any;
  session:any;

  constructor(private router: Router, private GoalsService: GoalsServiceService,private formBuilder: FormBuilder, private sidebarService: NbSidebarService,
      private toastrService: NbToastrService ,private dialogService: NbDialogService, private DiscService :DiscipleshipService, private loginService:LoginService) { 
    this.HomecellAttendance = this.formBuilder.group({Date:'',
    Description: '',
    Members: '',
    Leaders: '',
    Visitors: '',
    FirstTimeVisitors: '',
    Salvations: '',
    Overseer: ''});

    this.ZoneChurchAttendance = this.formBuilder.group({Date:'',
    Description: '',
    Member: '',
    Leader: '',
    Visitors: '',
    FirstTimeVisitors: '',
    Salvations: '',
    Overseer: ''});

    this.ChurchAttendance = this.formBuilder.group({Date:'',
    Description: '',
    Member: '',
    Leader: '',
    Visitors: '',
    FirstTimeVisitors: '',
    Salvations: '',
    Overseer: ''});

    this.ZoneHomecellAttendance = this.formBuilder.group({Date:'',
    Description: '',
    Members: '',
    Leaders: '',
    Visitors: '',
    FirstTimeVisitors: '',
    Salvations: '',
    MaritualStatus: '',
    Overseer: ''});

    this.NewMemberOrientation = this.formBuilder.group({Date:'',
    MonthTotal: '',
    Members: '',
    Overseer: ''});

    this.Discipleship = this.formBuilder.group({Date:'',
    Description: '',
    DiscipleshipType: '',
    Attendance: '',
    Overseer: ''});

    this.StructureGrowth = this.formBuilder.group({Date:'',
    Description: '',
    MonthlyTotal: '',
    Members: '',
    Overseer: ''});

    this.ZoneGrowth = this.formBuilder.group({Date:'',
    Description: '',
    MonthlyTotal: '',
    Members: '',
    Overseer: ''});
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
           link: '/OverviewStructureReport'
        },
   
      ],

    },
  ];
  discipleshipTypes : Discipleship[];
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

    HCAtt: true;
  CAtt: true;
  ZHCAtt: true;
    this.DiscService.getAllDiscipleships().subscribe(data=> {this.discipleshipTypes = data;});
    this.dataGet = this.GoalsService.getData();

    console.log(this.dataGet);
    
  // if(this.dataGet == 1)
  // {
  //   this.HCAtt = true;
  //   this.CAtt = false;
  //   this.ZHCAtt = false;
  // }
  // else if(this.dataGet == 2)
  // {
  //   this.CAtt = true;
  //   this.HCAtt = false;
  //   this.ZHCAtt = false;
  // }
  // else if(this.dataGet == 3)
  // {
  //   this.ZHCAtt = true;
  //   this.HCAtt = false;
  //   this.CAtt = false;
  
  // }

  }

  //Add method that will send the form data to the service
  addHomecellAttGoalForm(form) {
 
    console.log(form);  
    this.GoalsService.setHomecellAttGoal(form);
  }
  
  addZoneChruchAttGoalForm(form) {
    
    console.log(form);  
    this.GoalsService.setZoneChurchAttGoal(form);
  }
  
  addChurchAttGoalForm(form) {
    
    console.log(form);  
    this.GoalsService.setChurchAttGoal(form);
  }
  
  addZoneHomecellAttendanceGoalForm(form) {
    
    console.log(form);  
    this.GoalsService.setZoneHomecellAttGoal(form);
  }
  
  addNewMemberOrientationGoalForm(form) {

    console.log(form);  
    this.GoalsService.setNMOGoal(form);
  }
  
  addDiscipleshipGoalForm(form) {
    
    console.log(form);  
    this.GoalsService.setDiscipleshipGoal(form);
  }
  
  addStructureGrowthGoalForm(form) {
 
    console.log(form);  
    this.GoalsService.setStructureGrowthGoal(form);
  }
  
  addZoneGrowthGoalForm(form) {
  
    console.log(form);  
    this.GoalsService.setZoneGrowthGoal(form);
  }

  //toaster message 
 

  SuccessMessage(position, status) {

    this.toastrService.show(
      status || 'Success',
      `Weekly goal was set successfully`,
      { position, status});
  }
}
