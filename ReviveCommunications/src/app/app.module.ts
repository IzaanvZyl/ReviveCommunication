import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrgChartModule } from 'angular-org-chart';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SendInvitationComponent } from './Messages/send-invitation/send-invitation.component';
import { ViewInvitationComponent } from './Messages/view-invitation/view-invitation.component';
import { PostAnnouncementComponent } from './Messages/post-announcement/post-announcement.component';
import { RemoveAnnouncementComponent } from './Messages/remove-announcement/remove-announcement.component';
import { ViewAnnouncementComponent } from './Messages/view-announcement/view-announcement.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbButtonModule, NbIconModule, NbMenuModule, NbInputModule, NbListModule, NbCardModule, NbCheckboxModule, NbUserModule, NbStepperModule, NbRadioModule, NbActionsModule, NbAccordionModule, NbToastrModule, NbDialogModule, NbSelectModule, NbTabsetModule, NbProgressBarModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
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
import { ViewGroupDialogComponent } from './Groups/view-group-dialog/view-group-dialog.component';
import { MembersComponent } from './Person/members/members.component';
import { AssignLeaderComponent } from './Person/assign-leader/assign-leader.component';
import { ViewMemberDialogComponent } from './Person/view-member-dialog/view-member-dialog.component';
import { ApproveMemberComponent } from './Person/approve-member/approve-member.component';
import { NmoFollowUpComponent } from './FollowUp/nmo-follow-up/nmo-follow-up.component';
import { LeaderFollowUpComponent } from './FollowUp/leader-follow-up/leader-follow-up.component';
import { ChildrenComponent } from './KidsChurch/children/children.component';
import { ViewChildDialogComponent } from './KidsChurch/view-child-dialog/view-child-dialog.component';
import { SignOutChildDialogComponent } from './KidsChurch/sign-out-child-dialog/sign-out-child-dialog.component';
import { SignedOutChildDialogComponent } from './KidsChurch/signed-out-child-dialog/signed-out-child-dialog.component';
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
import { CancelConfirmDiscipleshipComponent } from 'src/app/Admin/Discipleship/cancel-confirm-discipleship/cancel-confirm-discipleship.component';
import { ConfirmDeleteDialogComponent } from './Admin/Discipleship/confirm-delete-dialog/confirm-delete-dialog.component';
import { ConfirmDeleteOIPDialogComponent } from './Admin/OrgIndivPos/confirm-delete-oipdialog/confirm-delete-oipdialog.component';
import { CancelConfirmOIPComponent } from './Admin/OrgIndivPos/cancel-confirm-oip/cancel-confirm-oip.component';
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
//import jsPDF from 'jspdf';


@NgModule({
  declarations: [
    AppComponent,
    SendInvitationComponent,
    ViewInvitationComponent,
    PostAnnouncementComponent,
    RemoveAnnouncementComponent,
    ViewAnnouncementComponent,
    ReportStructureGrowthComponent,
    NMOReportComponent,
    AddDiscipleshipComponent,
    SearchDiscipleshipComponent,
    UpdateDiscipleshipComponent,
    ViewOrgIndivPosComponent,
    AddOrgIndivPosComponent,
    MaintainOrgIndivPosComponent,
    FollowUpDiscipleshipComponent,
    RegisterChildComponent,
    OverviewStructureReportComponent,
    FollowUpSalvationComponent,
    FollowUpMembersWantingToServeComponent,
    SalvationViewComponent,
    CreateOrganisationalStrcuturePositionComponent,
    AssignOrganisationalStrcuturePositionComponent,
    ViewOrganisationalStrcuturePositionComponent,
    MaintainOrganisationalStrcuturePositionComponent,
    HomecellNotesComponent,
    AddHomecellNotesComponent,
    CheckInChildComponent,
    ZoneGrowthReportComponent,
    SalvationFormComponent,
    SetWeeklyGoalComponent,
    UpdateWeeklyGoalsComponent,
    SearchWeeklyGoalsComponent,
    EditOrganisationalStructurePositionComponent,
    FinancialContributionComponent,
    GroupsComponent,
    GroupTransferComponent,
    AddGroupComponent,
    MaintainGroupComponent,
    ViewGroupDialogComponent,
    MembersComponent,
    AssignLeaderComponent,
    ViewMemberDialogComponent,
    ApproveMemberComponent,
    NmoFollowUpComponent,
    LeaderFollowUpComponent,
    ChildrenComponent,
    ViewChildDialogComponent,
    SignOutChildDialogComponent,
    SignedOutChildDialogComponent,
    VolunteerChildrenComponent,
    SignOutChildComponent,
    VolunteerSignOutApproveComponent,
    UpdateChildComponent,
    StructureDiscipleshipComponent,
    AddChildComponent,
    CancelConfirmationDialogComponent,
    LoginComponent,
    CancelConfirmDiscipleshipComponent,
    ConfirmDeleteDialogComponent,
    CancelConfirmOIPComponent,
    ConfirmDeleteOIPDialogComponent,
    LandingComponent,
    HomeComponent,
    ResetPasswordComponent,
    UpdateActivationstatusComponent,
    ReactivateComponent,
    DeActivateComponent,
    SearchPersonComponent,
    UpdatePersonComponent,
    AddGroupTypeComponent,
    UpdateGroupTypeComponent,
    JoinGroupComponent,
    ReportStructureGrowthComponent,
    ReportOnChurchAttComponent,
    ReportOnHCAttComponent,
    ReportStructureGrowthComponent,
    ReportOnHCAttComponent,
    ReportOnChurchAttComponent,
    ReportZoneHCComponent,
    ReportZoneChurchAttComponent,
    ReportZoneGrowthComponent,
    AddCounsellingComponent,
    ViewCounsellingComponent,
    ViewCounsellingRequestComponent,
    FollowUpMemberComponent,
    RegisterPersonComponent  

  ],
  imports: [
    //HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'cosmic' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule,
    NbButtonModule,
    NbSidebarModule.forRoot(),
    NbIconModule,
    NbMenuModule.forRoot(),
    NbMenuModule,
    NbInputModule,
    NbListModule,
    NbCardModule,
    NbCheckboxModule,
    NbUserModule,
    NbStepperModule,
    NbRadioModule,
    NbActionsModule,
    NbAccordionModule,
    NbToastrModule.forRoot(),
    NbDialogModule.forRoot(),
    NbSelectModule,
    NbTabsetModule,
    NbProgressBarModule,
    //Ng2SmartTableModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    OrgChartModule,
    //jsPDF,
  ],
  entryComponents: [
    ConfirmDeleteDialogComponent,
    CancelConfirmDiscipleshipComponent,
    CancelConfirmOIPComponent,
    ConfirmDeleteOIPDialogComponent,
    ViewMemberDialogComponent,
    ViewChildDialogComponent,
    ViewGroupDialogComponent
  ],
  schemas: [ CUSTOM_ELEMENTS_SCHEMA ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
