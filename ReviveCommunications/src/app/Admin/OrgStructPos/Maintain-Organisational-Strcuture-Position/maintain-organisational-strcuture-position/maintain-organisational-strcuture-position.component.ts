import { Component, OnInit } from '@angular/core';
import { OrgData } from 'angular-org-chart/src/app/modules/org-chart/orgData';
import { OrganisationalStructurePositionService } from 'src/app/Services/organisational-struture-position.service';
import { Router } from '@angular/router';
import { NbMenuItem, NbSidebarService,  NbComponentStatus, NbIconConfig, NbToastrService } from '@nebular/theme';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-maintain-organisational-strcuture-position',
  templateUrl: './maintain-organisational-strcuture-position.component.html',
  styleUrls: ['./maintain-organisational-strcuture-position.component.scss']
})
export class MaintainOrganisationalStrcuturePositionComponent implements OnInit {

  OrgStructPos: any;
  orgStructPosition: any;

  Person:any;
	  session:any;

  constructor(private OrgStructPosService: OrganisationalStructurePositionService, 
    private router: Router,  private sidebarService: NbSidebarService,
    private loginService: LoginService,
    private toastrService: NbToastrService ,

    ){}
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
    this.OrgStructPosService.OrgStructPos().subscribe(data=> {this.OrgStructPos = data;});

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

  submitData(position)
  {
    console.log(position);
    this.OrgStructPosService.setData(position);
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
  
  deletePosition(Position) {
    console.log(Position);  
    if(confirm('Are you sure you to delete the organisational structure position?'))
    {
        this.OrgStructPosService.deleteOrgStructPos(Position).subscribe(x =>{         
          location.reload();
          this.SuccessMessage('top-right', 'success');
        });
       
    }
    
  }
  SuccessMessage(position, status) {

    this.toastrService.show(
      status || 'Success',
      `Organisational structure position was deleted successfully.`,
      { position, status});

      
    
  }

  orgData: OrgData= {
    name: "Ps. At Boshoff",
    type: 'Senior Pastor',
    children: [
        {
            name: "Jack Smith",
            type: 'Zone Pastor',
            children: [
                {
                    name: "Kevin Wilson",
                    type: 'Overseer',
                    children: []
                },
                {
                    name: "Andrea Nel",
                    type: 'Overseer',
                    children: []
                }
            ]
        },
        {
            name: "Jane Muller",
            type: 'Zone Pastor',
            children: [
                {
                    name: "Ndlali Ledwaba",
                    type: 'Overseer',
                    children: [
                        {
                            name: "Jackson Seyfried",
                            type: 'Supervisor',
                            children: []
                        }
                    ]
                },
                {
                    name: "Amanda Schwarts",
                    type: 'Overseer',
                    children: [
                        {
                            name: "Louis Botha",
                            type: 'Supervisor',
                            children: []
                        }
                    ]
                }
            ]
        }
    ]
  };
}
