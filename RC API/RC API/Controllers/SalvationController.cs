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
    public class SalvationController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //1.5 Add Salvation information -Charl

        [System.Web.Http.Route("api/Salvation/addSalvationInformation")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> addSalvationInformation([FromBody] Salvation newSalvation) //get JSON parameter
        {
            //validate that there is no null values
            if (newSalvation != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    //Set date before saving to database
                    newSalvation.Date = DateTime.Today;
                    //Set follow-up values to false
                    newSalvation.FollowedUp = false;
                    newSalvation.NoAnswer = false;
                    db.Salvations.Add(newSalvation); //add new salvation to Salvations table
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getSalvationInformation(db.Salvations.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        //Get method to return new list of salvations after a salvation was added
        public List<dynamic> getSalvationInformation(List<Salvation> SalvationTable)
        {
            List<dynamic> dynamicSalvationList = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var Visitor in SalvationTable)
                {
                    //create new dynamic object 
                    dynamic dynamicSalvation = new ExpandoObject();
                    dynamicSalvation.SalID = Visitor.SalID;
                    dynamicSalvation.Date = Visitor.Date;
                    dynamicSalvation.AlterWorker = Visitor.AlterWorker;
                    dynamicSalvation.Name = Visitor.Name;
                    dynamicSalvation.Surname = Visitor.Surname;
                    dynamicSalvation.Age = Visitor.Age;
                    dynamicSalvation.EmploymentStatus = Visitor.EmploymentStatus;
                    dynamicSalvation.MaritialStatus = Visitor.MaritualStatus;
                    dynamicSalvation.ResidentialAddress = Visitor.ResidentialAddress;
                    dynamicSalvation.Suburb = Visitor.Suburb;
                    dynamicSalvation.City = Visitor.City;
                    dynamicSalvation.HomeTelNo = Visitor.HomeTelNo;
                    dynamicSalvation.WorkTelNo = Visitor.WorkTelNo;
                    dynamicSalvation.Cellphone = Visitor.CellPhone;
                    dynamicSalvation.Email = Visitor.Email;
                    dynamicSalvation.Invited = Visitor.Invited;
                    dynamicSalvation.NameSurnameInvite = Visitor.NameSurnameInvite;
                    dynamicSalvation.HomecellLeader = Visitor.HomecellLeader;
                    dynamicSalvation.ZonePastor = Visitor.ZonePastor;
                    dynamicSalvation.StudyAddress = Visitor.StudyAddress;
                    dynamicSalvation.ParentGuardianCell = Visitor.ParentGuardianCell;
                    dynamicSalvation.PrayerRequest = Visitor.PrayerRequest;
                    dynamicSalvation.SchoolLevel = Visitor.SchoolLevel;
                    dynamicSalvation.NameofSchool = Visitor.NameofSchool;
                    dynamicSalvation.Grade = Visitor.Grade;
                    dynamicSalvation.StudyYear = Visitor.StudyYear;
                    dynamicSalvation.Institution = Visitor.Institution;
                    dynamicSalvation.FollowedUp = Visitor.FollowedUp;
                    dynamicSalvation.NoAnswer = Visitor.NoAnswer;
                    dynamicSalvationList.Add(dynamicSalvation); // add to dynamic list
                }
            }
            catch (Exception e)
            {

            }



            return dynamicSalvationList; //return list
        }

    }
}

