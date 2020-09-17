using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using RC_API.Models;
using System.Web.Http.Cors;
using System.Dynamic;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net;

namespace RC_API.Controllers
{
    public class DiscipleshipController : ApiController
    {

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        //*********CRUD DISCIPLESHIP START************//


        //CREATE DISCIPLESHIP
        [System.Web.Http.Route("api/Discipleship/addDiscipleship")]
        [System.Web.Mvc.HttpPost]
        public dynamic addDiscipleship([FromBody] Discipleship discipleship)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            dynamic toReturn = new ExpandoObject();


            try
            {
                //retrieve similar data
                List<Discipleship> disc = db.Discipleships.Where(x => x.DiscipleshipDescription == discipleship.DiscipleshipDescription).ToList();

                if (disc.Count == 0)
                {
                    //If no similar entry exists add to db
                    db.Discipleships.Add(discipleship);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Added a Discipleship with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();//save
                }
                else
                {
                    //else return error
                    toReturn.Error = "Similar already exists";
                    return toReturn;
                }



            }
            catch (Exception e)
            {
                // if error occurs return error
                toReturn.Error = e.Message + e.InnerException;
                return toReturn;

            }

            return getAllDiscipleships();


        }


        //READ ALL DISCIPLESHIPS 
        [System.Web.Http.Route("api/Discipleship/getAllDiscipleships")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllDiscipleships()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;


            try
            {
                //retrieve all 
                List<Discipleship> Disc = db.Discipleships.ToList();
                return getDiscipleshipList(Disc);


            }
            catch (Exception e)
            {
                //else return null
                return null;
                //dynamic toReturn = new ExpandoObject();
                //toReturn.Error = e.Message;
                //return toReturn;
            }

        }


        public List<dynamic> getDiscipleshipList(List<Discipleship> allDiscipleships)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicDiscipleships = new List<dynamic>();
            //get dynamic object list

            try
            {
                foreach (Discipleship thisDiscipleship in allDiscipleships)
                {
                    dynamic dynamicDiscipleship = new ExpandoObject();

                    dynamicDiscipleship.DiscipleshipID = thisDiscipleship.DiscipleshipID;
                    dynamicDiscipleship.DiscipleshipDescription = thisDiscipleship.DiscipleshipDescription;

                    dynamicDiscipleships.Add(dynamicDiscipleship);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicDiscipleships;

        }



        //Get Discipleship by ID
        [System.Web.Http.Route("api/Discipleship/GetDiscipleshipByID/{DiscipleshipID}")]
        [System.Web.Mvc.HttpGet]
        public dynamic GetDiscipleshipByID(int DiscipleshipID)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //retrieve object where id is equal to id received
            Discipleship thisDiscipleship = db.Discipleships.Where(x => x.DiscipleshipID == DiscipleshipID).FirstOrDefault();

            try
            {
                return thisDiscipleship;//return object
            }
            catch (Exception e)
            {
                //else return error
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message;
                return toReturn;
            }
        }


        //UPDATE DISCIPLESHIP
        [System.Web.Http.Route("api/Discipleship/updateDiscipleship")]
        [System.Web.Mvc.HttpPost]
        public dynamic updateDiscipleship([FromBody] Discipleship currentDiscipleship)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //retrieve selected object
            Discipleship thisDiscipleship = db.Discipleships.Where(i => i.DiscipleshipID == currentDiscipleship.DiscipleshipID).FirstOrDefault();

            //alter attributes
            thisDiscipleship.DiscipleshipID = currentDiscipleship.DiscipleshipID;
            thisDiscipleship.DiscipleshipDescription = currentDiscipleship.DiscipleshipDescription;
            dynamic toReturn = new ExpandoObject();
            try
            {
                //check for similar
                List<Discipleship> disc = db.Discipleships.Where(x => x.DiscipleshipDescription == currentDiscipleship.DiscipleshipDescription).ToList();

                if (disc.Count == 0)
                {

                Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Updated a Discipleship with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    //if not similar save
                    db.SaveChanges();
                    return getAllDiscipleships();
                }
                else
                {
                    //else return error
                    toReturn.Error = "Similar already exists";
                    return toReturn;
                }
            }
            catch (Exception e)
            {
                //else error
                toReturn.Error = e.Message + e.InnerException;
                return toReturn;
            }

        }


        //DELETE DISCIPLESHIP
        [System.Web.Http.Route("api/Discipleship/delDiscipleship")]
        [System.Web.Mvc.HttpPost]
        public dynamic delDiscipleship([FromBody] Discipleship currentDiscipleship)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //retrieve selected
            Discipleship thisDiscipleship = db.Discipleships.Where(x => x.DiscipleshipID == currentDiscipleship.DiscipleshipID).FirstOrDefault();

            //remove from db
            db.Discipleships.Remove(thisDiscipleship);

            try
            {

            Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Deleted a Discipleship with ID:";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                //save
                db.SaveChanges();
                return getAllDiscipleships();
            }
            catch (Exception e)
            {
                //else error
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message;
                return toReturn;
            }

        }

        //*********CRUD DISCIPLESHIP END************//
    }
}
