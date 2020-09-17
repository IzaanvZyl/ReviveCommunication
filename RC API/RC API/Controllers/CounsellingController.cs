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
    public class CounsellingController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // 8.1 add counselling request
        [System.Web.Http.Route("api/Counselling/AddCounsellingRequest")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> AddCounsellingRequest([FromBody] Counselling_Request AddCounsellingRequest)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            if (AddCounsellingRequest != null)
            {

                db.Configuration.ProxyCreationEnabled = false;

                string PhoneNumber = db.People.Where(x => x.PersonID == AddCounsellingRequest.PersonID).Select(o => o.Number).FirstOrDefault();

                AddCounsellingRequest.PhoneNumber = PhoneNumber;



                db.Counselling_Request.Add(AddCounsellingRequest);
                db.SaveChanges();
                return GetCounsellingRequest();
            }
            else
            {
                return null;
            }
        }

        //8.2 view counselling request/ response
        [System.Web.Http.Route("api/Counselling/GetCounsellingRequest")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetCounsellingRequest()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            db.Configuration.ProxyCreationEnabled = false;
            return GetCounsellingRequestList(db.Counselling_Request.ToList());
        }

        private List<dynamic> GetCounsellingRequestList(List<Counselling_Request> forClient)
        {
            List<dynamic> dynamicCounsellingRequests = new List<dynamic>();
            foreach (Counselling_Request counselling in forClient)
            {
                dynamic dynamicCounsellingRequest = new ExpandoObject();
                //assign
                dynamicCounsellingRequest.CounsellingRequestID = counselling.CounsellingRequestID;
                dynamicCounsellingRequest.PersonID = counselling.PersonID;
                dynamicCounsellingRequest.CounsellingDescription = counselling.CounsellingDescription;
                dynamicCounsellingRequest.PhoneNumber = counselling.PhoneNumber;
                //add to origional
                dynamicCounsellingRequests.Add(dynamicCounsellingRequest);
            }
            return dynamicCounsellingRequests;
        }

        //8.3 add counselling response
        [System.Web.Http.Route("api/Counselling/AddCounsellingResponse")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> AddCounsellingResponse([FromBody] Counselling AddCounsellingResponse)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            if (AddCounsellingResponse != null)
            {

                db.Configuration.ProxyCreationEnabled = false;
                db.Counsellings.Add(AddCounsellingResponse);
                db.SaveChanges();
                return GetCounsellingResponse();
            }
            else
            {
                return null;
            }
        }
        //view counsellingResponse
        [System.Web.Http.Route("api/Counselling/GetCounsellingResponse")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetCounsellingResponse()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            db.Configuration.ProxyCreationEnabled = false;
            return GetCounsellingResponseList(db.Counsellings.ToList());
        }

        private List<dynamic> GetCounsellingResponseList(List<Counselling> forClient)
        {
            List<dynamic> dynamicCounsellingResponses = new List<dynamic>();
            foreach (Counselling counselling in forClient)
            {
                dynamic dynamicCounsellingResponse = new ExpandoObject();
                //assign
                dynamicCounsellingResponse.CounsellingID = counselling.CounsellingID;
                dynamicCounsellingResponse.CounsellingResponse = counselling.CounsellingResponse;

                //add to origional
                dynamicCounsellingResponses.Add(dynamicCounsellingResponse);
            }
            return dynamicCounsellingResponses;
        }

        //8.4 resolve counselling request
        [System.Web.Http.Route("api/Counselling/ResolveCounselling")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> ResolveCounselling([FromBody] Counselling_Request groups)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            Counselling_Request group = db.Counselling_Request.Where(x => x.CounsellingRequestID == groups.CounsellingRequestID).FirstOrDefault();
            db.Counselling_Request.Remove(group);
            db.SaveChanges();
            return GetCounsellingRequest();
        }

        //Get GroupType by ID
        [System.Web.Http.Route("api/Counselling/GetCounsellingByID/{CounsellingRequestID}")]
        [System.Web.Mvc.HttpGet]
        public dynamic GetCounsellingByID(int CounsellingReqID)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //retrieve object where id is equal to id received
            Counselling_Request thisCounsellingType = db.Counselling_Request.Where(x => x.CounsellingRequestID == CounsellingReqID).FirstOrDefault();
            try
            {
                return thisCounsellingType;//return object
            }
            catch (Exception e)
            {
                //else return error
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message;
                return toReturn;
            }
        }
    }
}
