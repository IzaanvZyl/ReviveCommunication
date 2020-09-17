import { Component, OnInit } from '@angular/core';
import { NbSidebarService, NbMenuItem } from '@nebular/theme';
import { Router } from '@angular/router';


import jsPDF from 'jspdf';
import autoTable from 'jspdf-autotable';
import Chart from 'chart.js';
import { ReportingService } from 'src/app/Services/reporting.service';
import { LoginService } from 'src/app/Services/login.service';
@Component({
  selector: 'app-zone-growth-report',
  templateUrl: './zone-growth-report.component.html',
  styleUrls: ['./zone-growth-report.component.scss']
})
export class ZoneGrowthReportComponent implements OnInit {

  
  HCList
  CAList

  HCMembers
  HCLeaders
  HCFTV
  HCV
  HCSalvations

  CMembers
  CLeaders
  CFTV
  CV
  CSalvations

  month
  ChurchAtt
  Discipleship
  HCAttendance
  nmo

  pleaseWait: string;
  Data: any
  title = 'Zone Growth Report'
  TableData: Object;
  chart: Chart;
  constructor(private sidebarService: NbSidebarService,
    private router: Router,
    private service : ReportingService,
    private loginService: LoginService) { }

  
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
   Person:any;
	  session:any;
  ngOnInit(){

   
  
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
    this.service.getZoneGrowth().subscribe(x =>{
      console.log(x);
      this.Data = x;
      console.log(x)
      this.month = x['Data'].map(o => o.Month);
      this.ChurchAtt = x['Data'].map(o => o.ChurchAttendance);
      this.HCAttendance = x['Data'].map(o => o.HomecellAttendance);

    })

    this.service.getHomecellAttendance().subscribe(x =>{
      console.log(x)
      this.HCList = x

      this.HCMembers = x['HomecellFeedback'].map(o => o.Member);
      this.HCLeaders = x['HomecellFeedback'].map(o => o.Leader);
      this.HCFTV = x['HomecellFeedback'].map(o => o.FirstTimeVisitors);
      this.HCV = x['HomecellFeedback'].map(o => o.Visitors);
      this.HCSalvations = x['HomecellFeedback'].map(o => o.Salvations);
    })
    this.service.getChurchAttendance().subscribe(x =>{
      console.log(x)
      this.CAList = x
      this.CMembers = x['ChurchAttendanceFeedback'].map(o => o.Members);
      this.CLeaders = x['ChurchAttendanceFeedback'].map(o => o.Leaders);
      this.CFTV = x['ChurchAttendanceFeedback'].map(o => o.FirstTimeVisitors);
      this.CV = x['ChurchAttendanceFeedback'].map(o => o.Visitors);
      this.CSalvations = x['ChurchAttendanceFeedback'].map(o => o.Salvations);
    })
    }

    downloadRequets(){
      this.service.getOverview().subscribe((x) =>{

        var doc = new jsPDF();

       var pageHeight = doc.internal.pageSize.height || doc.internal.pageSize.getHeight();
       var pageWidth = doc.internal.pageSize.width || doc.internal.pageSize.getWidth();

       let month = x['Data'].map(o => o.Month);
       let ChurchAtt = x['Data'].map(o => o.ChurchAttendance);
       let HomecellAttendance = x['Data'].map(o => o.HomecellAttendance);

       let finalY = 160;
       var newCanvas = <HTMLCanvasElement>document.querySelector('#canvas');

       var newCanvasImg = newCanvas.toDataURL("image/png", 1.0);

       doc.setFontSize(30);
       doc.text("Zone Growth Report", (pageWidth /2)-50, 20)
       doc.addImage(newCanvasImg, 'PNG', 20 ,20,160,150);
       doc.setFontSize(14)
       for(let i =0; i<length; i++){
         doc.text(month[i] , (pageWidth /2) -40, finalY +23 )
         // @ts-ignore
         doc.autoTable({startY: finalY + 25, html:'#table' + i, useCss:true, head:[
           [ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" ]
         ]})
       // @ts-ignore
         finalY = doc.autoTable.previous.finalY
       }
       doc.save('ZoneGrowthReport.pdf');

      })

    }

  submitRequets(){

    this.pleaseWait = 'This may take a few minutes. Please wait.'

    this.service.getZoneGrowth().subscribe(x => {
      console.log(x)
      let month = x['Data'].map(o => o.Month);
      let ChurchAtt = x['Data'].map(o => o.ChurchAttendance);

      let HomecellAttendance = x['Data'].map(o => o.HomecellAttendance);


      if (this.chart) this.chart.destroy();
    this.chart = new Chart('canvas', {
      type: 'line',
      data: {
        labels: month,
        datasets: [
          {
          label: 'Church Attendance',
          color: 'white',
          backgroundColor : '#3D047F',
          borderColor: '#3cba9f',
          data: ChurchAtt,
          fill: false,
        },
          {
          label: 'Homecell Attendance',
          color: 'white',
          backgroundColor : '#3D047F',
          borderColor: '#ffcc00',
          data: HomecellAttendance,
          fill: false,
        },

      ]
    },
    options: {
      legend: {
        display: false
      },
      scales:{
        xAxes: [{
          display: true
        }],
        yAxes: [{
          display: true
        }],
      }
    }

    })
    })
    }

}
