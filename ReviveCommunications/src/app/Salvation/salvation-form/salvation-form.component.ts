import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { SalvationServiceService } from '../salvation-service.service';
import { NbSidebarService, NbMenuItem } from '@nebular/theme';

@Component({
  selector: 'app-salvation-form',
  templateUrl: './salvation-form.component.html',
  styleUrls: ['./salvation-form.component.scss']
})
export class SalvationFormComponent implements OnInit {
  salvation;
  
  today: number = Date.now();

  //variables to enable education
  School: boolean;
  University: boolean;

   //variables to enable invitee information
   Invite: boolean;
  Invited: number;

  constructor(private SalvationService: SalvationServiceService, private formBuilder: FormBuilder, private sidebarService: NbSidebarService) { 
    this.salvation = this.formBuilder.group({Date:'',
    AlterWorker: '',
    Title: '',
    Name: '',
    Surname: '',
    Age: '',
    EmploymentStatus: '',
    MaritualStatus: '',
    ResidentialAddress: '',
    Suburb: '',
    City: '',
    HomeTelNo: '',
    WorkTelNo: '',
    Cellphone: '',
    Email: '',
    Invited: '',
    NameSurnameInvite: '',
    ZonePastor: '',
    StudyAddress: '',
    ParentGuardianCell: '',
    PrayerRequest: '',
    SchoolLevel: '',
    NameofSchool: '',
    Grade: '',
    StudyYear: '',
    Institution: ''});
  }

  items: NbMenuItem[] = [

    {
      title: 'Profile',
      icon: 'person-outline',
      children: [
        {
          title: 'Update Profile',
          icon: 'edit-outline',
           link: 'UpdatePerson'
        },
        {
          title: 'Financial Contribution',
          icon: 'credit-card-outline',
           link: 'FinancialContribution'
        },
        {
          title: 'Logout',
          icon: 'unlock-outline',
           link: ''
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
           link: 'Members'
        },
        {
          title: 'Activate Members',
          icon: 'person-done-outline',
           link: 'RequestReactivate'
        },
        {
          title: 'Deactivate Members',
          icon: 'person-remove-outline',
           link: 'RequestDeActivate'
        },
        {
          title: 'Transfer Groups',
          icon: 'swap-outline',
           link: 'GroupTransfer'
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
           link: 'SendInvitation'

        },
        {
          title: 'Send Announcement',
          icon: 'arrow-right-outline',
           link: 'PostAnnouncement'
        },
        {
          title: 'Remove Announcement',
          icon: 'arrow-right-outline',
           link: 'RemoveAnnouncement'
        },
      ],

    },
     {
      title: 'Groups',
      icon: 'plus-circle-outline',
       link: 'Groups'
    },
     {
      title: 'Homecell notes',
      icon: 'file-add-outline',
       link: 'HomecellNotes'
    },
     {
      title: 'Kids Church',
      icon: 'home-outline',
       link: 'KidsChurch'

    },

    {
      title: 'Follow-up',
      icon: 'phone-outline',
      children: [
        {
          title: 'Salvation',
          icon: 'arrow-right-outline',
           link: 'FollowUpSalvation'

        },
        {
          title: 'Requests to Serve',
          icon: 'arrow-right-outline',
           link: 'FollowUpMembersWantingToServe'
        },
        {
          title: 'NMO',
          icon: 'arrow-right-outline',
           link: 'NMOFollowUp'
        },
        {
          title: 'Overseers',
          icon: 'arrow-right-outline',
           link: '#'
        },
        {
          title: 'Leaders',
          icon: 'arrow-right-outline',
           link: 'LeaderFollowUp'
        },
        {
          title: 'Members',
          icon: 'arrow-right-outline',
           link: 'MemberFollowUp'
        },
        {
          title: 'Discipleship',
          icon: 'arrow-right-outline',
           link: 'FollowUpDiscipleship'
        },
      ],

    },
    {
      title: 'Set Goals',
      icon: 'award-outline',
       link: 'SetWeeklyGoal'

    },
    {
      title: 'Feedback',
      icon: 'bar-chart',
      children: [
        {
          title: 'Homecell Attendance',
          icon: 'arrow-right-outline',
           link: 'ReportOnHCAtt'

        },
        {
          title: 'Church Attendance',
          icon: 'arrow-right-outline',
           link: 'ReportOnChurchAtt'
        },
        {
          title: 'Structure Growth',
          icon: 'arrow-right-outline',
           link: 'ReportStructureGowth'
        },
        {
          title: 'New Member Orientation',
          icon: 'arrow-right-outline',
           link: 'NMOReport'
        },
        {
          title: 'Zone Growth',
          icon: 'arrow-right-outline',
           link: 'ZoneGrowth'
        },
        {
          title: 'Zone HC Attendance',
          icon: 'arrow-right-outline',
           link: 'ZoneHomecellAttendance'
        },
        {
          title: 'Zone Church Attendance',
          icon: 'arrow-right-outline',
           link: 'ZoneChurchAttendance'
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
           link: 'ZoneGrowthReport'

        },
        {
          title: 'Overview Of Structure',
          icon: 'arrow-right-outline',
           link: 'OverviewStructureReport'
        },
        {
          title: 'Discipleship Progress',
          icon: 'arrow-right-outline',
           link: 'StructureDiscipleshipReport'
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
              link: 'AddGroupType',
            },
            {
              title: 'Update Group Type',
              icon: 'arrow-right-outline',
              link: 'UpdateGroupType',
            }
          ],
        },
        {
          title: 'Discipleships',
          icon: 'arrow-right-outline',
           link: 'SearchDiscipleship'
        },
        {
          title: 'Structure Positions',
          icon: 'arrow-right-outline',
           link: 'ViewOrganisationalStructurePosition'
        },
        {
          title: 'Individual Positions',
          icon: 'arrow-right-outline',
           link: 'ViewOrgIndivPos'
        },
      ],

    },
  ];

  ngOnInit(): void {
    this.School = false;
    this.University = false;
    this.Invite = false;
  }
  //Add method that will send the form data to the service
  addSalvationForm(form) {
    
    //form.Date = Date.now();
    form.Invited = this.Invited;
    console.log(form);  
    this.SalvationService.addNewSalvation(form);
  }

  //aMethods that will enable education sections
  enableUniversity()
  {
    this.University = true;
    this.School = false;
  }
  enableSchool()
  {
    this.School = true;
    this.University = false;
  }
  enableInvite()
  {
    this.Invite = true;
    this.Invited = 1;
  }
  disableInvite()
  {
    this.Invite = false;
    this.Invited = 0;
  }
 

}
