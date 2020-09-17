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
using System.IO;

namespace RC_API.Controllers
{
    public class OrganisationalStructurePositionController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //3.15 Add Organisational structure position -Charl

        [System.Web.Http.Route("api/OrganisationalStructurePosition/CreateOrgStructPos")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> CreateOrgStructPos([FromBody] Organisational_Structure_Position NewPosition) //get JSON parameter
        {
            //validate that there is no null values
            if (NewPosition != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    db.Organisational_Structure_Position.Add(NewPosition); //add new customer to customer table

                   Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Organisational Structure Position with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //Save nchanges and Add new position
                }
                catch (Exception e)
                {

                }

                return getOrgStructPos(db.Organisational_Structure_Position.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        //3.16 Assign Organisational structure position -Charl
        [System.Web.Http.Route("api/OrganisationalStructurePosition/AssignOrgStructPos")] //create route for api
        [System.Web.Mvc.HttpPost]
        public List<dynamic> AssignOrgStructPos([FromBody] Organisational_Structure_Position positionAssignInfo)
        {

            if (positionAssignInfo != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                Organisational_Structure_Position OrgStructPosition = db.Organisational_Structure_Position.Where(x => x.OrgStructID == positionAssignInfo.OrgStructID).FirstOrDefault();

                try
                {
                    OrgStructPosition.PersonID = positionAssignInfo.PersonID;
                    OrgStructPosition.OrgGroupID = positionAssignInfo.OrgGroupID;
                    OrgStructPosition.OrgGroupID1 = positionAssignInfo.OrgGroupID1;
                    OrgStructPosition.OrgGroupID2 = positionAssignInfo.OrgGroupID2;
                    OrgStructPosition.OrgGroupID3 = positionAssignInfo.OrgGroupID3;
                    db.SaveChanges(); //Save nchanges and Add new position
                }
                catch (Exception e)
                {

                }


                return getOrgStructPos(db.Organisational_Structure_Position.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        [System.Web.Http.Route("api/OrganisationalStructurePosition/Person")] //create route for api
        [System.Web.Mvc.HttpPost]
        public dynamic Person([FromBody] Person personSearch)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
            string[] nameSurname = personSearch.Name.Split(' ');
            string name = nameSurname[0];
            string surname = nameSurname[1];


            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data


            return PersonInfo(db.People.Where(z => z.Name == name && z.Surname == surname).FirstOrDefault());

        }
        public dynamic PersonInfo(Person PersonList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

            dynamic dynamicOrgStructPositionList = new ExpandoObject();
            dynamic dynamicPerson = new ExpandoObject();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return

                //Person pers = db.People.Where(z => z.PersonID == personn.PersonID 
                //|| z.Name == personn.Name || z.Name == personn.Surname || z.Name == personn.Name && z.Name == personn.Surname).FirstOrDefault();
                //Organisational_Individual_Position getIndivPos = db.Organisational_Individual_Position.Where(z => z.OrgIndivPosID == Position.OrgIndivPosID).FirstOrDefault();


                //create new dynamic object 

                dynamicPerson.PersonID = PersonList.PersonID;
                dynamicPerson.Name = PersonList.Name;
                dynamicPerson.Surname = PersonList.Surname;
            }
            catch (Exception e)
            {

            }


            return dynamicPerson;
        }

        //3.17 View Organisational structure position -Charl
        [System.Web.Http.Route("api/OrganisationalStructurePosition/getAllViewOrgStructPos")] //create route for api
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllViewOrgStructPos()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

            return getOrgStructPos(db.Organisational_Structure_Position.ToList()); // return called method
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

        //get Organisational structure type
        [System.Web.Http.Route("api/OrganisationalStructurePosition/getStructType")] //create route for api
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getStructType()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

            return getOrgStructTYpe(db.Organisational_Structure_Type.ToList()); // return called method
        }
        public List<dynamic> getOrgStructTYpe(List<Organisational_Structure_Type> typeList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

            List<dynamic> dynamicOrgStructTypeList = new List<dynamic>();

            try
            {
                //foreach method ro retrieve data from database and add it to list to return
                foreach (var type in typeList)
                {

                    //create new dynamic object 
                    dynamic dynamicOrgStructType = new ExpandoObject();
                    dynamicOrgStructType.OrgStructTypeID = type.OrgStructTypeID;
                    dynamicOrgStructType.Description = type.Description;

                    // dynamicOrgStructPosition.OrgGroupList = Position.Organisational_Group;
                    dynamicOrgStructTypeList.Add(dynamicOrgStructType); // add to dynamic list
                }
            }
            catch (Exception)
            {

            }


            return dynamicOrgStructTypeList;
        }

        //3.18 Maintain Organisational structure position -Charl
        [System.Web.Http.Route("api/OrganisationalStructurePosition/UpdateOrgStructPos")] //create route for api
        [System.Web.Mvc.HttpPost]

        public List<dynamic> UpdateOrgStructPos([FromBody] Organisational_Structure_Position UpdatedPosition) //get JSON parameter
        {
            //validate that there is no null values
            if (UpdatedPosition != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection

                db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data

                try
                {
                    Organisational_Structure_Position OrgStructPosition = db.Organisational_Structure_Position.Where(x => x.OrgStructID == UpdatedPosition.OrgStructID).FirstOrDefault();
                    OrgStructPosition.OrgIndivPosID = UpdatedPosition.OrgIndivPosID;
                    OrgStructPosition.OrgStructLevel = UpdatedPosition.OrgStructLevel;
                    OrgStructPosition.OrgStructIDReportsTo = UpdatedPosition.OrgStructIDReportsTo;
                    OrgStructPosition.Description = UpdatedPosition.Description;

                   Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated Organisational Structure Position with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges(); //Save nchanges and Add new position
                }
                catch (Exception e)
                {

                }

                return getOrgStructPos(db.Organisational_Structure_Position.ToList()); // return called method
            }
            else
            {
                return null;
            }
        }

        [System.Web.Http.Route("api/OrganisationalStructurePosition/RemoveOrganisationalStructurePositionD")] //create route for api
        [System.Web.Mvc.HttpDelete]


        public List<dynamic> RemoveOrganisationalStructurePositionD([FromBody] Organisational_Structure_Position orgStructPos) //get JSON parameter
        {
            //validate that there is no null values
            if (orgStructPos != null)
            {
                ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3(); //establish database connection
                db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of data

                try
                {
                    Organisational_Structure_Position orgStructPosDelete = db.Organisational_Structure_Position.Where(z => z.OrgStructID == orgStructPos.OrgStructID).FirstOrDefault(); //return record based on ID
                    db.Organisational_Structure_Position.Remove(orgStructPosDelete); //remove record retrieved from customer table
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }


                return getAllViewOrgStructPos();
            }
            else
            {
                return null;
            }
        }

        [System.Web.Http.Route("api/OrganisationalStructurePosition/HomecellNotes")] //create route for api
        [System.Web.Mvc.HttpPost]

        public void HomecellNotes(string fileName) //get JSON parameter
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();//establish database connection
            db.Configuration.ProxyCreationEnabled = false; //configure proxy to eliminate overload of data
            string location = "C:/Users/Charl-Christiaan/Documents/";

            try
            {
                using (Stream stream = File.OpenRead(location + fileName))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);


                    dynamic HomecellNotesAdd = new ExpandoObject();
                    HomecellNotesAdd.HomecellNotes = buffer;
                    HomecellNotesAdd.UploadDate = DateTime.Now;


                    db.Homecell_Notes.Add(HomecellNotesAdd);
                }
            }
            catch (Exception e)
            {

            }


        }
    }
}
