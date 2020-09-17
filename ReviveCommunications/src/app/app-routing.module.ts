import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ReportStructureGrowthComponent } from './Feedback/report-structure-growth/report-structure-growth.component';
import { NMOReportComponent } from './Feedback/nmoreport/nmoreport.component';
import { AddDiscipleshipComponent } from './Admin/Discipleship/add-discipleship/add-discipleship.component';
import { SearchDiscipleshipComponent } from './Admin/Discipleship/search-discipleship/search-discipleship.component';
import { UpdateDiscipleshipComponent } from './Admin/Discipleship/update-discipleship/update-discipleship.component';
import { ViewOrgIndivPosComponent } from './Admin/OrgIndivPos/view-org-indiv-pos/view-org-indiv-pos.component';
import { AddOrgIndivPosComponent } from './Admin/OrgIndivPos/add-org-indiv-pos/add-org-indiv-pos.component';
import { MaintainOrgIndivPosComponent } from './Admin/OrgIndivPos/maintain-org-indiv-pos/maintain-org-indiv-pos.component';
import { FollowUpDiscipleshipComponent } from './FollowUp/follow-up-discipleship/follow-up-discipleship.component';
import { RegisterChildComponent } from './KidsChurch/register-child/register-child.component';
import { OverviewStructureReportComponent } from './Reports/overview-structure-report/overview-structure-report.component';
import { FollowUpSalvationComponent } from './FollowUp/Salvation/follow-up-salvation/follow-up-salvation.component';
import { FollowUpMembersWantingToServeComponent } from './FollowUp/Members-wanting-to-serve/follow-up-members-wanting-to-serve/follow-up-members-wanting-to-serve.component';
import { SalvationViewComponent } from './FollowUp/Salvation/salvation-view/salvation-view.component';
import { CreateOrganisationalStrcuturePositionComponent } from './Admin/OrgStructPos/Create-Organisational-Strcuture-Position/create-organisational-strcuture-position/create-organisational-strcuture-position.component';
import { AssignOrganisationalStrcuturePositionComponent } from './Admin/OrgStructPos/Assign-Organisational-Strcuture-Position/assign-organisational-strcuture-position/assign-organisational-strcuture-position.component';
import { ViewOrganisationalStrcuturePositionComponent } from './Admin/OrgStructPos/View-Organisational-Strcuture-Position/view-organisational-strcuture-position/view-organisational-strcuture-position.component';
import { MaintainOrganisationalStrcuturePositionComponent } from './Admin/OrgStructPos/Maintain-Organisational-Strcuture-Position/maintain-organisational-strcuture-position/maintain-organisational-strcuture-position.component';
import { HomecellNotesComponent } from './Person/HomecellNotes/Homecell-Notes/homecell-notes/homecell-notes.component';
import { AddHomecellNotesComponent } from './Person/HomecellNotes/Add-Homecell-Notes/add-homecell-notes/add-homecell-notes.component';
import { CheckInChildComponent } from './KidsChurch/Check-in/check-in-child/check-in-child.component';
import { ZoneGrowthReportComponent } from './Reports/Zone-Growth-Report/zone-growth-report/zone-growth-report.component';
import { SalvationFormComponent } from './Salvation/salvation-form/salvation-form.component';
import { SetWeeklyGoalComponent } from './Goals/set-weekly-goal/set-weekly-goal.component';
import { UpdateWeeklyGoalsComponent } from './Goals/update-weekly-goals/update-weekly-goals.component';
import { SearchWeeklyGoalsComponent } from './Goals/search-weekly-goals/search-weekly-goals.component';
import { EditOrganisationalStructurePositionComponent } from './Admin/OrgStructPos/Maintain-Organisational-Strcuture-Position/Edit-Organisational-structure-position/edit-organisational-structure-position/edit-organisational-structure-position.component';
import { FinancialContributionComponent } from './FinancialContribution/financial-contribution/financial-contribution.component';
import { GroupsComponent } from './Groups/groups/groups.component';
import { GroupTransferComponent } from './Groups/group-transfer/group-transfer.component';
import { AddGroupComponent } from './Groups/add-group/add-group.component';
import { MaintainGroupComponent } from './Groups/maintain-group/maintain-group.component';
import { MembersComponent } from './Person/members/members.component';
import { AssignLeaderComponent } from './Person/assign-leader/assign-leader.component';
import { ApproveMemberComponent } from './Person/approve-member/approve-member.component';
import { NmoFollowUpComponent } from './FollowUp/nmo-follow-up/nmo-follow-up.component';
import { LeaderFollowUpComponent } from './FollowUp/leader-follow-up/leader-follow-up.component';
import { ChildrenComponent } from './KidsChurch/children/children.component';
import { VolunteerChildrenComponent } from './KidsChurch/volunteer-children/volunteer-children.component';
import { SignOutChildComponent } from './KidsChurch/sign-out-child/sign-out-child.component';
import { VolunteerSignOutApproveComponent } from './KidsChurch/volunteer-sign-out-approve/volunteer-sign-out-approve.component';
import { UpdateChildComponent } from './KidsChurch/update-child/update-child.component';
import { StructureDiscipleshipComponent } from './Reports/structure-discipleship/structure-discipleship.component';
import { AddChildComponent } from './KidsChurch/add-child/add-child.component';
//import { Ng2SmartTableModule } from 'ng2-smart-table';
//import { HttpClientModule } from '@angular/common/http';
import { CancelConfirmationDialogComponent } from './Admin/OrgStructPos/cancel-confirmation-dialog/cancel-confirmation-dialog.component';
import { LoginComponent } from './login/login/login.component';
import { JoinGroupComponent } from './Groups/join-group/join-group.component';
import { LandingComponent } from './landing/landing.component';
import { HomeComponent } from './home/home.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { UpdateActivationstatusComponent } from './ActivationStatus/update-activationstatus/update-activationstatus.component';
import { ReactivateComponent } from './ActivationStatus/reactivate/reactivate.component';
import { DeActivateComponent } from './ActivationStatus/de-activate/de-activate.component';
import { SearchPersonComponent } from './Person/search-person/search-person.component';
import { UpdatePersonComponent } from './Person/update-person/update-person.component';
import { AddGroupTypeComponent } from './Groups/add-group-type/add-group-type.component';
import { UpdateGroupTypeComponent } from './Groups/update-group-type/update-group-type.component';
import { ReportZoneHCComponent } from './Feedback/report-zone-hc/report-zone-hc.component';
import { ReportZoneChurchAttComponent } from './Feedback/report-zone-church-att/report-zone-church-att.component';
import { ReportZoneGrowthComponent } from './Feedback/report-zone-growth/report-zone-growth.component';
import { ReportOnChurchAttComponent } from './Feedback/report-on-church-att/report-on-church-att.component';
import { ReportOnHCAttComponent } from './Feedback/report-on-hc-att/report-on-hc-att.component';
import { AddCounsellingComponent } from './Counselling/add-counselling/add-counselling.component';
import { ViewCounsellingComponent } from './Counselling/view-counselling/view-counselling.component';
import { ViewCounsellingRequestComponent } from './Counselling/view-counselling-request/view-counselling-request.component';
import { FollowUpMemberComponent } from './FollowUp/follow-up-member/follow-up-member.component';
import { RegisterPersonComponent } from './Person/register-person/register-person.component';
import { SendInvitationComponent } from './Messages/send-invitation/send-invitation.component';
import { PostAnnouncementComponent } from './Messages/post-announcement/post-announcement.component';
import { ViewAnnouncementComponent } from './Messages/view-announcement/view-announcement.component';
import { ViewInvitationComponent } from './Messages/view-invitation/view-invitation.component';
import { RemoveAnnouncementComponent } from './Messages/remove-announcement/remove-announcement.component';

const routes: Routes = [

  { path: '', component: LandingComponent},
  { path: 'Home', component: HomeComponent},

  //Messages
  { path: 'SendInvitation', component: SendInvitationComponent },
  { path: 'PostAnnouncement', component: PostAnnouncementComponent },
  { path: 'ViewInvitation', component: ViewInvitationComponent },
  { path: 'ViewAnnouncement', component: ViewAnnouncementComponent },
  { path: 'RemoveAnnouncement', component: RemoveAnnouncementComponent },
  
  //CRUDs
  { path: 'AddDiscipleship', component: AddDiscipleshipComponent },
  { path: 'SearchDiscipleship', component: SearchDiscipleshipComponent },
  { path: 'UpdateDiscipleship/:id', component: UpdateDiscipleshipComponent },
  { path: 'ViewOrgIndivPos', component: ViewOrgIndivPosComponent },
  { path: 'AddOrgIndivPos', component: AddOrgIndivPosComponent },
  { path: 'MaintainOrgIndivPos/:id', component: MaintainOrgIndivPosComponent },
  { path: 'AddChild', component: AddChildComponent },
  { path: 'UpdateChild', component: UpdateChildComponent },
  { path: 'AddGroup', component: AddGroupComponent },
  { path: 'MaintainGroup', component: MaintainGroupComponent },
  { path: 'SalvationForm', component: SalvationFormComponent},
  { path: 'AddOrganisationalStructurePosition', component: CreateOrganisationalStrcuturePositionComponent },
  { path: 'MaintainOrganisationalStructurePosition', component: MaintainOrganisationalStrcuturePositionComponent },
  { path: 'EditOrganisationalStructurePosition', component: EditOrganisationalStructurePositionComponent },
  { path: 'AssignOrganisationalStructurePosition', component: AssignOrganisationalStrcuturePositionComponent },
  { path: 'CancelConfirmation', component: CancelConfirmationDialogComponent },
  { path: 'ViewOrganisationalStructurePosition', component: ViewOrganisationalStrcuturePositionComponent },
  
  //Follow Ups
  { path: 'FollowUpDiscipleship', component: FollowUpDiscipleshipComponent },
  { path: 'FollowUpSalvation' , component: FollowUpSalvationComponent },
  { path: 'SalvtionForm', component: SalvationFormComponent },
  { path: 'FollowUpMembersWantingToServe' , component: FollowUpMembersWantingToServeComponent },
  { path: 'NMOFollowUp', component: NmoFollowUpComponent },
  { path: 'LeaderFollowUp', component: LeaderFollowUpComponent },
  { path: 'MemberFollowUp', component: FollowUpMemberComponent },

  //Kids Church
  { path: 'RegisterChild', component: RegisterChildComponent },
  { path: 'SignOutChild', component: SignOutChildComponent },
  { path: 'VolunteerSignOutApprove', component: VolunteerSignOutApproveComponent },
  { path: 'VolunteerChildren', component: VolunteerChildrenComponent} ,
  { path: 'KidsChurch', component: ChildrenComponent },
  { path: 'Check-in', component: CheckInChildComponent },

  //Reports
  { path: 'OverviewStructureReport', component: OverviewStructureReportComponent },
  { path: 'StructureDiscipleshipReport', component: StructureDiscipleshipComponent },
  { path: 'ZoneGrowthReport', component: ZoneGrowthReportComponent },

  //Financial Contribution
  { path: 'FinancialContribution', component: FinancialContributionComponent },

  //Goal Feedback
  { path: 'ZoneGrowth', component: ReportZoneGrowthComponent },
  { path: 'ZoneHomecellAttendance', component: ReportZoneHCComponent },
  { path: 'ZoneChurchAttendance', component: ReportZoneChurchAttComponent },
  { path: 'ReportOnHCAtt', component: ReportOnHCAttComponent },
  { path: 'ReportOnChurchAtt', component: ReportOnChurchAttComponent },
  { path: 'ReportOnHCAttComponent', component: ReportOnHCAttComponent },
  { path: 'ReportStructureGowth', component: ReportStructureGrowthComponent },
  { path: 'NMOReport', component: NMOReportComponent },

  //Groups
  { path: 'Groups', component: GroupsComponent },
  { path: 'GroupTransfer', component: GroupTransferComponent },
  { path: 'AddGroupType', component: AddGroupTypeComponent },
  { path: 'UpdateGroupType', component: UpdateGroupTypeComponent },
  { path: 'JoinGroup', component: JoinGroupComponent },

  //Members
  { path: 'ApproveMember', component: ApproveMemberComponent },
  { path: 'AssignLeader', component: AssignLeaderComponent },
  { path: 'Members', component: MembersComponent },
  
  //Login
  { path: 'Login', component: LoginComponent },
  { path: 'ResetPassword', component: ResetPasswordComponent },
  { path: 'UpdatePerson', component: UpdatePersonComponent },
  { path: 'RegisterPerson', component: RegisterPersonComponent },
  { path: "UpdateActivationStatus", component: UpdateActivationstatusComponent },
  { path: "RequestReactivate", component: ReactivateComponent },
  { path: "RequestDeActivate", component: DeActivateComponent },
  { path: "SearchPerson", component: SearchPersonComponent },

  //Counselling
  {path: 'ViewCounselling', component: ViewCounsellingComponent},
  {path: 'AddCounselling', component:AddCounsellingComponent},
  {path: 'ViewCounsellingRequest/:id', component:ViewCounsellingRequestComponent},

  //Goals
  { path: 'SetWeeklyGoal', component: SetWeeklyGoalComponent },
  { path: 'SearchWeeklyGoal', component: SearchWeeklyGoalsComponent },
  { path: 'UpdateWeeklyGoal', component: UpdateWeeklyGoalsComponent },

  //Homecell Notes
  { path: 'AddHCNotes', component: AddHomecellNotesComponent },
  { path: 'HomecellNotes', component: HomecellNotesComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
