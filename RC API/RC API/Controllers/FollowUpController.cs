using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RC_API.Models;
using System.Web.Http.Cors;
using System.Dynamic;
using System.Web.UI.WebControls;
using System.Web.Compilation;

namespace RC_API.Controllers
{
    public class FollowUpController : ApiController
    {
        private static List<Salvation> allSalvations = new List<Salvation>();
        //Calculate progress statistics
        ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection

        //4.1 Follow-up on salvation - Charl
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //Read All Salvation information
        [System.Web.Http.Route("api/FollowUp/getSalvation")] //create route for api
        [System.Web.Mvc.HttpGet]

        public List<dynamic> getSalvation()
        {
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory


            return SalvationInformation(db.Salvations.Where(z => z.FollowedUp == false).ToList()); // return called method
        }

        public List<dynamic> SalvationInformation(List<Salvation> SalvationTable)
        {
            List<dynamic> dynamicSalvationList = new List<dynamic>();
            List<dynamic> dynamicSalvationListNoAnswer = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var Visitor in SalvationTable)
                {
                    dynamic dynamicSalvation1 = new ExpandoObject();
                    dynamicSalvation1.SalID = Visitor.SalID;
                    dynamicSalvation1.Date = Visitor.Date;
                    dynamicSalvation1.AlterWorker = Visitor.AlterWorker;
                    dynamicSalvation1.Name = Visitor.Name;
                    dynamicSalvation1.Surname = Visitor.Surname;
                    dynamicSalvation1.Age = Visitor.Age;
                    dynamicSalvation1.EmploymentStatus = Visitor.EmploymentStatus;
                    dynamicSalvation1.MaritialStatus = Visitor.MaritualStatus;
                    dynamicSalvation1.ResidentialAddress = Visitor.ResidentialAddress;
                    dynamicSalvation1.Suburb = Visitor.Suburb;
                    dynamicSalvation1.City = Visitor.City;
                    dynamicSalvation1.HomeTelNo = Visitor.HomeTelNo;
                    dynamicSalvation1.WorkTelNo = Visitor.WorkTelNo;
                    dynamicSalvation1.Cellphone = Visitor.CellPhone;
                    dynamicSalvation1.Email = Visitor.Email;
                    dynamicSalvation1.Invited = Visitor.Invited;
                    dynamicSalvation1.NameSurnameInvite = Visitor.NameSurnameInvite;
                    dynamicSalvation1.HomecellLeader = Visitor.HomecellLeader;
                    dynamicSalvation1.ZonePastor = Visitor.ZonePastor;
                    dynamicSalvation1.StudyAddress = Visitor.StudyAddress;
                    dynamicSalvation1.ParentGuardianCell = Visitor.ParentGuardianCell;
                    dynamicSalvation1.PrayerRequest = Visitor.PrayerRequest;
                    dynamicSalvation1.SchoolLevel = Visitor.SchoolLevel;
                    dynamicSalvation1.NameofSchool = Visitor.NameofSchool;
                    dynamicSalvation1.Grade = Visitor.Grade;
                    dynamicSalvation1.StudyYear = Visitor.StudyYear;
                    dynamicSalvation1.Institution = Visitor.Institution;
                    dynamicSalvation1.FollowedUp = Visitor.FollowedUp;
                    dynamicSalvation1.NoAnswer = Visitor.NoAnswer;

                    if (Visitor.FollowedUp == true && Visitor.NoAnswer == false || Visitor.FollowedUp == false && Visitor.NoAnswer == false)
                    {
                        //create new dynamic object 
                        dynamicSalvationList.Add(dynamicSalvation1);
                        // add to dynamic list
                    }
                    else if (Visitor.FollowedUp == false && Visitor.NoAnswer == true)
                    {
                        //create new dynamic object 
                        dynamicSalvationListNoAnswer.Add(dynamicSalvation1);
                        // add to dynamic list
                    }
                }
            }
            catch (Exception e)
            {

            }

            //Add totals and numbers to list

            return dynamicSalvationList.Concat(dynamicSalvationListNoAnswer).ToList();
        }


        [System.Web.Http.Route("api/FollowUp/getSalvationProgress")] //create route for api
        [System.Web.Mvc.HttpGet]
        public dynamic getSalvationProgress() //get JSON parameter
        {
            //create new dynamic object for calculations
            dynamic FollowUpProgress = new ExpandoObject();

            try
            {

                //Get list of data depending on remaining and completed
                List<Salvation> TotalFollowUps = db.Salvations.Where(x => x.FollowedUp == false).ToList();
                List<Salvation> CompletedFollowUps = db.Salvations.Where(x => x.FollowedUp == true).ToList();

                int totals = TotalFollowUps.Count;
                int remaining = TotalFollowUps.Count - CompletedFollowUps.Count;
                int completed = CompletedFollowUps.Count;
                double percentage = totals - remaining;

                //Add list totals and perfom remaining calculations
                FollowUpProgress.Total = totals;
                FollowUpProgress.Remaining = remaining;
                FollowUpProgress.Completed = completed;

                if (FollowUpProgress.Remaining == 0)
                {
                    FollowUpProgress.ProgressPercentage = 100;
                }
                else
                {
                    FollowUpProgress.ProgressPercentage = percentage;
                }
            }
            catch (Exception e)
            {

            }

            return FollowUpProgress;
        }

        //Follow-up Completed
        [System.Web.Http.Route("api/FollowUp/CompletedSalvationFollowUp")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> CompletedSalvationFollowUp([FromBody] Salvation SalvationUpdate) //get JSON parameter
        {
            //validate that there is no null values
            if (SalvationUpdate != null)
            {
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                try
                {
                    Salvation SalFollowUpUpdate = db.Salvations.Where(z => z.SalID == SalvationUpdate.SalID).FirstOrDefault(); //retrieve record to update data


                    SalFollowUpUpdate.FollowedUp = true; //update boolean values
                    SalFollowUpUpdate.NoAnswer = false;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "Completed Follow-up on Salvation with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes
                }
                catch (Exception e)
                {

                }


                return getSalvation();
            }
            else
            {
                return null;
            }
        }

        //Follow-up no Answer
        [System.Web.Http.Route("api/FollowUp/SalvationFollowUpNoAnswer")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> SalvationFollowUpNoAnswer([FromBody] Salvation SalvationUpdate) //get JSON parameter
        {
            //validate that there is no null values
            if (SalvationUpdate != null)
            {

                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                try
                {
                    Salvation SalFollowUpUpdate = db.Salvations.Where(z => z.SalID == SalvationUpdate.SalID).FirstOrDefault(); //retrieve record to update data

                    SalFollowUpUpdate.FollowedUp = false; //update boolean values
                    SalFollowUpUpdate.NoAnswer = true;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "No Answer for Follow-up on Salvation with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getSalvation();
            }
            else
            {
                return null;
            }
        }

        //4.6 Follow-up on Members wanting to serve - Charl

        //Read All Members wanting to serve information
        [System.Web.Http.Route("api/FollowUp/getMembersWantingToServe")] //create route for api
        [System.Web.Mvc.HttpGet]

        public List<dynamic> getMembersWantingToServe()
        {
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

            return getMembersServeInformation(db.Members_Serve_Follow_Up.Where(x => x.FollowUpStatus == false).ToList()); // return called method
        }

        public List<dynamic> getMembersServeInformation(List<Members_Serve_Follow_Up> MemberServeList)
        {
            List<dynamic> dynamicMemberServe = new List<dynamic>();
            List<dynamic> dynamicMemberServeNoAnswer = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var member in MemberServeList)
                {
                    Person memberServePerson = db.People.Where(z => z.PersonID == member.PersonID).FirstOrDefault();
                    Organisational_Group group3 = db.Organisational_Group.Where(z => z.OrgGroupID == member.Group3).FirstOrDefault();
                    //create new dynamic object 
                    dynamic dynamicMember = new ExpandoObject();
                    dynamicMember.PersonName = memberServePerson.Name;
                    dynamicMember.PersonSurname = memberServePerson.Surname;
                    dynamicMember.PersonNumber = memberServePerson.Number;
                    dynamicMember.PersonEmail = memberServePerson.Email;
                    dynamicMember.FollowUpDate = member.FollowUpDate;
                    dynamicMember.ZonePastor = member.ZonePastor;
                    dynamicMember.Homecell = member.Homecell;
                    dynamicMember.SpiritualGiftTestSession = member.SpiritualGiftTestSession;
                    dynamicMember.HighestSpiritualGifts = member.HighestSpiritualGifts;
                    dynamicMember.Group1 = member.Group1;
                    dynamicMember.ServeRequestID = member.ServeRequestID;
                    dynamicMember.Group2 = member.Group2;
                    dynamicMember.Group3 = group3.Description;
                    dynamicMember.Comment = member.Comment;
                    dynamicMember.FollowedUp = member.FollowUpStatus;
                    dynamicMember.NoAnswer = member.NoAnswer;// add to dynamic list


                    if (member.FollowUpStatus == true && member.NoAnswer == false || member.FollowUpStatus == false && member.NoAnswer == false)
                    {
                        //add to dynamic list 
                        dynamicMemberServe.Add(dynamicMember);
                    }
                    else if (member.FollowUpStatus == false && member.NoAnswer == true)
                    {
                        // add to dynamic list
                        dynamicMemberServeNoAnswer.Add(dynamicMember);
                    }
                }
            }
            catch (Exception e)
            {

            }

            return dynamicMemberServe.Concat(dynamicMemberServeNoAnswer).ToList();

        }

        [System.Web.Http.Route("api/FollowUp/getMemberServeProgress")] //create route for api
        [System.Web.Mvc.HttpGet]
        public dynamic getMemberServeProgress() //get JSON parameter
        {
            //create new dynamic object for calculations
            dynamic FollowUpProgress = new ExpandoObject();

            try
            {
                //Get list of data depending on remaining and completed
                List<Salvation> TotalFollowUps = db.Salvations.Where(x => x.FollowedUp == false).ToList();
                List<Salvation> CompletedFollowUps = db.Salvations.Where(x => x.FollowedUp == true).ToList();

                int totals = TotalFollowUps.Count;
                int remaining = TotalFollowUps.Count - CompletedFollowUps.Count;
                int completed = CompletedFollowUps.Count;
                double percentage = totals - remaining;

                //Add list totals and perfom remaining calculations
                FollowUpProgress.Total = totals;
                FollowUpProgress.Remaining = remaining;
                FollowUpProgress.Completed = completed;

                if (FollowUpProgress.Remaining == 0)
                {
                    FollowUpProgress.ProgressPercentage = 100;
                }
                else
                {
                    FollowUpProgress.ProgressPercentage = percentage;
                }
            }
            catch (Exception e)
            {

            }

            return FollowUpProgress;
        }

        //Follow-up  Completed
        [System.Web.Http.Route("api/FollowUp/UpdateMembersServeFollowUp")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateMembersServeFollowUp([FromBody] Members_Serve_Follow_Up MemberServeUpdate) //get JSON parameter
        {
            //validate that there is no null values
            if (MemberServeUpdate != null)
            {
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                try
                {
                    Members_Serve_Follow_Up MemberServeFollowUpUpdate = db.Members_Serve_Follow_Up.Where(z => z.ServeRequestID == MemberServeUpdate.ServeRequestID).FirstOrDefault(); //retrieve record to update data

                    MemberServeFollowUpUpdate.FollowUpStatus = true; //update boolean values
                    MemberServeFollowUpUpdate.NoAnswer = false;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "Completed Follow-up on Members wanting to serve with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes
                }
                catch (Exception e)
                {

                }


                return getMembersWantingToServe();
            }
            else
            {
                return null;
            }
        }

        //Follow-up no Answer
        [System.Web.Http.Route("api/FollowUp/UpdateMembersServeNoAnswer")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateMembersServeNoAnswer([FromBody] Members_Serve_Follow_Up MemberServeUpdate) //get JSON parameter
        {
            //validate that there is no null values
            if (MemberServeUpdate != null)
            {
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
                try
                {

                    Members_Serve_Follow_Up MemberServeFollowUpUpdate = db.Members_Serve_Follow_Up.Where(z => z.ServeRequestID == MemberServeUpdate.ServeRequestID).FirstOrDefault(); //retrieve record to update data

                    MemberServeFollowUpUpdate.FollowUpStatus = false; //update boolean values
                    MemberServeFollowUpUpdate.NoAnswer = true;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "No Answer for Follow-up on Members wanting to serve with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }

                return getMembersWantingToServe();
            }
            else
            {
                return null;
            }
        }



        ////4.5 Follow up on discipleship - Annie
        ////Read All Members who do 
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.Route("api/FollowUp/getPersonDiscInfo")] //create route for api
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getPersonDiscInfo()
        {
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory


            //create list of members that have already been followed up on in the current week 
            var dateCriteria = DateTime.Now.Date.AddDays(-7);
            List<Person_Discipleship> completeFollowUps = db.Person_Discipleship.OrderByDescending(x => x.FollowUpDate)
                .Where(o => o.FollowUpDate <= dateCriteria || o.FollowedUp == true).ToList();


            int DiscipleshipCount = db.Discipleships.Count();



            //Create a list of people who have not completed all the discipleships
            List<Person> needDisc = db.People.Include("Person_Discipleship").Where(x => x.Person_Discipleship.Count < DiscipleshipCount).ToList();

            List<Person> needsFollowUp = new List<Person>();
            foreach (Person p in needDisc)
            {
                //If the person that does not have all 5 has not been called yet this week add to list.
                if (completeFollowUps.Any(x => x.PersonID == p.PersonID))
                {

                }
                else
                {
                    needsFollowUp.Add(p);
                }

            }


            return getMembersDiscipleshipInformation(needsFollowUp); // return called method

        }

        public List<dynamic> getMembersDiscipleshipInformation(List<Person> incompleteDisListc)
        {
            List<dynamic> toPassList = new List<dynamic>();

            dynamic toPass = new ExpandoObject();
            List<dynamic> dynamicMemberDisc = new List<dynamic>();

            try
            {
                //foreach method to retrieve data from database and add it to list to return

                foreach (var member in incompleteDisListc)
                {
                    //create new dynamic object 
                    dynamic dynamicMember = new ExpandoObject();
                    dynamicMember.PersonID = member.PersonID;
                    dynamicMember.PersonName = member.Name;
                    dynamicMember.PersonSurname = member.Surname;
                    dynamicMember.PersonNumber = member.Number;
                    dynamicMember.Discipleships = getPersonsOutstandingDisc(member.PersonID);


                    dynamicMemberDisc.Add(dynamicMember); // add to dynamic list
                }
                toPass.MemberList = dynamicMemberDisc;

                //Calculate progress statistics
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                //create new dynamic object for calculations
                dynamic FollowUpProgress = new ExpandoObject();

                //Get list of data depending on remaining and completed
                // List<Person_Discipleship> TotalFollowUps = db.Person_Discipleship.Where(x => x.FollowedUp == false ).ToList();
                List<Person_Discipleship> CompletedFollowUps = db.Person_Discipleship.Where(x => x.FollowedUp == true && x.FollowUpDate == DateTime.Today).ToList();
                int TotalFollowUps = incompleteDisListc.Count;



                //Add list totals and perfom remaining calculations
                FollowUpProgress.Total = TotalFollowUps;

                if (TotalFollowUps != 0)
                {
                    FollowUpProgress.Remaining = TotalFollowUps - CompletedFollowUps.Count;
                    FollowUpProgress.Completed = CompletedFollowUps.Count;
                    FollowUpProgress.PersentageComplete = CompletedFollowUps.Count / TotalFollowUps * 100;

                }

                //Add calculations and numbers of prgress to the lists
                toPass.FollowUpPorgress = FollowUpProgress;
                toPassList.Add(toPass);
            }
            catch (Exception e)
            {

            }


            return toPassList; //return the list
        }


        //Follow-up  Completed
        [System.Web.Http.Route("api/FollowUp/UpdateDiscipleshipFollowUp")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateDiscipleshipFollowUp([FromBody] dynamic FollowupUpdate) //get JSON parameter
        {
            //validate that there is no null values
            if (FollowupUpdate != null)
            {

                int id = FollowupUpdate.Person0;
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                Person thisPerson = db.People.Where(z => z.PersonID == id).FirstOrDefault(); //retrieve record to update data

                try
                {
                    Person_Discipleship pD = new Person_Discipleship();


                    foreach (var p in FollowupUpdate.Person_Discipleship[0].Discipleship)
                    {
                        pD.PersonID = thisPerson.PersonID;
                        pD.DiscipleshipID = p.DiscipleshipID;
                        pD.FollowUpDate = DateTime.Today;
                        pD.FollowedUp = true;

                    }

                    thisPerson.Person_Discipleship.Add(pD); //Add new completed dicipleship to members Person_Disc table


                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "Completed Follow-up on Discipleship with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes
                }
                catch (Exception e)
                {

                }


                return getPersonDiscInfo();
            }
            else
            {
                return null;
            }
        }


        public List<dynamic> getPersonsOutstandingDisc(int PersonID) //get JSON parameter
        {
            List<OutstandingDiscipleship> pD = db.OutstandingDiscipleships.Where(x => x.personid == PersonID).ToList();

            List<dynamic> outstanding = new List<dynamic>();
            try
            {
                foreach (var o in pD)
                {
                    //create new dynamic object 
                    dynamic dynamicOutstanding = new ExpandoObject();

                    dynamicOutstanding.PersonID = PersonID;
                    dynamicOutstanding.Discipleship = db.Discipleships.Where(d => d.DiscipleshipID == o.discipleshipid);


                    outstanding.Add(dynamicOutstanding); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }


            return outstanding;
        }

        //4.7 Follow-up Member - Marno
        //returns members and then must allow pop/follow up
        [System.Web.Http.Route("api/FollowUp/GetMembers")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetMembers()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            db.Configuration.ProxyCreationEnabled = false;
            return GetMemberList(db.People.ToList());
        }

        private List<dynamic> GetMemberList(List<Person> forClient)
        {
            List<dynamic> dynamicMembers = new List<dynamic>();

            try
            {
                foreach (Person Member in forClient)
                {
                    dynamic dynamicMember = new ExpandoObject();
                    //assign

                    dynamicMember.PersonID = Member.PersonID;
                    dynamicMember.Name = Member.Name;
                    dynamicMember.Number = Member.Number;

                    //add to origional
                    dynamicMembers.Add(dynamicMember);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicMembers;
        }

        [System.Web.Http.Route("api/FollowUp/PopMember")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> PopMembers([FromBody] Person currentP)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            Person Change = db.People.Where(x => x.PersonID == currentP.PersonID).FirstOrDefault();
            try
            {
                db.People.Remove(Change);
                db.SaveChanges();
                db.People.Add(Change);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }


            return GetMembers();
        }

        //4.2 Follow-Up on New Members Orientation - Izaan

        //Read all members who attended NMO
        [System.Web.Http.Route("api/FollowUp/getNMO")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getNMO()
        {
            //Connecting to database
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate overload memory
            db.Configuration.ProxyCreationEnabled = false;

            return NMOInformation(db.NMO_Follow_Up.Where(z => z.FollowUpStatus == false).ToList()); //Return called method
        }

        public List<dynamic> NMOInformation(List<NMO_Follow_Up> NMOList)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate overload memory
            db.Configuration.ProxyCreationEnabled = false;

            //Create dynamic list
            List<dynamic> dynamicNMOAttend = new List<dynamic>();
            List<dynamic> dynamicNMOListNoAnswer = new List<dynamic>();

            try
            {
                //foreach method to retrieve data from databse and add it to list to return
                foreach (var member in NMOList)
                {
                    Person memberNMO = db.People.Where(z => z.PersonID == member.PersonID).FirstOrDefault();

                    //Create dynamic object
                    dynamic dynamicNMOMember = new ExpandoObject();
                    dynamicNMOMember.Name = memberNMO.Name;
                    dynamicNMOMember.Surname = memberNMO.Surname;
                    dynamicNMOMember.Email = memberNMO.Number;
                    dynamicNMOMember.FollowedUp = member.FollowUpStatus;

                    if (member.FollowUpStatus == true && member.NoAnswer == false || member.FollowUpStatus == false && member.NoAnswer == false)
                    {
                        //Add to dynamic list
                        dynamicNMOAttend.Add(dynamicNMOMember);
                    }
                    else if (member.FollowUpStatus == false && member.FollowUpStatus == true)
                    {
                        //Add to dynamic list
                        dynamicNMOListNoAnswer.Add(dynamicNMOMember);
                    }

                }
            }
            catch (Exception e)
            {


            }



            return dynamicNMOAttend; //Return list

            ////Calculate progress statistics

            ////Create new dynamic object for calculations
            //dynamic FollowUpProgress = new ExpandoObject();

            ////Get list of data depending on remaining and completed
            //List<NMO_Follow_Up> TotalFollowUps = db.NMO_Follow_Up.Where(x => x.FollowUpStatus == false && x.NoAnswer == false).ToList();
            //List<NMO_Follow_Up> CompletedFollowUps = db.NMO_Follow_Up.Where(z => z.FollowUpStatus == true && z.NoAnswer == false).ToList();

            ////Add list totals and perform remaining calculations
            //FollowUpProgress.Total = TotalFollowUps.Count();
            //FollowUpProgress.Remaining = TotalFollowUps.Count - CompletedFollowUps.Count;
            //FollowUpProgress.Completed = CompletedFollowUps.Count;
            //FollowUpProgress.PersentageComplete = CompletedFollowUps.Count / TotalFollowUps.Count * 100;

            ////Add calculations and numbers of progress to list
            //dynamicNMOAttend.Add(FollowUpProgress);

            //return dynamicNMOAttend
        }

        //Follow-up Completed
        [System.Web.Http.Route("api/FollowUp/UpdateNMOFollowUP")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateNMOFollowUP([FromBody] NMO_Follow_Up NMOUpdate)
        {
            //Database
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //Validate that there is no null values
            if (NMOUpdate != null)
            {
                NMO_Follow_Up NMOAttendFollowUpUpdate = db.NMO_Follow_Up.Where(z => z.ID == NMOUpdate.ID).FirstOrDefault();

                try
                {
                    NMOAttendFollowUpUpdate.FollowUpStatus = true; //update boolean values
                    NMOAttendFollowUpUpdate.NoAnswer = false;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "Completed Follow-up on NMO with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getNMO();
            }
            else
            {
                return null;
            }
        }

        //Follow-up no answer
        [System.Web.Http.Route("api/FollowUp/UpdateNMOFollowUPNoAnswer")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateNMOFollowUPNoAnswer([FromBody] NMO_Follow_Up NMOUpdate)
        {
            //Database
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //Validate that there is no null values
            if (NMOUpdate != null)
            {
                NMO_Follow_Up NMOAttendFollowUpUpdate = db.NMO_Follow_Up.Where(z => z.ID == NMOUpdate.ID).FirstOrDefault();

                try
                {
                    NMOAttendFollowUpUpdate.FollowUpStatus = false; //update boolean values
                    NMOAttendFollowUpUpdate.NoAnswer = true;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "No answer for Follow-up on NMO with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getNMO();
            }
            else
            {
                return null;
            }
        }

        //4.4 Follow-Up on Leaders - Izaan

        //Read all leaders
        [System.Web.Http.Route("api/FollowUp/getAllLeaders")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllLeaders()
        {
            //Connecting to database
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate overload memory
            db.Configuration.ProxyCreationEnabled = false;

            return leaderInformation(db.Leader_Follow_Up.Where(z => z.FollowUpStatus == false).ToList()); //Return called method
        }

        public List<dynamic> leaderInformation(List<Leader_Follow_Up> LeaderList)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate overload memory
            db.Configuration.ProxyCreationEnabled = false;

            //Create dynamic list
            List<dynamic> dynamicLeaders = new List<dynamic>();
            List<dynamic> dynamicLeaderListNoAnswer = new List<dynamic>();

            try
            {
                //foreach method to retrieve data from databse and add it to list to return
                foreach (var leader in LeaderList)
                {
                    Person memberLeader = db.People.Where(z => z.PersonID == leader.PersonID).FirstOrDefault();

                    //Create dynamic object
                    dynamic dynamicLeader = new ExpandoObject();
                    dynamicLeader.Name = memberLeader.Name;
                    dynamicLeader.Surname = memberLeader.Surname;
                    dynamicLeader.Email = memberLeader.Number;
                    dynamicLeader.FollowedUp = leader.FollowUpStatus;

                    if (leader.FollowUpStatus == true && leader.NoAnswer == false || leader.FollowUpStatus == false && leader.NoAnswer == false)
                    {
                        //Add to dynamic list
                        dynamicLeaders.Add(dynamicLeader);
                    }
                    else if (leader.FollowUpStatus == false && leader.FollowUpStatus == true)
                    {
                        //Add to dynamic list
                        dynamicLeaderListNoAnswer.Add(dynamicLeader);
                    }

                }
            }
            catch (Exception e)
            {

            }



            return dynamicLeaders; //Return list

            ////Calculate progress statistics

            ////Create new dynamic object for calculations
            //dynamic FollowUpProgress = new ExpandoObject();

            ////Get list of data depending on remaining and completed
            //List<Leader_Follow_Up> TotalFollowUps = db.Leader_Follow_Up.Where(x => x.FollowUpStatus == false && x.NoAnswer == false).ToList();
            //List<Leader_Follow_Up> CompletedFollowUps = db.Leader_Follow_Up.Where(z => z.FollowUpStatus == true && z.NoAnswer == false).ToList();

            ////Add list totals and perform remaining calculations
            //FollowUpProgress.Total = TotalFollowUps.Count();
            //FollowUpProgress.Remaining = TotalFollowUps.Count - CompletedFollowUps.Count;
            //FollowUpProgress.Completed = CompletedFollowUps.Count;
            //FollowUpProgress.PersentageComplete = CompletedFollowUps.Count / TotalFollowUps.Count * 100;

            ////Add calculations and numbers of progress to list
            //dynamicLeaders.Add(FollowUpProgress);

            //return dynamicNMOAttend
        }

        //Follow-up Completed
        [System.Web.Http.Route("api/FollowUp/UpdateNMOFollowUP")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateLeaderFollowUP([FromBody] Leader_Follow_Up LeaderUpdate)
        {
            //Database
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //Validate that there is no null values
            if (LeaderUpdate != null)
            {
                Leader_Follow_Up LeaderFollowUpUpdate = db.Leader_Follow_Up.Where(z => z.ID == LeaderUpdate.ID).FirstOrDefault();

                try
                {
                    LeaderFollowUpUpdate.FollowUpStatus = true; //update boolean values
                    LeaderFollowUpUpdate.NoAnswer = false;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "Completed Follow-up on NMO with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getNMO();
            }
            else
            {
                return null;
            }
        }

        //Follow-up no answer
        [System.Web.Http.Route("api/FollowUp/UpdateNMOFollowUPNoAnswer")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateNMOFollowUPNoAnswer([FromBody] Leader_Follow_Up LeaderUpdate)
        {
            //Database
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //Validate that there is no null values
            if (LeaderUpdate != null)
            {
                Leader_Follow_Up LeaderFollowUpUpdate = db.Leader_Follow_Up.Where(z => z.ID == LeaderUpdate.ID).FirstOrDefault();

                try
                {
                    LeaderFollowUpUpdate.FollowUpStatus = false; //update boolean values
                    LeaderFollowUpUpdate.NoAnswer = true;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "No answer for Follow-up on NMO with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getNMO();
            }
            else
            {
                return null;
            }
        }

        // 4.3 Follow-Up on Overseer - Lali
        //----------------OVERSEER FOLLOW-UP----------

        //Read All Overseers information
        [System.Web.Http.Route("api/FollowUp/retrieveOverseers")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> retrieveOverseers()
        {
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

            return getOverseersInformation(db.Overseer_Follow_Up.ToList()); // return called method
        }
        public List<dynamic> getOverseersInformation(List<Overseer_Follow_Up> OverseerList)
        {
            List<dynamic> dynamicOVfollowUp = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var overseer in OverseerList)
                {
                    //create new dynamic object 
                    dynamic dynamicOV = new ExpandoObject();
                    dynamicOV.Overseer = overseer.Overseer;
                    dynamicOV.ZonePastor = overseer.ZonePastor;
                    dynamicOV.Structure = overseer.Structure;
                    dynamicOV.OverseerFollowUpID = overseer.OverseerFollowUpID;
                    dynamicOV.FollowUpStatus = overseer.FollowUpStatus;
                    dynamicOV.PersonID = overseer.PersonID;
                    dynamicOV.FollowUpDate = overseer.FollowUpDate;

                    dynamicOV.NoAnswer = overseer.NoAnswer;
                    dynamicOVfollowUp.Add(dynamicOV); // add to dynamic list
                }
                //Calculate progress statistics
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                //create new dynamic object for calculations
                dynamic FollowUpProgress = new ExpandoObject();

                //Get list of data depending on remaining and completed
                List<Overseer_Follow_Up> TotalFollowUps = db.Overseer_Follow_Up.Where(x => x.FollowUpStatus == false && x.NoAnswer == false).ToList();
                List<Overseer_Follow_Up> CompletedFollowUps = db.Overseer_Follow_Up.Where(x => x.FollowUpStatus == true && x.NoAnswer == false).ToList();

                //Add list totals and perfom remaining calculations
                FollowUpProgress.Total = TotalFollowUps.Count;
                FollowUpProgress.Remaining = TotalFollowUps.Count - CompletedFollowUps.Count;
                FollowUpProgress.Completed = CompletedFollowUps.Count;

                //Add calculations and numbers of prgress to the lists
                dynamicOVfollowUp.Add(FollowUpProgress);
            }
            catch (Exception e)
            {

            }


            return dynamicOVfollowUp; //return the list
        }
        //FollowUpOnOverseer
        [System.Web.Http.Route("api/FollowUp/OverseerFollowUp")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> OverseerFollowUp([FromBody] Overseer_Follow_Up OverseerFollowUp)
        {
            if (OverseerFollowUp != null)
            {
                db.Configuration.ProxyCreationEnabled = false;
                Overseer_Follow_Up OVfollowUpUpdate = db.Overseer_Follow_Up.Where(x => x.OverseerFollowUpID == OverseerFollowUp.OverseerFollowUpID).FirstOrDefault();

                try
                {
                    OVfollowUpUpdate.FollowUpStatus = false;
                    OVfollowUpUpdate.NoAnswer = true;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "Completed Follow-up on Zone Pastor with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return retrieveOverseers();
            }
            else
            {
                return null;
            }
        }
        //Follow-up no Answer
        [System.Web.Http.Route("api/FollowUp/UpdateOverseerFollowUpNoAnswer")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateOverseerFollowUpNoAnswer([FromBody] Overseer_Follow_Up OverseerUpdate) //get JSON parameter
        {
            //validate that there is no null values
            if (OverseerUpdate != null)
            {
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

                Overseer_Follow_Up OverseerFollowUpUpdate = db.Overseer_Follow_Up.FirstOrDefault(); //retrieve record to update data

                try
                {
                    OverseerFollowUpUpdate.FollowUpStatus = false; //update boolean values
                    OverseerFollowUpUpdate.NoAnswer = true;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 1;
                    auditLog.EventDescription = "No Answer for Follow-up on Members wanting to serve with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return retrieveOverseers();
            }
            else
            {
                return null;
            }
        }




    }

}

