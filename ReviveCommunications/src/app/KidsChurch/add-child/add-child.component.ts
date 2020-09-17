import { Component, OnInit } from '@angular/core';
import { NbSidebarService, NbMenuItem, NbToastrService, NbDialogService } from '@nebular/theme';
import { FormBuilder, FormGroup } from '@angular/forms';
import { KidsChurchService } from 'src/app/Services/kids-church.service'; 
import { IKidsChurch } from 'src/app/model/kidschurch';
import { from } from 'rxjs';
import { ViewChildDialogComponent } from 'src/app/KidsChurch/view-child-dialog/view-child-dialog.component';
import { SignOutChildDialogComponent } from 'src/app/KidsChurch/sign-out-child-dialog/sign-out-child-dialog.component';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/Services/login.service';

export interface tempChild {
  ChildID: number;
  ChildName: string;
  ChildSurname: string;
  DateOfBirth: string;
}

@Component({
  selector: 'app-add-child',
  templateUrl: './add-child.component.html',
  styleUrls: ['./add-child.component.scss']
})
export class AddChildComponent implements OnInit {

  addChild;
  kidschurches: IKidsChurch[];

  checked = false;
  loading = false;
  showTable = false;
  myChildren: any[];
  Person:any;
  session:any;


  constructor(private sidebarService: NbSidebarService,
              private toastrService: NbToastrService,
              private formbuilder: FormBuilder,
              private kidsChurchService: KidsChurchService,
              private dialogService: NbDialogService,
              private router: Router,
              private loginService : LoginService) 
              {
                this.addChild = this.formbuilder.group(
                  {
                    Name: '',
                    Surname: '',
                    DateOfBirth: '',
                  }
                );
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
  ngOnInit() 
  {
   
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

  toggle() {
    this.sidebarService.toggle(true);
    return false;
  }

  showToast(position, status) {

    if (this.checked = true)
    {
      this.toastrService.show(
        status || 'Success',
        `Child successfully added`,
        { position, status});
    }
    else
    {
      this.toastrService.show(
        status || 'Danger',
        `Not all field were completed. Please complete all required fields`,
        { position, status});
    }

    
  }

  showErrorToast(position, status) {

    this.toastrService.show(
      status || 'Danger',
      `Not all field were completed. Please complete all required fields`,
      { position, status});
  }

  onSubmit(form)
  {
  
    console.log(form);
    form.PersonID = this.Person.PersonID;
    this.kidsChurchService.addChild(form).subscribe(x =>{
      console.log(x)
     
      // this.getMyChildren()
      this.router.navigate(['/Home'])
    }
      
    );
    this.addChild = this.formbuilder.group(
      {
        Name: '',
        Surname: '',
        DateOfBirth: '',
      }
    );
    this.showToast('top-right', 'success');

 
  }

  getMyChildren(){
    this.kidsChurchService.getMyChildren().subscribe( x=>{  
      this.myChildren = x;
      console.log(x)
    })
    this.showTable = true;
  }

  open() {
    this.dialogService.open(SignOutChildDialogComponent, {
      context: {

      },
    });
  }

  open2() {

  
    this.dialogService.open(ViewChildDialogComponent, {
      context: {

      },
    });
  }

  toggleLoadingAnimation() {
    this.loading = true;
    setTimeout(() => this.loading = false, 3000);
  }


 

}

