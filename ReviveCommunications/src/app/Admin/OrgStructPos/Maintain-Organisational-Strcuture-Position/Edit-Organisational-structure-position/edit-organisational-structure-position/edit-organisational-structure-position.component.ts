import { Component, OnInit } from '@angular/core';
import { OrganisationalStructurePositionService } from 'src/app/Services/organisational-struture-position.service';
import { NbToastrService, NbDialogService } from '@nebular/theme';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { NbMenuItem, NbSidebarService,  NbComponentStatus, NbIconConfig } from '@nebular/theme';
import { OrgIndivPosService } from '../../../../../Services/org-indiv-pos.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-edit-organisational-structure-position',
  templateUrl: './edit-organisational-structure-position.component.html',
  styleUrls: ['./edit-organisational-structure-position.component.scss']
})
export class EditOrganisationalStructurePositionComponent implements OnInit {
  OrgStructPos: any;
  OrgPosition: any;
  OrgStructPos1: any;
  OrgStructType: any;
  OrgIndivPosList: any[];

  Person:any;
	  session:any;

  constructor(private OrgStructPosService: OrganisationalStructurePositionService,
    private formBuilder: FormBuilder,private router: Router,
    private toastrService: NbToastrService ,
    private OIPService: OrgIndivPosService,
    private dialogService: NbDialogService,  
    private sidebarService: NbSidebarService,
    private loginService: LoginService) { 
  this.OrgStructPos = this.formBuilder.group({OrgStructLevel:'',
  OrgStructTypeID: '',
  OrgIndivPosID: '',
  OrgStructIDReportsTo: '',
  Description: '',
  OrgStructID: ''
 });
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
    this.OrgPosition = this.OrgStructPosService.getData();
    console.log(this.OrgPosition.OrgStructID);

      this.OrgStructPos.controls.OrgStructLevel.setValue(this.OrgPosition.OrgStructLevel);
      this.OrgStructPos.controls.OrgStructID.setValue(this.OrgPosition.OrgStructID);
      this.OrgStructPos.controls.OrgStructTypeID.setValue(this.OrgPosition.Description);
      this.OrgStructPos.controls.OrgIndivPosID.setValue(this.OrgPosition.OrgIndivPosID);
      this.OrgStructPos.controls.OrgStructIDReportsTo.setValue(this.OrgPosition.Leaders);
      this.OrgStructPos.controls.Description.setValue(this.OrgPosition.Description);
      
      this.OrgStructPosService.OrgStructPos().subscribe(x =>{
        this.OrgStructPos1 = x
        console.log(this.OrgStructPos1)});

        this.OrgStructPosService.OrgStructType().subscribe(x =>{
          this.OrgStructType = x
          console.log(this.OrgStructType)});

      this.OIPService.getAllOrgIndivPos().subscribe(x =>{
        this.OrgIndivPosList = x
        console.log(this.OrgIndivPosList)}
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

  updateHomecellAttGoalForm(form) {
 
    console.log(form);  
    this.OrgStructPosService.UpdateOrganisationalStructurePosition(form);
   
    this.router.navigate(["/MaintainOrganisationalStructurePosition"]);
    this.SuccessMessage('top-right','success');
  }
  
  //toaster message 
  

  SuccessMessage(position, status) {

    this.toastrService.show(
      status || 'Success',
      `Organisational structure position was updated successfully.`,
      { position, status});

      
    
  }

  close()
  {
    if(confirm("Are you sure you want to go back?"))
    this.router.navigate(["MaintainOrganisationalStructurePosition"]);
  }

  title = 'ReviveCommunications';

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



