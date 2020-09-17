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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MessagesController : ApiController
    {
        //Send Invitation
        [System.Web.Http.Route("api/Messages/SendInvitation")]
        [System.Web.Mvc.HttpPost]
        public void SendInvitation([FromBody] dynamic inv)
        {

            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            if (inv != null) //if object not null
            {
                try
                {

                    Invitation dynamicInvitation = new Invitation();

                    //create new announcement based on Object received
                    dynamicInvitation.InvitationDate = inv.InvitationDate;
                    dynamicInvitation.InvitationSenderPersonID = inv.PersonID;
                    dynamicInvitation.InvitationDetail = inv.InvitationDetail;
                    dynamicInvitation.StartTime = inv.StartTime;
                    dynamicInvitation.EndTime = inv.EndTime;
                    dynamicInvitation.Summary = inv.Summary;


                    db.Invitations.Add(dynamicInvitation);// add Invite to database
                    db.SaveChanges();//save

                    string d = inv.InvitationDetail;//write new Invite detail to string

                    Invitation created = db.Invitations.Where(x => x.InvitationDetail == d).FirstOrDefault();//retrieve created Invite



                    foreach (dynamic p in inv.SelectedReceivers)// foreach person in receiver list
                    {
                        //create new Person_Announcement entry
                        Person_Invitation person_Invitation = new Person_Invitation();
                        person_Invitation.PersonID = p.PersonID;
                        person_Invitation.InvitationID = created.InvitationID;


                        db.Person_Invitation.Add(person_Invitation);// Add to data base
                    }
                    db.SaveChanges();//save

                }
                catch (Exception e)
                {
                    dynamic toReturn = new ExpandoObject();
                    toReturn = e.Message + e.InnerException;// else error 

                }


            }


        }



        //Dismiss Invitation
        [System.Web.Http.Route("api/Messages/dismissInvitation")]
        [System.Web.Mvc.HttpPost]
        public void dismissAnnouncement([FromBody] Invitation Inv)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            Person_Invitation thisInv = db.Person_Invitation.Where(x => x.InvitationID == Inv.InvitationID).FirstOrDefault();

            try
            {
                thisInv.InvitationStatus = true;

                db.SaveChanges();

            }
            catch (Exception e)
            {

            }

        }

        //View Invitation     

        [System.Web.Http.Route("api/Messages/retrieveInvitations")]
        [System.Web.Mvc.HttpPost]
        public List<Invitation> retrieveInvitations(Person Person)
        {

            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            if(Person == null)
            {
                return null;
            }
            int PersonID = Person.PersonID;
            List<Person_Invitation> pI = db.Person_Invitation.Where(x => x.InvitationStatus == false && x.PersonID == PersonID).ToList();// retrieve Person's Person_Invitations


            List<Invitation> inv = new List<Invitation>();
            try
            {
                foreach (Person_Invitation p in pI)//retrieve all invitations that is linked to this person
                {
                    inv.Add(db.Invitations.Where(x => x.InvitationID == p.InvitationID).FirstOrDefault());
                }
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
            

            return inv;//display list of announcements
        }



        //Announcemnets
        [System.Web.Http.Route("api/Messages/GetPeople")]
        [System.Web.Mvc.HttpGet]
        public List<Person> GetPeople()
        {

            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<Person> people = db.People.ToList();

            return people;
        }

        //get Announcements
        [System.Web.Http.Route("api/Messages/retrieveAllAnnouncements")]
        [System.Web.Mvc.HttpGet]
        public List<Announcement> retrieveAllAnnouncements()
        {

            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<Announcement> ann = db.Announcements.ToList();
            return ann;//display list of announcements
        }

        //get Persons Announcements
        [System.Web.Http.Route("api/Messages/retrieveAnnouncements")]
        [System.Web.Mvc.HttpPost]
        public List<Announcement> retrieveAnnouncements( Person pp)
        {

            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            // List<Person_Announcement> pA = db.Person_Announcement.Where(o => o.PersonID == PersonID).ToList();// retrieve Person's Person_Announcements
            if (pp == null)
            {
                return null;
            }
            List<Person_Announcement> pA = db.Person_Announcement.Where(x => x.AnnouncementStatus == false && x.PersonID == pp.PersonID).ToList();// retrieve Person's Person_Announcements

          
            List<Announcement> ann = new List<Announcement>();

            try
            {
                foreach (Person_Announcement p in pA)//retrieve all announcements that is liked to this person
                {
                    ann.Add(db.Announcements.Where(x => x.AnnouncementID == p.AnnouncementID).FirstOrDefault());
                }
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

            return ann;//display list of announcements
        }

        //Delete Announcement
        [System.Web.Http.Route("api/Messages/delAnnouncement")]
        [System.Web.Mvc.HttpPost]
        public void delAnnouncement([FromBody] Announcement announcement)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<Person_Announcement> thisAnn = db.Person_Announcement.Where(x => x.AnnouncementID == announcement.AnnouncementID).ToList();

            try
            {
                foreach (Person_Announcement a in thisAnn)
                {
                    db.Person_Announcement.Remove(a);
                }

                Announcement x = db.Announcements.Where(d => d.AnnouncementID == announcement.AnnouncementID).FirstOrDefault();
                db.Announcements.Remove(x);

                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Removed announcement with ID:";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                db.SaveChanges();

            }
            catch (Exception e)
            {

            }

        }


        //Dismiss Announcement
        [System.Web.Http.Route("api/Messages/dismissAnnouncement")]
        [System.Web.Mvc.HttpPost]
        public void dismissAnnouncement([FromBody] Announcement announcement)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            Person_Announcement thisAnn = db.Person_Announcement.Where(x => x.AnnouncementID == announcement.AnnouncementID).FirstOrDefault();

            try
            {
                thisAnn.AnnouncementStatus = true;

                db.SaveChanges();

            }
            catch (Exception e)
            {

            }

        }

        [System.Web.Http.Route("api/Messages/PostAnnouncement")]
        [System.Web.Mvc.HttpPost]
        public void PostAnnouncement([FromBody] dynamic announcement)
        {

            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            if (announcement != null) //if object not null
            {
                try
                {

                    Announcement dynamicAnnouncement = new Announcement();

                    //create new announcement based on Object received
                    ////dynamicAnnouncement.AnnouncementDate = DateTime.Today;
                    dynamicAnnouncement.AnnouncementSenderID = announcement.PersonID;
                    dynamicAnnouncement.AnnouncementDetail = announcement.AnnouncementDetail;

                    db.Announcements.Add(dynamicAnnouncement);// add Announcement to database
                    db.SaveChanges();//save

                    string d = announcement.AnnouncementDetail;//write new announcement detail to string

                    Announcement created = db.Announcements.Where(x => x.AnnouncementDetail == d).FirstOrDefault();//retrieve created announcement



                    foreach (dynamic p in announcement.SelectedReceivers)// foreach person in receiver list
                    {
                        //create new Person_Announcement entry
                        Person_Announcement dynamicPerson_Announcement = new Person_Announcement();
                        dynamicPerson_Announcement.PersonID = p.PersonID;
                        dynamicPerson_Announcement.AnnouncementID = created.AnnouncementID;


                        db.Person_Announcement.Add(dynamicPerson_Announcement);// Add to data base
                    }

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Posted announcement with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();//save

                }
                catch (Exception e)
                {
                    dynamic toReturn = new ExpandoObject();
                    toReturn = e.Message + e.InnerException;// else error 

                }


            }

        }
    }
}