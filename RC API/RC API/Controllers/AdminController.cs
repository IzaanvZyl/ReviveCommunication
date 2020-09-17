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
    public class AdminController : ApiController
    {
        //2.5 Join org group-Marno
        [System.Web.Http.Route("api/Admin/getGroupTypes")]
        [System.Web.Mvc.HttpPost]
        public List<Group_Type> getGroupTypes()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false; // configure proxy to eliminate overload of memory

            return db.Group_Type.ToList();

        }



        [System.Web.Http.Route("api/Admin/JoinOrgGroup")]
        [System.Web.Mvc.HttpPost]
        public void JoinOrgGroup([FromBody] dynamic JoinOrgGroup)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            if (JoinOrgGroup != null)
            {
                try
                {
                    Members_Serve_Follow_Up members_Serve = new Members_Serve_Follow_Up();
                    members_Serve.PersonID = JoinOrgGroup.PersonID;
                    members_Serve.ZonePastor = JoinOrgGroup.ZonePastor;
                    members_Serve.Homecell = JoinOrgGroup.Homecell;
                    members_Serve.SpiritualGiftTestSession = JoinOrgGroup.SpiritualGiftTestSession;
                    members_Serve.HighestSpiritualGifts = JoinOrgGroup.HighestSpiritualGifts;
                    members_Serve.Group1 = JoinOrgGroup.Group1.GroupTypeID;
                    members_Serve.Group2 = JoinOrgGroup.Group2.GroupTypeID;
                    members_Serve.Group3 = JoinOrgGroup.Group3.GroupTypeID;

                    db.Members_Serve_Follow_Up.Add(members_Serve);
                    db.SaveChanges();
                }
                catch (Exception e)
                {

                }

            }

        }


    }
}
