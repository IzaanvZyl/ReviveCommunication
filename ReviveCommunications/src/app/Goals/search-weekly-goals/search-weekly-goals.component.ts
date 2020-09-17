import { Component, OnInit } from '@angular/core';
import { GoalsServiceService } from 'src/app/Services/goals.service';
import { NbToastrService, NbDialogService, NbSidebarService, NbMenuItem } from '@nebular/theme';
import { Router } from '@angular/router';
import { LoginComponent } from 'src/app/login/login/login.component';
import { LoginService } from 'src/app/Services/login.service';
//import { HomecellAttendance } from '../../model/Goals';
//import { DeleteConfirmationDialogComponent } from './Goals/delete-confirmation-dialog/delete-confirmation-dialog.component';


@Component({
  selector: 'app-search-weekly-goals',
  templateUrl: './search-weekly-goals.component.html',
  styleUrls: ['./search-weekly-goals.component.scss']
})
export class SearchWeeklyGoalsComponent implements OnInit {

  ZoneHCGoals: any;
  ChurchAtt: any;
  ChurchAttFeedback: Object;
  ZoneHCGoalsFeedback: Object;
  GoalsFeedback: Object;
  goalDisplay: number;
  HCAtt: boolean;
  CAtt: boolean;
  ZHCAtt: boolean;
  goalsPost: any;
  Person:any;
  session:any;

  constructor(private GoalsService: GoalsServiceService, 
    private toastrService: NbToastrService ,private dialogService: NbDialogService, private loginService: LoginService,
    private sidebarService: NbSidebarService,
    private router : Router) { }

    
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
 
  Goals: any;
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
    this.GoalsService.getHomecellAtt().subscribe(data=> {this.Goals = data;});
    this.GoalsService.getZoneHomecellAtt().subscribe(data=> {this.ZoneHCGoals = data;});
    this.GoalsService.getChurchAtt().subscribe(data=> {this.ChurchAtt = data;});

    this.GoalsService.getHomecellAttFeedback().subscribe(data=> {this.GoalsFeedback = data;});
    this.GoalsService.getZoneHomecellAttFeedback().subscribe(data=> {this.ZoneHCGoalsFeedback = data;});
    this.GoalsService.getChurchAttFeedback().subscribe(data=> {this.ChurchAttFeedback = data;});

    this.HCAtt = true;
  
    this.CAtt = true;
  
    this.ZHCAtt = true;
   
  }

displayGoal(form)
{
  if(form.goalDescription == 1)
  {
    this.HCAtt = true;
  
    this.CAtt = false;
  
    this.ZHCAtt = false;
  }
  else if(form.goalDescription == 2)
  {
    this.CAtt = true;
    this.HCAtt = false;

    this.ZHCAtt = false;
  }
  else if(form.goalDescription == 3)
  {
    this.ZHCAtt = true;
    this.HCAtt = false;
    this.CAtt = false;
  
  }

}
    //delete method that will send the goalID data to the service
    deleteHomecellAttGoalID(goalID) {
 
      if(confirm("Are you sure you want to delete this goal?"))
      {
      console.log(goalID);  
      this.GoalsService.deleteHomecellAttGoal(goalID);
      this.SuccessMessage('top-right', 'success')
      }
    }
    //delete method that will send the goalID data to the service
    deleteZoneChruchAttGoalgoalID(goalID) {
      if(confirm("Are you sure you want to delete this goal?"))
      {
      console.log(goalID);  
      this.GoalsService.deleteZoneChurchAttGoal(goalID);
      this.SuccessMessage('top-right', 'success')
      }
    }
    //delete method that will send the goalID data to the service
    deleteChurchAttGoalgoalID(goalID) {
      if(confirm("Are you sure you want to delete this goal?"))
      {
      console.log(goalID);  
      this.GoalsService.deleteChurchAttGoal(goalID);
      this.SuccessMessage('top-right', 'success')
      }
    }
    //delete method that will send the goalID data to the service
    deleteZoneHomecellAttendanceGoalgoalID(goalID) {
      if(confirm("Are you sure you want to delete this goal?"))
      {
      console.log(goalID);  
      this.GoalsService.deleteZoneHomecellAttGoal(goalID);
      this.SuccessMessage('top-right', 'success')
      }
    }
    //delete method that will send the goalID data to the service
    deleteNewMemberOrientationGoalgoalID(goalID) {
  
      console.log(goalID);  
      this.GoalsService.deleteNMOGoal(goalID);
    }
    //delete method that will send the goalID data to the service
    deleteDiscipleshipGoalgoalID(goalID) {
      
      console.log(goalID);  
      this.GoalsService.deleteDiscipleshipGoal(goalID);
    }
    //delete method that will send the goalID data to the service
    deleteStructureGrowthGoalgoalID(goalID) {
   
      console.log(goalID);  
      this.GoalsService.deleteStructureGrowthGoal(goalID);
    }
    //delete method that will send the goalID data to the service
    deleteZoneGrowthGoalgoalID(goalID) {
    
      console.log(goalID);  
      this.GoalsService.deleteZoneGrowthGoal(goalID);
    }
    submitData(pro)
    {
      console.log(pro);
      this.GoalsService.setData(pro);
      this.GoalsService.setData1(1);
    }
    submitData1(pro)
    {
      console.log(pro);
      this.GoalsService.setData(pro);
      this.GoalsService.setData1(2);
    }
    submitData2(pro)
    {
      console.log(pro);
      this.GoalsService.setData(pro);
      this.GoalsService.setData1(3);
    }

    SuccessMessage(position, status) {

      this.toastrService.show(
        status || 'Success',
        `Weekly goal was deleted successfully`,
        { position, status});
    }
    //toaster message 
 /* open() {
    this.dialogService.open(DeleteConfirmationDialogComponent, {
      context: {

      },
    });
  }*/
  }

