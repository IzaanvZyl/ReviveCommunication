import { Component, OnInit } from '@angular/core';
import { ChurchOption } from 'src/app/model/churchoption';
import { BankingInfo } from 'src/app/model/banking';
import { FinancialContributionService } from 'src/app/Services/financial-contribution.service';
import { FormBuilder } from '@angular/forms';
import { NbSidebarService, NbMenuItem } from '@nebular/theme';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-financial-contribution',
  templateUrl: './financial-contribution.component.html',
  styleUrls: ['./financial-contribution.component.scss']
})
export class FinancialContributionComponent implements OnInit {
  showTable = false;
  selectedOption: BankingInfo[];
  bankingDetails: false;
  showErrorMessage: boolean = false;

  financialContribution;
  ChurchBankID: BankingInfo[];

  Person:any;
	  session:any;

  options: ChurchOption[] /*= [
    { ChurchBankID: 1, ChurchName: 'CRC Pretoria' },
    { ChurchBankID: 2, ChurchName: 'CRC Bloemfontein' },
    { ChurchBankID: 3, ChurchName: 'CRC Johannesburg' },
  ]*/;
  bankingOptions: BankingInfo[] /*= [
    { ChurchBankID: 1, ChurchName: 'CRC Pretoria', AccountName: "CRC Pretoria", AccountNumber: "9164642662", Bank: "ABSA", BranchCode: "632005", Reference: "Name, Surname & Zone" },
    { ChurchBankID: 2, ChurchName: 'CRC Bloemfontein', AccountName: "CRC Bloemfontein", AccountNumber: "1102507490", Bank: "Nedbank", BranchCode: "110234", Reference: "Name, Surname & Zone" },
    { ChurchBankID: 3, ChurchName: 'CRC Johannesburg', AccountName: "CRC Johannesburg", AccountNumber: "9257341989", Bank: "ABSA", BranchCode: "632005", Reference: "Name, Surname & Zone" },
  ]*/;
  banking: Object;

  constructor(private router:Router, 
    private financialContributionService: FinancialContributionService, 
    private formBuilder: FormBuilder, 
    private sidebarService: NbSidebarService,
    private loginService: LoginService) {
    this.financialContribution = this.formBuilder.group(
      {
        ChurchBankID: ''
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

  ngOnInit() {
    this.bankingDetails = false;
    this.financialContributionService.getChurchNames()
    .subscribe
    (
      bankdata =>
      {
        this.options = bankdata;
        console.log(bankdata);
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

  

  showBanking(form) 
  {
    //this.ChurchBankID = form.ChurchBankID;
    console.log(form.ChurchBankID);

    this.financialContributionService.getChurchBanking(form.ChurchBankID).subscribe((res => {
      this.banking = res;
      console.log(res);
    }))
    //this.showTable = true;
  }
}

