using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using RC_API.Models;
using System.Web.Http.Cors;
using System.Dynamic;


namespace RC_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class FeedbackController : ApiController
    {
        //2.13 report on Homecell attendance -Marno
        [System.Web.Http.Route("api/Feedback/ReportHCAttendance")]
        [System.Web.Mvc.HttpPost]
        public void ReportHCAttendance([FromBody] Homecell_Attendance_Feedback AddHCAttendance)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddHCAttendance != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    dynamic Att = new ExpandoObject();

                    Att.Date = AddHCAttendance.Date;
                    Att.Description = AddHCAttendance.Description;
                    Att.Members = AddHCAttendance.Members;
                    Att.Salvations = AddHCAttendance.Salvations;
                    Att.Leaders = AddHCAttendance.Leaders;
                    Att.Visitors = AddHCAttendance.Visitors;
                    Att.FirstTimeVisitors = AddHCAttendance.FirstTimeVisitors;
                    Att.HomecellAttendanceGoalID = AddHCAttendance.HomecellAttendanceGoalID;
                    Att.OrgIndivPosID = AddHCAttendance.OrgIndivPosID;

                    db.Homecell_Attendance_Feedback.Add(Att);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Homecell Attendance with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {

            }

        }

        //2.14 Report on church attendance- -Marno
        [System.Web.Http.Route("api/Feedback/ReportChurchAttendance")]
        [System.Web.Mvc.HttpPost]
        public void ReportChurchAttendance([FromBody] Church_Attendance_Feedback AddChurchAttendance)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddChurchAttendance != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Church_Attendance_Feedback.Add(AddChurchAttendance);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Church Attendance with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }

        //2.15 Report discipleship -Marno
        [System.Web.Http.Route("api/Feedback/ReportDisc")]
        [System.Web.Mvc.HttpPost]
        public void ReportDisc([FromBody] Discipleship_Feedback AddDisc)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddDisc != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Discipleship_Feedback.Add(AddDisc);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Discipleship with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }


        //2.16 Report on structture growth -Marno
        [System.Web.Http.Route("api/Feedback/ReportStructureGrowth")]
        [System.Web.Mvc.HttpPost]
        public void ReportStructureGrowth([FromBody] Structure_Growth_Feedback AddStructureGrowth)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddStructureGrowth != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Structure_Growth_Feedback.Add(AddStructureGrowth);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Structure Growth with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }

        //2.17 Report on NMO -Marno
        [System.Web.Http.Route("api/Feedback/ReportNMO")]
        [System.Web.Mvc.HttpPost]
        public void ReportNMO([FromBody] NMO_Feedback AddNMO)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddNMO != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.NMO_Feedback.Add(AddNMO);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on New Members Orienatation with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }

        //2.18 Report on zone growth -Marno
        [System.Web.Http.Route("api/Feedback/ReportZoneGrowth")]
        [System.Web.Mvc.HttpPost]
        public void ReportZoneGrowth([FromBody] Zone_Growth_Feedback AddZG)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddZG != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Zone_Growth_Feedback.Add(AddZG);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Zone Growth with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }

        //2.19 Report on zone HC att -Marno
        [System.Web.Http.Route("api/Feedback/ReportZoneHC")]
        [System.Web.Mvc.HttpPost]
        public void ReportZoneHC([FromBody] Zone_Homecell_Attendance_Feedback AddZHA)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddZHA != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Zone_Homecell_Attendance_Feedback.Add(AddZHA);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Zone Homecell Attendance with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }

        //2.20 Report on zone church att -Marno
        [System.Web.Http.Route("api/Feedback/ReportZoneCA")]
        [System.Web.Mvc.HttpPost]
        public void ReportZoneCA([FromBody] Zone_Church_Attendance_Feedback AddZCA)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddZCA != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Zone_Church_Attendance_Feedback.Add(AddZCA);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Feedback on Zone Church Attendance with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

            }

        }

        //Search Weekly Goal
        [System.Web.Http.Route("api/Feedback/getAllChurchAttFeedback")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllChurchAttFeedback()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getChurchAtt(db.Church_Attendance_Feedback.ToList()); // return called method
        }

        public List<dynamic> getChurchAtt(List<Church_Attendance_Feedback> ChurchAtt)
        {
            List<dynamic> DynamicChurchAttFeedback = new List<dynamic>();
            //foreach method ro retrieve data from database and add it to list to return
            foreach (var ChurchAttFeedback in ChurchAtt)
            {
                //create new dynamic object 
                dynamic DynamicChurchAtt = new ExpandoObject();
                DynamicChurchAtt.Date = ChurchAttFeedback.Date; //update data with parameter data
                DynamicChurchAtt.Member = ChurchAttFeedback.Member;
                DynamicChurchAtt.Leader = ChurchAttFeedback.Leader;
                DynamicChurchAtt.Visitors = ChurchAttFeedback.Visitors;
                DynamicChurchAtt.FirstTimeVisitors = ChurchAttFeedback.FirstTimeVisitors;
                DynamicChurchAtt.Salvations = ChurchAttFeedback.Salvations;
                DynamicChurchAttFeedback.Add(DynamicChurchAtt); // add to dynamic list
            }
            return DynamicChurchAttFeedback;
        }

        [System.Web.Http.Route("api/Feedback/getAllHomecellAttFeedback")] //create route for api
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllHomecellAttFeedback()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getHomecellAtt(db.Homecell_Attendance_Feedback.ToList()); // return called method
        }

        public List<dynamic> getHomecellAtt(List<Homecell_Attendance_Feedback> HomecellAtt)
        {
            List<dynamic> DynamicHomecellAttFeedback = new List<dynamic>();
            //foreach method ro retrieve data from database and add it to list to return
            foreach (var HomecellAttFeedback in HomecellAtt)
            {
                //create new dynamic object 
                dynamic DynamicHomecellAtt = new ExpandoObject();
                DynamicHomecellAtt.HomecellAttendanceGoalID = HomecellAttFeedback.HomecellAttendanceGoalID;
                DynamicHomecellAtt.Date = HomecellAttFeedback.Date;
                DynamicHomecellAtt.Members = HomecellAttFeedback.Members;
                DynamicHomecellAtt.Leaders = HomecellAttFeedback.Leaders;
                DynamicHomecellAtt.Visitors = HomecellAttFeedback.Visitors;
                DynamicHomecellAtt.FirstTimeVisitors = HomecellAttFeedback.FirstTimeVisitors;
                DynamicHomecellAtt.Salvations = HomecellAttFeedback.Salvations;
                DynamicHomecellAttFeedback.Add(DynamicHomecellAtt); // add to dynamic list
            }
            return DynamicHomecellAttFeedback;
        }

        [System.Web.Http.Route("api/Feedback/getAllZoneHomecellAttFeedback")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllZoneHomecellAttFeedback()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getZoneHomecellAtt(db.Zone_Homecell_Attendance_Feedback.ToList()); // return called method
        }

        public List<dynamic> getZoneHomecellAtt(List<Zone_Homecell_Attendance_Feedback> ZoneHomecellAtt)
        {
            List<dynamic> DynamicZoneHomecellAttFeedback = new List<dynamic>();
            //foreach method ro retrieve data from database and add it to list to return
            foreach (var ZoneHomecellAttFeedback in ZoneHomecellAtt)
            {
                //create new dynamic object 
                dynamic DynamicHomecellAtt = new ExpandoObject();
                DynamicHomecellAtt.Date = ZoneHomecellAttFeedback.Date; //update data with parameter data
                DynamicHomecellAtt.Members = ZoneHomecellAttFeedback.Member;
                DynamicHomecellAtt.Leaders = ZoneHomecellAttFeedback.Leader;
                DynamicHomecellAtt.Visitors = ZoneHomecellAttFeedback.Visitors;
                DynamicHomecellAtt.FirstTimeVisitors = ZoneHomecellAttFeedback.FirstTimeVisitors;
                DynamicHomecellAtt.Salvations = ZoneHomecellAttFeedback.Salvations;
                DynamicZoneHomecellAttFeedback.Add(DynamicHomecellAtt); // add to dynamic list
            }
            return DynamicZoneHomecellAttFeedback;
        }
    }
}

