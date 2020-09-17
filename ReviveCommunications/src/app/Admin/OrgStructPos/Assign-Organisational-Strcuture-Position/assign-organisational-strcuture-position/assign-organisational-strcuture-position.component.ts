import { Component, OnInit } from '@angular/core';
import { OrganisationalStructurePositionService } from 'src/app/Services/organisational-struture-position.service';
import { Router } from '@angular/router';
import { FormBuilder } from '@angular/forms';
import { OrgIndivPosService } from '../../../../Services/org-indiv-pos.service';
import { NbToastrService, NbSidebarService, NbDialogService, NbMenuItem } from '@nebular/theme';
import { GroupsService } from 'src/app/Services/groups.service';
import { LoginService } from 'src/app/Services/login.service';
import { MembersService } from 'src/app/Services/members.service';

@Component({
  selector: 'app-assign-organisational-strcuture-position',
  templateUrl: './assign-organisational-strcuture-position.component.html',
  styleUrls: ['./assign-organisational-strcuture-position.component.scss']
})
export class AssignOrganisationalStrcuturePositionComponent implements OnInit {
  OrgStructPos: Object;
  Member: any;
  OrgIndivPos: any;
  OrgPosition: any;
  OrgStructPos1: any;
  search: any;
  MemberFound: any;
  ShowAssign: boolean;
  groups: any;

  Person:any;
  session:any;
  structpos: any;

  constructor(private OrgStructPosService: OrganisationalStructurePositionService, private memberService: MembersService,
    private formBuilder: FormBuilder,private router: Router,
    private toastrService: NbToastrService ,
    private dialogService: NbDialogService,
    private groupService: GroupsService ,
    private sidebarService: NbSidebarService,
    private loginService: LoginService) 
    { 
      this.OrgStructPos1 = this.formBuilder.group
      ({

          OrgStructID: '',
          OrgGroupID: '',
          OrgGroupID1: '',
          OrgGroupID2: '',
          OrgGroupID3: '',
          
          PersonID: ''
 });

        this.search = this.formBuilder.group({
          Name:''});
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
    this.OrgStructPosService.OrgStructPos().subscribe(data=> {this.OrgStructPos = data;
    console.log(data)});
    this.ShowAssign = false;
    this.OrgPosition = this.OrgStructPosService.getData();

    this.memberService.getUnassignedLeaders()
      .subscribe(
        leaderdata => 
        {
          this.structpos = leaderdata;
          console.log(leaderdata);
        }
      );

    this.groupService.getGroups().subscribe
    (
      data => 
      {
        this.groups = data;
        console.log(data)
      }
    );

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
  
  
/*
      this.OrgStructPos1.controls.OrgStructLevel.setValue(this.OrgPosition.OrgStructLevel);
      this.OrgStructPos1.controls.OrgStructID.setValue(this.OrgPosition.OrgStructID);
      this.OrgStructPos1.controls.OrgStructTypeID.setValue(this.OrgPosition.Description);
      this.OrgStructPos1.controls.OrgIndivPosID.setValue(this.OrgPosition.OrgIndivPosID);
      this.OrgStructPos1.controls.OrgStructIDReportsTo.setValue(this.OrgPosition.Leaders);
      this.OrgStructPos1.controls.Description.setValue(this.OrgPosition.Description);*/
  
  
  MemberGet(form)
  {
    this.OrgStructPosService.MemberInfo(form);
  }

  MemberSearch(form)
  {
    this.ShowAssign = true;
    this.OrgStructPosService.MemberSearchInfo(form).subscribe(response => {
    let memberInfo = response["PersonID"];
    this.OrgStructPos1.controls.PersonID.setValue(memberInfo);
    console.log(memberInfo);
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

