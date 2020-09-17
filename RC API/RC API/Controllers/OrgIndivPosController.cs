using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RC_API.Models;
using System.Web.Http.Cors;
using System.Dynamic;

namespace RC_API.Controllers
{

    public class OrgIndivPosController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*")]

        //*********CRUD ORG INDIV POS START************//
        //CREATE ORG INDIV POS
        [System.Web.Http.Route("api/OrgIndivPos/addOrgIndivPos")]
        [System.Web.Mvc.HttpPost]
        public dynamic addOrgIndivPos([FromBody] Organisational_Individual_Position OrgIndivPos)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //If no data is received return error
            dynamic toReturn = new ExpandoObject();
            if (OrgIndivPos == null)
            {
                toReturn.Error = "Cant be null";
                return toReturn;
            }
            try
            {

                db.Organisational_Individual_Position.Add(OrgIndivPos);

                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Added Organisational Individual Position";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                db.SaveChanges(); //save changes

                return getAllOrgIndivPos();


            }
            catch (Exception e)
            {
                //if any errors occur return error message
                toReturn.Error = e.Message + e.InnerException;
                return toReturn;
            }
        }

        //Get position name
        [System.Web.Http.Route("api/OrgIndivPos/getPositionNames")]
        [System.Web.Mvc.HttpGet]
        public List<Organisational_Individual_Position> getPositionNames()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            try
            {
                //retrieves all OrgIndivPos names
                List<Organisational_Individual_Position> o = db.Organisational_Individual_Position.ToList();

                return o;

            }
            catch (Exception e)
            {
                //else return null
                return null;
            }

        }

        //READ ALL ORG INDIV POS 
        [System.Web.Http.Route("api/OrgIndivPos/getAllOrgIndivPos")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllOrgIndivPos()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            try
            {
                // get all OrgIndiv Pos
                List<Organisational_Individual_Position> o = db.Organisational_Individual_Position.ToList();

                return getAllOrgIndivPosList(o); //send to attach Access levels to retrieved OrgIndivPos

            }
            catch (Exception e)
            {
                //else return null
                return null;
                //dynamic toReturn = new ExpandoObject();
                //toReturn.Error = e.Message + e.InnerException;
                //return toReturn;
            }

        }


        public List<dynamic> getAllOrgIndivPosList(List<Organisational_Individual_Position> allOrgIndivPos)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            List<dynamic> dynamicOrgIndivPosList = new List<dynamic>();

            foreach (Organisational_Individual_Position thisOrgIndivPos in allOrgIndivPos)
            {
                dynamic dynamicOrgIndivPos = new ExpandoObject();

                //create a dynamic object that contains all relevent attributes of OrgIndivPos
                dynamicOrgIndivPos.OrgIndivPosID = thisOrgIndivPos.OrgIndivPosID;
                dynamicOrgIndivPos.Decription = thisOrgIndivPos.Decription;
                dynamicOrgIndivPos.Goal_Access = db.Organisational_Individual_Position.Select(x => x.Goal_Access);
                dynamicOrgIndivPos.Use_Cases = db.Organisational_Individual_Position.Select(x => x.Use_Cases);



                dynamicOrgIndivPosList.Add(dynamicOrgIndivPos);// add dynamic object to list
            }
            return dynamicOrgIndivPosList; //send back ot get All method

        }


        //Get ORG INDIV POS by ID
        [System.Web.Http.Route("api/OrgIndivPos/getAllOrgIndivPosByID/{OrgIndivPosID}")]
        [System.Web.Mvc.HttpGet]
        public Organisational_Individual_Position getAllOrgIndivPosByID(int OrgIndivPosID)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //retrieve object where id is equal to id received
            Organisational_Individual_Position thisOrgIndivPos = db.Organisational_Individual_Position.Where(x => x.OrgIndivPosID == OrgIndivPosID).FirstOrDefault();

            try
            {
                return thisOrgIndivPos; //return found object
            }
            catch (Exception e)
            {
                //else present error
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message + e.InnerException;
                return toReturn;
            }
        }


        //UPDATE ORG INDIV POS
        [System.Web.Http.Route("api/OrgIndivPos/updateOrgIndivPos")]
        [System.Web.Mvc.HttpPost]
        public dynamic updateOrgIndivPos([FromBody] Organisational_Individual_Position currentOrgIndivPos)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            try
            {
                //retrieve existing object
                Organisational_Individual_Position thisOrgIndivPos = db.Organisational_Individual_Position.Include("Use_Cases").Include("Goal_Access").Where(i => i.OrgIndivPosID == currentOrgIndivPos.OrgIndivPosID).FirstOrDefault();

                //remove current Usecase and Goal access
                foreach (Goal_Access goal in thisOrgIndivPos.Goal_Access.ToList())
                {
                    thisOrgIndivPos.Goal_Access.Remove(goal);
                }
                foreach (Use_Cases uc in thisOrgIndivPos.Use_Cases.ToList())
                {
                    thisOrgIndivPos.Use_Cases.Remove(uc);
                }
                //assign new access
                thisOrgIndivPos.Goal_Access = currentOrgIndivPos.Goal_Access;
                thisOrgIndivPos.Use_Cases = currentOrgIndivPos.Use_Cases;

                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 1;
                auditLog.EventDescription = "Updated an Organisational Individual Positions Access levels with ID:";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                db.SaveChanges();//save 
                return getAllOrgIndivPos(); //retrieve all
            }
            catch (Exception e)
            {
                //else return error
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message + e.InnerException;
                return toReturn;
            }
        }


        //DELETE ORG INDIV POS

        [System.Web.Http.Route("api/OrgIndivPos/delOrgIndivPos")]
        [System.Web.Mvc.HttpPost]
        public dynamic delOrgIndivPos([FromBody] Organisational_Individual_Position currentOrgIndivPos)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;
            //retrieve selected object
            Organisational_Individual_Position thisOrgIndivPos = db.Organisational_Individual_Position.Where(x => x.OrgIndivPosID == currentOrgIndivPos.OrgIndivPosID).FirstOrDefault();

            //remove object 
            db.Organisational_Individual_Position.Remove(thisOrgIndivPos);

            try
            {
                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Removed Organisational Individual Structure Position with ID:";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                db.SaveChanges();//save
                return getAllOrgIndivPos();//return all
            }
            catch (Exception e)
            {
                //else return error
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message + e.InnerException;
                return toReturn;
            }
        }

        //*********CRUD ORG INDIV POS END************//

        //**********Get Goals and Usecases***********//

        [System.Web.Http.Route("api/OrgIndivPos/GetAllGoals")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> GetAllGoals()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            try
            {
                //retrieve all goals
                List<Goal_Access> o = db.Goal_Access.ToList();
                return GetAllGoalsList(o);

            }
            catch (Exception e)
            {
                //else return null
                return null;
                //dynamic toReturn = new ExpandoObject();
                //toReturn.Error = e.Message + e.InnerException;
                //return toReturn;
            }

        }


        public List<dynamic> GetAllGoalsList(List<Goal_Access> allGoals)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            List<dynamic> dynamicGoalList = new List<dynamic>();

            //create dynamic object 
            foreach (Goal_Access thisGoal in allGoals)
            {
                dynamic dynamicGoal = new ExpandoObject();

                dynamicGoal.GoalAccessID = thisGoal.GoalAccessID;
                dynamicGoal.GoalName = thisGoal.GoalName;
                dynamicGoal.GoalDescription = thisGoal.GoalDescription;



                dynamicGoalList.Add(dynamicGoal);
            }
            return dynamicGoalList;

        }

        //*****************************//

        [System.Web.Http.Route("api/OrgIndivPos/GetAllUseCase")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> GetAllUseCase()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            try
            {
                //retrieve all use cases
                List<Use_Cases> o = db.Use_Cases.ToList();
                return GetAllUseCaseList(o);

            }
            catch (Exception e)
            {
                //else return null
                return null;
                //dynamic toReturn = new ExpandoObject();
                //toReturn.Error = e.Message + e.InnerException;
                //return toReturn;
            }

        }


        public List<dynamic> GetAllUseCaseList(List<Use_Cases> allUsecases)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            List<dynamic> dynamicUsecasesList = new List<dynamic>();

            foreach (Use_Cases thisUsecase in allUsecases)
            {
                dynamic dynamicGoal = new ExpandoObject();

                dynamicGoal.UCID = thisUsecase.UCID;
                dynamicGoal.UCName = thisUsecase.UCName;

                dynamicUsecasesList.Add(dynamicGoal);
            }
            return dynamicUsecasesList;
        }


        //**********Get Goals and Usecases End***********//

    }
}
