using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.Cors;
using RC_API.Models;
using System.Dynamic;
using System.Data.Entity;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Runtime.CompilerServices;

namespace RC_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MembersController : ApiController
    {
        //*********Members START************//

        //Retrieve all Members from person table to view the Members and to approve the Members
        [System.Web.Http.Route("api/Members/getAllMembers")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllMembers()
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            // !!--User Management--!!
            //string sessionId = Request.Headers.Authorization.ToString();
            //var user = db.Where(o => o.SessionID == sessionId).FirstOrDefault();
            //if(user != null)

            try
            {
                return getAllMembersReturnList(db.People.Where(a => a.Activation_Status_ID == 1).ToList());
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e;
                return toReturn;
            }
        }

        public List<dynamic> getAllMembersReturnList(List<Person> allPeople)
        {
            //Database conncection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicPeople = new List<dynamic>();

            try
            {

                foreach (Person person in allPeople)
                {
                    dynamic dynamicPerson = new ExpandoObject();
                    dynamicPerson.PersonID = person.PersonID;
                    dynamicPerson.Name = person.Name;
                    dynamicPerson.Surname = person.Surname;
                    dynamicPerson.DateOfBirth = person.DateOfBirth;
                    dynamicPerson.Number = person.Number;
                    dynamicPerson.Email = person.Email;
                    dynamicPerson.Address = person.Address;
                    dynamicPerson.Activation_Status = person.Activation_Status_ID;

                    dynamicPeople.Add(dynamicPerson);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicPeople;
        }

        [System.Web.Http.Route("api/Members/getAllUnapprovedMembers")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllUnapprovedMembers()
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            // !!--User Management--!!
            //string sessionId = Request.Headers.Authorization.ToString();
            //var user = db.Where(o => o.SessionID == sessionId).FirstOrDefault();
            //if(user != null)

            try
            {
                return getAllUnapprovedMembersReturnList(db.People.Where(a => a.Activation_Status_ID == 4).ToList());
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e;
                return toReturn;
            }
        }

        public List<dynamic> getAllUnapprovedMembersReturnList(List<Person> allPeople)
        {
            //Database conncection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicPeople = new List<dynamic>();

            try
            {
                foreach (Person person in allPeople)
                {
                    dynamic dynamicPerson = new ExpandoObject();
                    dynamicPerson.PersonID = person.PersonID;
                    dynamicPerson.Name = person.Name;
                    dynamicPerson.Surname = person.Surname;
                    dynamicPerson.DateOfBirth = person.DateOfBirth;
                    dynamicPerson.Number = person.Number;
                    dynamicPerson.Email = person.Email;
                    dynamicPerson.Address = person.Address;
                    dynamicPerson.Activation_Status = person.Activation_Status_ID;

                    dynamicPeople.Add(dynamicPerson);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicPeople;
        }

        [System.Web.Http.Route("api/Members/updateMemberApproval")]
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult updateMemberApproval([FromBody] Person currentPerson)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //Person thisPerson = db.People.Where(z => z.PersonID == currentPerson.PersonID).FirstOrDefault();

            //Find the person current activation status id en updated the activation status id to approved.

            if (currentPerson == null)
            {
                return BadRequest(ModelState);
            }


            try
            {
                Person psn = new Person();
                psn = db.People.Find(currentPerson.PersonID);
                if (psn != null && psn.Activation_Status_ID == 4)
                {
                    psn.Activation_Status_ID = 1;
                }

                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Approved Member";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                int a = db.SaveChanges();


            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e;
                return toReturn;
            }
            return Ok(currentPerson);
        }

        // 2.22 Assign leader to member
        [System.Web.Http.Route("api/Members/getUnassignedMember")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getUnassignedMember()
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            List<Organisational_Structure_Position> orgStructpos = db.Organisational_Structure_Position.Include(z => z.Person).Include(q => q.Organisational_Individual_Position).ToList();

            try
            {
                return getUnassignedMemberList(db.Organisational_Structure_Position.Where(a => a.OrgIndivPosID == 47).ToList());
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message;
                return toReturn;
            }
        }

        public List<dynamic> getUnassignedMemberList(List<Organisational_Structure_Position> structPos)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicOrgStructPositions = new List<dynamic>();

            try
            {
                foreach (Organisational_Structure_Position structposition in structPos)
                {
                    dynamic dynamicOrgPosition = new ExpandoObject();

                    dynamicOrgPosition.OrgStructID = structposition.OrgStructID;
                    dynamicOrgPosition.OrgStructLevel = structposition.OrgStructLevel;
                    dynamicOrgPosition.AssignLeader = structposition.AssignLeader;
                    dynamicOrgPosition.Description = structposition.Description;
                    dynamicOrgPosition.PersonID = structposition.PersonID;
                    dynamicOrgPosition.Name = db.People.Where(x => x.PersonID == structposition.PersonID).Select(o => o.Name).FirstOrDefault();
                    dynamicOrgPosition.Surname = db.People.Where(x => x.PersonID == structposition.PersonID).Select(o => o.Surname).FirstOrDefault();
                    dynamicOrgPosition.OrgStructTypeID = structposition.OrgStructTypeID;
                    dynamicOrgPosition.OrgIndivPosId = structposition.OrgIndivPosID;
                    dynamicOrgPosition.OrgStructIDReportsTo = structposition.OrgStructIDReportsTo;
                    dynamicOrgPosition.OrgGroupID = structposition.OrgGroupID;
                    dynamicOrgPosition.Description = db.Organisational_Group.Where(z => z.OrgGroupID == structposition.OrgGroupID).Select(c => c.Description).FirstOrDefault();
                    dynamicOrgPosition.GroupID1 = structposition.OrgGroupID1;
                    dynamicOrgPosition.GroupID2 = structposition.OrgGroupID2;
                    dynamicOrgPosition.GroupID3 = structposition.OrgGroupID3;

                    dynamicOrgStructPositions.Add(dynamicOrgPosition);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicOrgStructPositions;
        }

        [System.Web.Http.Route("api/Members/getUnassignedLeader")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getUnassignedLeader()
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            List<Organisational_Structure_Position> orgStructPosition = db.Organisational_Structure_Position.Include(z => z.Person).Include(q => q.Organisational_Individual_Position).ToList();

            try
            {
                return getUnassignedLeaderList(db.Organisational_Structure_Position.Where(a => a.OrgIndivPosID == 43).ToList());
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message;
                return toReturn;
            }
        }

        public List<dynamic> getUnassignedLeaderList(List<Organisational_Structure_Position> structPosition)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicOrgStructurePositions = new List<dynamic>();

            try
            {
                foreach (Organisational_Structure_Position structpos in structPosition)
                {
                    dynamic dynamicOrgPos = new ExpandoObject();

                    dynamicOrgPos.OrgStructID = structpos.OrgStructID;
                    dynamicOrgPos.OrgStructLevel = structpos.OrgStructLevel;
                    dynamicOrgPos.AssignLeader = structpos.AssignLeader;
                    dynamicOrgPos.Description = structpos.Description;
                    dynamicOrgPos.PersonID = structpos.PersonID;
                    dynamicOrgPos.Name = db.People.Where(x => x.PersonID == structpos.PersonID).Select(o => o.Name).FirstOrDefault();
                    dynamicOrgPos.Surname = db.People.Where(x => x.PersonID == structpos.PersonID).Select(o => o.Surname).FirstOrDefault();
                    dynamicOrgPos.OrgStructTypeID = structpos.OrgStructTypeID;
                    dynamicOrgPos.OrgIndivPosId = structpos.OrgIndivPosID;
                    dynamicOrgPos.OrgIndivDescription = db.Organisational_Individual_Position.Where(s => s.OrgIndivPosID == structpos.OrgIndivPosID).Select(w => w.Decription);
                    dynamicOrgPos.OrgStructIDReportsTo = structpos.OrgStructIDReportsTo;
                    dynamicOrgPos.OrgGroupID = structpos.OrgGroupID;

                    dynamicOrgStructurePositions.Add(dynamicOrgPos);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicOrgStructurePositions;
        }

        [System.Web.Http.Route("api/Members/AssignLeader")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> AssignLeader([FromBody] Organisational_Structure_Position currentStructPos)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            Organisational_Structure_Position thisOrgStrucPos = db.Organisational_Structure_Position.Where(a => a.OrgStructID == currentStructPos.OrgStructID).FirstOrDefault();



            try
            {
                thisOrgStrucPos.AssignLeader = currentStructPos.AssignLeader;

                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Leader assigned to Member";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                db.SaveChanges();
                return getUnassignedMember();
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();

                if (e != null)
                {
                    toReturn.Error = e.Message;
                    return toReturn;
                }
                else
                {
                    return null;
                }
            }

        }

    }
}