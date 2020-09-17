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

namespace RC_API.Controllers
{
    public class GoalsController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //*********CRUD GOALS START************//

        //Homecell Attendance Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetHomecellAttGoal([FromBody] Homecell_Attendance_Goal newHomecellAtt) //get JSON parameter
        {
            //validate that there is no null values
            if (newHomecellAtt != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Homecell_Attendance_Goal.Add(newHomecellAtt); //add new Homecell attenance goal

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Homecell Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getHomecellAtt(db.Homecell_Attendance_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }
        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateHomecellAttGoal([FromBody] Homecell_Attendance_Goal HomecellAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (HomecellAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Homecell_Attendance_Goal HomecellAtt = db.Homecell_Attendance_Goal.Where(z => z.HomecellAttendanceGoalID == HomecellAttGoal.HomecellAttendanceGoalID).FirstOrDefault(); //retrieve record to update data
                    HomecellAtt.Date = HomecellAttGoal.Date; //update data with parameter data
                    HomecellAtt.Members = HomecellAttGoal.Members;
                    HomecellAtt.Leaders = HomecellAttGoal.Leaders;
                    HomecellAtt.Visitors = HomecellAttGoal.Visitors;
                    HomecellAtt.FirstTimeVisitors = HomecellAttGoal.FirstTimeVisitors;
                    HomecellAtt.Overseer = HomecellAttGoal.Overseer;
                    HomecellAtt.Salvations = HomecellAttGoal.Salvations;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Homecell Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }

                return getAllHomecellAttGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getAllHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllHomecellAttGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getHomecellAtt(db.Homecell_Attendance_Goal.ToList()); // return called method
        }

        public List<dynamic> getHomecellAtt(List<Homecell_Attendance_Goal> HomecellAtt)
        {
            List<dynamic> DynamicHomecellAttGoal = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var HomecellAttGoal in HomecellAtt)
                {
                    //create new dynamic object 
                    dynamic DynamicHomecellAtt = new ExpandoObject();
                    DynamicHomecellAtt.HomecellAttendanceGoalID = HomecellAttGoal.HomecellAttendanceGoalID;
                    DynamicHomecellAtt.Date = HomecellAttGoal.Date;
                    DynamicHomecellAtt.Members = HomecellAttGoal.Members;
                    DynamicHomecellAtt.Leaders = HomecellAttGoal.Leaders;
                    DynamicHomecellAtt.Visitors = HomecellAttGoal.Visitors;
                    DynamicHomecellAtt.FirstTimeVisitors = HomecellAttGoal.FirstTimeVisitors;
                    DynamicHomecellAtt.Overseer = HomecellAttGoal.Overseer;
                    DynamicHomecellAtt.Salvations = HomecellAttGoal.Salvations;
                    DynamicHomecellAttGoal.Add(DynamicHomecellAtt); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }

            return DynamicHomecellAttGoal;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/RemoveHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpDelete]

        public List<dynamic> RemoveHomecellAttGoal([FromBody] Homecell_Attendance_Goal HomecellAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (HomecellAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {

                    Homecell_Attendance_Goal HomecellAtt = db.Homecell_Attendance_Goal.Where(z => z.HomecellAttendanceGoalID == HomecellAttGoal.HomecellAttendanceGoalID).FirstOrDefault(); //return record based on ID
                    db.Homecell_Attendance_Goal.Remove(HomecellAtt); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed Homecell Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getAllHomecellAttGoal();
            }
            else
            {
                return null;
            }
        }

        //Church Attenedance Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetChurchAttGoal([FromBody] Church_Attendance_Goal newchurchAtt) //get JSON parameter
        {
            //validate that there is no null values
            if (newchurchAtt != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Church_Attendance_Goal.Add(newchurchAtt); //add new church attenance goals

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }



                return getChurchAtt(db.Church_Attendance_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }
        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateChurchAttGoal([FromBody] Church_Attendance_Goal ChurchAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ChurchAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Church_Attendance_Goal ChurchAtt = db.Church_Attendance_Goal.Where(z => z.ChurchAttGoalID == ChurchAttGoal.ChurchAttGoalID).FirstOrDefault(); //retrieve record to update data
                    ChurchAtt.Date = ChurchAttGoal.Date; //update data with parameter data
                    ChurchAtt.Member = ChurchAttGoal.Member;
                    ChurchAtt.Leader = ChurchAttGoal.Leader;
                    ChurchAtt.Visitors = ChurchAttGoal.Visitors;
                    ChurchAtt.FirstTimeVisitors = ChurchAttGoal.FirstTimeVisitors;
                    ChurchAtt.Overseer = ChurchAttGoal.Overseer;
                    ChurchAtt.Salvations = ChurchAttGoal.Salvations;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getAllChurchAttGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getAllChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllChurchAttGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getChurchAtt(db.Church_Attendance_Goal.ToList()); // return called method
        }

        public List<dynamic> getChurchAtt(List<Church_Attendance_Goal> ChurchAtt)
        {
            List<dynamic> DynamicChurchAttGoal = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var ChurchAttGoal in ChurchAtt)
                {
                    //create new dynamic object 
                    dynamic DynamicChurchAtt = new ExpandoObject();
                    DynamicChurchAtt.Date = ChurchAttGoal.Date; //update data with parameter data
                    DynamicChurchAtt.Member = ChurchAttGoal.Member;
                    DynamicChurchAtt.Leader = ChurchAttGoal.Leader;
                    DynamicChurchAtt.Visitors = ChurchAttGoal.Visitors;
                    DynamicChurchAtt.FirstTimeVisitors = ChurchAttGoal.FirstTimeVisitors;
                    DynamicChurchAtt.Overseer = ChurchAttGoal.Overseer;
                    DynamicChurchAtt.Salvations = ChurchAttGoal.Salvations;
                    DynamicChurchAttGoal.Add(DynamicChurchAtt); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }

            return DynamicChurchAttGoal;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteChurchAttGoal([FromBody] Church_Attendance_Goal ChurchAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ChurchAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {
                    Church_Attendance_Goal ChurchAtt = db.Church_Attendance_Goal.Where(z => z.ChurchAttGoalID == ChurchAttGoal.ChurchAttGoalID).FirstOrDefault(); //return record based on ID
                    db.Church_Attendance_Goal.Remove(ChurchAtt); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getAllChurchAttGoal();
            }
            else
            {
                return null;
            }
        }


        //Zone Homecell Attenance Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetZoneHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetZoneHomecellAttGoal([FromBody] Zone_Homecell_Attendance_Goal newZoneHomecellAtt) //get JSON parameter
        {
            //validate that there is no null values
            if (newZoneHomecellAtt != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Zone_Homecell_Attendance_Goal.Add(newZoneHomecellAtt); //add new Zone homecell attendance goal

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Zone Homecell Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }



                return getZoneHomecellAtt(db.Zone_Homecell_Attendance_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateZoneHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateZoneHomecellAttGoal([FromBody] Zone_Homecell_Attendance_Goal ZoneHomecellAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ZoneHomecellAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Zone_Homecell_Attendance_Goal ZoneHomecellAtt = db.Zone_Homecell_Attendance_Goal.Where(z => z.ZoneHomecellAttGoalID == ZoneHomecellAttGoal.ZoneHomecellAttGoalID).FirstOrDefault(); //retrieve record to update data
                    ZoneHomecellAtt.Date = ZoneHomecellAttGoal.Date; //update data with parameter data
                    ZoneHomecellAtt.Members = ZoneHomecellAttGoal.Members;
                    ZoneHomecellAtt.Leaders = ZoneHomecellAttGoal.Leaders;
                    ZoneHomecellAtt.Visitors = ZoneHomecellAttGoal.Visitors;
                    ZoneHomecellAtt.FirstTimeVisitors = ZoneHomecellAttGoal.FirstTimeVisitors;
                    ZoneHomecellAtt.Overseer = ZoneHomecellAttGoal.Overseer;
                    ZoneHomecellAtt.Salvations = ZoneHomecellAttGoal.Salvations;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Zone Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getAllZoneHomecellAttGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getAllZoneHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllZoneHomecellAttGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getZoneHomecellAtt(db.Zone_Homecell_Attendance_Goal.ToList()); // return called method
        }

        public List<dynamic> getZoneHomecellAtt(List<Zone_Homecell_Attendance_Goal> ZoneHomecellAtt)
        {
            List<dynamic> DynamicZoneHomecellAttGoal = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var ZoneHomecellAttGoal in ZoneHomecellAtt)
                {
                    //create new dynamic object 
                    dynamic DynamicHomecellAtt = new ExpandoObject();
                    DynamicHomecellAtt.Date = ZoneHomecellAttGoal.Date; //update data with parameter data
                    DynamicHomecellAtt.Members = ZoneHomecellAttGoal.Members;
                    DynamicHomecellAtt.Leaders = ZoneHomecellAttGoal.Leaders;
                    DynamicHomecellAtt.Visitors = ZoneHomecellAttGoal.Visitors;
                    DynamicHomecellAtt.FirstTimeVisitors = ZoneHomecellAttGoal.FirstTimeVisitors;
                    DynamicHomecellAtt.Overseer = ZoneHomecellAttGoal.Overseer;
                    DynamicHomecellAtt.Salvations = ZoneHomecellAttGoal.Salvations;
                    DynamicZoneHomecellAttGoal.Add(DynamicHomecellAtt); // add to dynamic list
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return DynamicZoneHomecellAttGoal;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteZoneHomecellAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteZoneHomecellAttGoal([FromBody] Zone_Homecell_Attendance_Goal ZoneHomecellAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ZoneHomecellAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {
                    Zone_Homecell_Attendance_Goal ZoneHomecellAtt = db.Zone_Homecell_Attendance_Goal.Where(z => z.ZoneHomecellAttGoalID == ZoneHomecellAttGoal.ZoneHomecellAttGoalID).FirstOrDefault(); //return record based on ID
                    db.Zone_Homecell_Attendance_Goal.Remove(ZoneHomecellAtt); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getAllZoneHomecellAttGoal();
            }
            else
            {
                return null;
            }
        }

        //Zone Church Attenance Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetZoneChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetZoneChurchAttGoal([FromBody] Zone_Church_Attendance_Goal newZoneChurchAtt) //get JSON parameter
        {
            //validate that there is no null values
            if (newZoneChurchAtt != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Zone_Church_Attendance_Goal.Add(newZoneChurchAtt); //add new Zone church attendance goal

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Zone Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getZoneChurchAtt(db.Zone_Church_Attendance_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateZoneChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateZoneChurchAttGoal([FromBody] Zone_Church_Attendance_Goal ZoneChurchAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ZoneChurchAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Zone_Church_Attendance_Goal ZoneChurchAtt = db.Zone_Church_Attendance_Goal.Where(z => z.ZoneChurchAttGoalID == ZoneChurchAttGoal.ZoneChurchAttGoalID).FirstOrDefault(); //retrieve record to update data
                    ZoneChurchAtt.Date = ZoneChurchAttGoal.Date; //update data with parameter data
                    ZoneChurchAtt.Member = ZoneChurchAttGoal.Member;
                    ZoneChurchAtt.Leader = ZoneChurchAttGoal.Leader;
                    ZoneChurchAtt.Visitors = ZoneChurchAttGoal.Visitors;
                    ZoneChurchAtt.FirstTimeVisitors = ZoneChurchAttGoal.FirstTimeVisitors;
                    ZoneChurchAtt.Overseer = ZoneChurchAttGoal.Overseer;
                    ZoneChurchAtt.Salvations = ZoneChurchAttGoal.Salvations;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Zone Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getAllZoneChurchAttGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getAllZoneChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllZoneChurchAttGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getZoneChurchAtt(db.Zone_Church_Attendance_Goal.ToList()); // return called method
        }

        public List<dynamic> getZoneChurchAtt(List<Zone_Church_Attendance_Goal> ZoneChurchAtt)
        {
            List<dynamic> DynamicZoneChurchAttGoal = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var ZoneChurchAttGoal in ZoneChurchAtt)
                {
                    //create new dynamic object 
                    dynamic DynamicChurchAtt = new ExpandoObject();
                    DynamicChurchAtt.Date = ZoneChurchAttGoal.Date; //update data with parameter data
                    DynamicChurchAtt.Member = ZoneChurchAttGoal.Member;
                    DynamicChurchAtt.Leader = ZoneChurchAttGoal.Leader;
                    DynamicChurchAtt.Visitors = ZoneChurchAttGoal.Visitors;
                    DynamicChurchAtt.FirstTimeVisitors = ZoneChurchAttGoal.FirstTimeVisitors;
                    DynamicChurchAtt.Overseer = ZoneChurchAttGoal.Overseer;
                    DynamicChurchAtt.Salvations = ZoneChurchAttGoal.Salvations;
                    DynamicZoneChurchAttGoal.Add(DynamicChurchAtt); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }

            return DynamicZoneChurchAttGoal;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteZoneChurchAttGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteZoneChurchAttGoal([FromBody] Zone_Church_Attendance_Goal ZoneChurchAttGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ZoneChurchAttGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {

                    Zone_Church_Attendance_Goal ZoneChurchAtt = db.Zone_Church_Attendance_Goal.Where(z => z.ZoneChurchAttGoalID == ZoneChurchAttGoal.ZoneChurchAttGoalID).FirstOrDefault(); //return record based on ID
                    db.Zone_Church_Attendance_Goal.Remove(ZoneChurchAtt); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed Zone Church Attendance Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getAllZoneChurchAttGoal();
            }
            else
            {
                return null;
            }
        }

        //New Member Orientation Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetNMOGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetNMOGoal([FromBody] NMO_Goal newNMO) //get JSON parameter
        {
            //validate that there is no null values
            if (newNMO != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.NMO_Goal.Add(newNMO); //add new salvation to Salvations table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created New Members Orientation Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getNMO(db.NMO_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateNMOGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateNMOGoal([FromBody] NMO_Goal NMOGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (NMOGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    NMO_Goal NMO = db.NMO_Goal.Where(z => z.NMOGoalID == NMOGoal.NMOGoalID).FirstOrDefault(); //retrieve record to update data
                    NMO.MonthTotal = NMOGoal.MonthTotal; //update data with parameter data
                    NMO.MonthTotal = NMOGoal.MonthTotal;
                    NMO.Overseer = NMOGoal.Overseer;
                    NMO.Date = NMOGoal.Date;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated New Members Orientation Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getAllNMOGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getAllNMOGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getAllNMOGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getNMO(db.NMO_Goal.ToList()); // return called method
        }

        public List<dynamic> getNMO(List<NMO_Goal> NMOGoals)
        {
            List<dynamic> DynamicNMOGoal = new List<dynamic>();

            try
            {
                foreach (var NMOGoal in NMOGoals)
                {
                    //create new dynamic object 
                    dynamic DynamicNMO = new ExpandoObject();
                    DynamicNMO.MonthTotal = NMOGoal.MonthTotal; //update data with parameter data
                    DynamicNMO.MonthTotal = NMOGoal.MonthTotal;
                    DynamicNMO.Overseer = NMOGoal.Overseer;
                    DynamicNMO.Date = NMOGoal.Date;
                    DynamicNMOGoal.Add(DynamicNMO); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }
            //foreach method ro retrieve data from database and add it to list to return

            return DynamicNMOGoal;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteNMOGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteNMOGoal([FromBody] NMO_Goal NMOGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (NMOGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {
                    NMO_Goal NMO = db.NMO_Goal.Where(z => z.NMOGoalID == NMOGoal.NMOGoalID).FirstOrDefault(); //return record based on ID
                    db.NMO_Goal.Remove(NMO); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed New Members Orientation Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getAllNMOGoal();
            }
            else
            {
                return null;
            }
        }

        //Discipleship Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetDiscipleshipGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetDiscipleshipGoal([FromBody] Discipleship_Goal newDisicpleshipGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (newDisicpleshipGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Discipleship_Goal.Add(newDisicpleshipGoal); //add new discipleship goal

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Discipleship Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getDiscipleship(db.Discipleship_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }
        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateDiscipleshipGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateDiscipleshipGoal([FromBody] Discipleship_Goal DiscipleshipGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (DiscipleshipGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Discipleship_Goal Discipleship = db.Discipleship_Goal.Where(z => z.DiscipleshipGoalID == DiscipleshipGoal.DiscipleshipGoalID).FirstOrDefault(); //retrieve record to update data
                    Discipleship.Description = DiscipleshipGoal.Description; //update data with parameter data
                    Discipleship.DiscipleshipType = DiscipleshipGoal.DiscipleshipType;
                    Discipleship.Attendance = DiscipleshipGoal.Attendance;
                    Discipleship.Overseer = DiscipleshipGoal.Overseer;
                    Discipleship.Date = DiscipleshipGoal.Date;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Discipleship Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getDiscipleshipGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getDiscipleshipGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getDiscipleshipGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getDiscipleship(db.Discipleship_Goal.ToList()); // return called method
        }

        public List<dynamic> getDiscipleship(List<Discipleship_Goal> discipleshipGoals)
        {
            List<dynamic> DynamicdiscipleshipGoals = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var discipleshipGoal in discipleshipGoals)
                {
                    //create new dynamic object 
                    dynamic Dynamicdiscipleship = new ExpandoObject();

                    Dynamicdiscipleship.Description = discipleshipGoal.Description; //update data with parameter data
                    Dynamicdiscipleship.DiscipleshipType = discipleshipGoal.DiscipleshipType;
                    Dynamicdiscipleship.Attendance = discipleshipGoal.Attendance;
                    Dynamicdiscipleship.Overseer = discipleshipGoal.Overseer;
                    Dynamicdiscipleship.Date = discipleshipGoal.Date;

                    DynamicdiscipleshipGoals.Add(Dynamicdiscipleship); // add to dynamic list
                }
            }
            catch (Exception e)
            {

                throw;
            }

            return DynamicdiscipleshipGoals;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteDiscipleshipGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteDiscipleshipGoal([FromBody] Discipleship_Goal DiscipleshipGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (DiscipleshipGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {
                    Discipleship_Goal DeleteDiscipleship = db.Discipleship_Goal.Where(z => z.DiscipleshipGoalID == DiscipleshipGoal.DiscipleshipGoalID).FirstOrDefault(); //return record based on ID
                    db.Discipleship_Goal.Remove(DeleteDiscipleship); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed Discipleship Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                    throw;
                }


                return getDiscipleshipGoal();
            }
            else
            {
                return null;
            }
        }


        //Structure Growth Goal
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetStructureGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetStructureGrowthGoal([FromBody] Structure_Growth_Goal newStructureGrowth) //get JSON parameter
        {
            //validate that there is no null values
            if (newStructureGrowth != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Structure_Growth_Goal.Add(newStructureGrowth); //add new structure growth goal

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Structure Growth Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getStructureGrowth(db.Structure_Growth_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }
        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateStructureGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateStructureGrowthGoal([FromBody] Structure_Growth_Goal StructureGrowthGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (StructureGrowthGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Structure_Growth_Goal StructureGrowth = db.Structure_Growth_Goal.Where(z => z.StructureGrowthGoalID == StructureGrowthGoal.StructureGrowthGoalID).FirstOrDefault(); //retrieve record to update data
                    StructureGrowth.Description = StructureGrowthGoal.Description; //update data with parameter data
                    StructureGrowth.Members = StructureGrowthGoal.Members;
                    StructureGrowth.Overseer = StructureGrowthGoal.Overseer;
                    StructureGrowth.Date = StructureGrowthGoal.Date;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Structure Growth Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }

                return getStructureGrowthGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getStructureGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getStructureGrowthGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getStructureGrowth(db.Structure_Growth_Goal.ToList()); // return called method
        }

        public List<dynamic> getStructureGrowth(List<Structure_Growth_Goal> StructureGrowthGoals)
        {
            List<dynamic> DynamicStructureGrowthGoals = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var StructureGrowthGoal in StructureGrowthGoals)
                {
                    //create new dynamic object 
                    dynamic DynamicStructureGrowth = new ExpandoObject();

                    DynamicStructureGrowth.Description = StructureGrowthGoal.Description;
                    DynamicStructureGrowth.Members = StructureGrowthGoal.Members;
                    DynamicStructureGrowth.Overseer = StructureGrowthGoal.Overseer;
                    DynamicStructureGrowth.Date = StructureGrowthGoal.Date;

                    DynamicStructureGrowthGoals.Add(DynamicStructureGrowth); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }

            return DynamicStructureGrowthGoals;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteStructureGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteStructureGrowthGoal([FromBody] Structure_Growth_Goal StructureGrowthGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (StructureGrowthGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {
                    Structure_Growth_Goal DeleteStructureGrowth = db.Structure_Growth_Goal.Where(z => z.StructureGrowthGoalID == StructureGrowthGoal.StructureGrowthGoalID).FirstOrDefault(); //return record based on ID
                    db.Structure_Growth_Goal.Remove(DeleteStructureGrowth); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Removed Structure Growth Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getStructureGrowthGoal();
            }
            else
            {
                return null;
            }
        }

        //Zone Growth Goal 
        //Set weekly Goal
        [System.Web.Http.Route("api/Goals/SetZoneGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> SetZoneGrowthGoal([FromBody] Zone_Growth_Goal newZoneGrowthGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (newZoneGrowthGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Zone_Growth_Goal.Add(newZoneGrowthGoal); //add new salvation to Salvations table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Zone Growth Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getZoneGrowth(db.Zone_Growth_Goal.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }
        //Update Weekly Goal
        [System.Web.Http.Route("api/Goals/UpdateZoneGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateZoneGrowthGoal([FromBody] Zone_Growth_Goal ZoneGrowthGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ZoneGrowthGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Zone_Growth_Goal ZoneGrowth = db.Zone_Growth_Goal.Where(z => z.ZonegrowthGoalID == ZoneGrowthGoal.ZonegrowthGoalID).FirstOrDefault(); //retrieve record to update data
                    ZoneGrowth.Description = ZoneGrowthGoal.Description; //update data with parameter data
                    ZoneGrowth.Members = ZoneGrowthGoal.Members;
                    ZoneGrowth.Overseer = ZoneGrowthGoal.Overseer;
                    ZoneGrowth.Date = ZoneGrowthGoal.Date;

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Zone Growth Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //save changes 
                }
                catch (Exception e)
                {

                }


                return getZoneGrowthGoal();
            }
            else
            {
                return null;
            }
        }
        //Search Weekly Goal
        [System.Web.Http.Route("api/Goals/getZoneGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> getZoneGrowthGoal()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); // create database connection
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory
            return getZoneGrowth(db.Zone_Growth_Goal.ToList()); // return called method
        }

        public List<dynamic> getZoneGrowth(List<Zone_Growth_Goal> ZoneGrowthGoals)
        {
            List<dynamic> DynamicZoneGrowthGoals = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var ZoneGrowthGoal in ZoneGrowthGoals)
                {
                    //create new dynamic object 
                    dynamic DynamicZoneGrowth = new ExpandoObject();

                    DynamicZoneGrowth.Description = ZoneGrowthGoal.Description;
                    DynamicZoneGrowth.Members = ZoneGrowthGoal.Members;
                    DynamicZoneGrowth.Overseer = ZoneGrowthGoal.Overseer;
                    DynamicZoneGrowth.Date = ZoneGrowthGoal.Date;

                    DynamicZoneGrowthGoals.Add(DynamicZoneGrowth); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }

            return DynamicZoneGrowthGoals;
        }
        //Delete Weekly Goal
        [System.Web.Http.Route("api/Goals/DeleteZoneGrowthGoal")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> DeleteZoneGrowthGoal([FromBody] Zone_Growth_Goal ZoneGrowthGoal) //get JSON parameter
        {
            //validate that there is no null values
            if (ZoneGrowthGoal != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {

                    Zone_Growth_Goal DeleteZoneGrowth = db.Zone_Growth_Goal.Where(z => z.ZonegrowthGoalID == ZoneGrowthGoal.ZonegrowthGoalID).FirstOrDefault(); //return record based on ID
                    db.Zone_Growth_Goal.Remove(DeleteZoneGrowth); //remove record retrieved from customer table

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Reoved Zone Growth Goal with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

                return getZoneGrowthGoal();
            }
            else
            {
                return null;
            }
        }

        //3.17 View Organisational structure position -Charl
        [System.Web.Http.Route("api/OrganisationalStructurePosition/getViewOrgStructPos")] //create route for api
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getViewOrgStructPos()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

            return getOrgStructPos(db.Organisational_Structure_Position.Where(z => z.OrgIndivPosID == 43).ToList()); // return called method
        }

        public List<dynamic> getOrgStructPos(List<Organisational_Structure_Position> PositionList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

            List<dynamic> dynamicOrgStructPositionList = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var Position in PositionList)
                {
                    Organisational_Structure_Type getStructureType = db.Organisational_Structure_Type.Where(z => z.OrgStructTypeID == Position.OrgStructTypeID).FirstOrDefault();
                    Organisational_Individual_Position getIndivPos = db.Organisational_Individual_Position.Where(z => z.OrgIndivPosID == Position.OrgIndivPosID).FirstOrDefault();

                    string orgStructType = getStructureType.Description;
                    string IndivPos = getIndivPos.Decription;

                    //create new dynamic object 
                    dynamic dynamicOrgStructPosition = new ExpandoObject();
                    dynamicOrgStructPosition.PersonID = Position.PersonID;
                    dynamicOrgStructPosition.OrgStructType = orgStructType;
                    dynamicOrgStructPosition.OrgSTructReportTo = Position.OrgStructIDReportsTo;
                    dynamicOrgStructPosition.Description = Position.Description;
                    dynamicOrgStructPosition.orgGroup = db.Organisational_Group.Where(x => x.OrgGroupID == Position.OrgGroupID).ToList();
                    dynamicOrgStructPosition.OrgStructLevel = Position.OrgStructLevel;
                    dynamicOrgStructPosition.OrgIndivPos = IndivPos;
                    dynamicOrgStructPosition.OrgStructID = Position.OrgStructID;

                    // dynamicOrgStructPosition.OrgGroupList = Position.Organisational_Group;
                    dynamicOrgStructPositionList.Add(dynamicOrgStructPosition); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }

            return dynamicOrgStructPositionList;
        }
    }
}
