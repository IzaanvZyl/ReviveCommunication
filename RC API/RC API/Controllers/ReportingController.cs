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
using System.Net.Http;
using System.Net;
using System.Web.WebSockets;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace RC_API.Controllers
{
    public class ReportingController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [System.Web.Http.Route("api/GenerateReport/getOverview")]
        [HttpGet]

        public dynamic getOverview(/*[FromBody] dynamic form*/)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> overview = new List<dynamic>();


            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            for (int i = 0; i < 12; i++)
            {

                var ChAtt = db.Church_Attendance_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();
                var HoAtt = db.Homecell_Attendance_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();
                var Disc = db.Person_Discipleship.Where(x => x.FollowUpDate.Year == 2020 && x.FollowUpDate.Month == i + 1).Count();
                var nmo = db.NMO_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();

                dynamic o = new ExpandoObject();
                o.Month = months[i];
                o.ChurchAttendance = 0;
                o.HomecellAttendance = 0;
                o.NewMemeberOrientation = 0;
                o.Discipleship = 0;
                o.Salvations = 0;
                foreach (var x in ChAtt)
                {
                    int ChAttCount = x.FirstTimeVisitors + x.Leader + x.Member + x.Salvations;
                    o.ChurchAttendance = ChAttCount;
                    o.Salvations = x.Salvations;
                }
                foreach (var x in HoAtt)
                {
                    int HoAttCount = x.FirstTimeVisitors + x.Leaders + x.Members + x.Salvations;
                    o.HomecellAttendance = HoAttCount;
                    o.Salvations = x.Salvations;
                }
                foreach (var x in nmo)
                {
                    int nmoCount = x.MonthTotal;
                    o.NewMemeberOrientation = nmoCount;

                }

                o.Discipleship = Disc;
                overview.Add(o);
            }
            dynamic OverviewData = new ExpandoObject();
            OverviewData.Data = overview;

            return OverviewData;




        }

        [System.Web.Http.Route("api/GenerateReport/getHomecellAttendance")]
        [HttpGet]
        public dynamic getHomecellAttendance(/*[FromBody] dynamic form*/)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> haf = new List<dynamic>();
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };


            for (int i = 0; i < 12; i++)
            {
                dynamic o = new ExpandoObject();
                o.Month = months[i];
                o.FirstTimeVisitors = 0;
                o.Leader = 0;
                o.Member = 0;
                o.Visitors = 0;
                o.Salvations = 0;
                var HoAtt = db.Homecell_Attendance_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();

                foreach (var x in HoAtt)
                {

                    o.Members = x.Members;
                    o.Leaders = x.Leaders;
                    o.Visitors = x.Visitors;
                    o.FirstTimeVisitors = x.FirstTimeVisitors;
                    o.Salvations = x.Salvations;
                }

                haf.Add(o);


            }
            dynamic HCF = new ExpandoObject();
            HCF.HomecellFeedback = haf;
            return HCF;
        }

        [System.Web.Http.Route("api/GenerateReport/getChurchAttendance")]
        [HttpGet]
        public dynamic getChurchAttendance(/*[FromBody] dynamic form*/)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> caf = new List<dynamic>();
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            for (int i = 0; i < 12; i++)
            {
                dynamic o = new ExpandoObject();
                o.Month = months[i];
                o.FirstTimeVisitors = 0;
                o.Leaders = 0;
                o.Members = 0;
                o.Visitors = 0;
                o.Salvations = 0;
                var ChAtt = db.Church_Attendance_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();

                foreach (var x in ChAtt)
                {

                    o.Members = x.Member;
                    o.Leaders = x.Leader;
                    o.Visitors = x.Visitors;
                    o.FirstTimeVisitors = x.FirstTimeVisitors;
                    o.Salvations = x.Salvations;
                }

                caf.Add(o);
            }

            dynamic CAF = new ExpandoObject();
            CAF.ChurchAttendanceFeedback = caf;

            return CAF;
        }


        [System.Web.Http.Route("api/GenerateReport/getDiscipleshipReport")]
        [HttpGet]
        public dynamic getDiscipleshipReport(/*[FromBody] dynamic form*/)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> DiscipleshipsAttended = new List<dynamic>();





            List<Discipleship> xx = db.Discipleships.ToList();

            foreach (var obj in xx)
            {
                dynamic o = new ExpandoObject();
                o.Discipleship = db.Discipleships.Where(x => x.DiscipleshipID == obj.DiscipleshipID).FirstOrDefault();
                o.Attended = db.Person_Discipleship.Where(x => x.DiscipleshipID == obj.DiscipleshipID).Count();
                DiscipleshipsAttended.Add(o);
            }




            dynamic DA = new ExpandoObject();
            DA.Data = DiscipleshipsAttended;

            return DA;
        }

        [System.Web.Http.Route("api/GenerateReport/getZoneGrowth")]
        [HttpGet]
        public dynamic getZoneGrowth(/*[FromBody] dynamic form*/)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> ZoneGrowth = new List<dynamic>();


            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            for (int i = 0; i < 12; i++)
            {

                var ChAtt = db.Zone_Church_Attendance_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();
                var HoAtt = db.Zone_Homecell_Attendance_Feedback.Where(x => x.Date.Year == 2020 && x.Date.Month == i + 1).ToList();


                dynamic o = new ExpandoObject();
                o.Month = months[i];
                o.ChurchAttendance = 0;
                o.HomecellAttendance = 0;

                foreach (var x in ChAtt)
                {
                    int ChAttCount = x.FirstTimeVisitors + x.Leader + x.Member + x.Salvations;
                    o.ChurchAttendance = ChAttCount;

                }
                foreach (var x in HoAtt)
                {
                    int HoAttCount = x.FirstTimeVisitors + x.Leader + x.Member + x.Salvations;
                    o.HomecellAttendance = HoAttCount;

                }

                ZoneGrowth.Add(o);
            }


            dynamic ZG = new ExpandoObject();
            ZG.Data = ZoneGrowth;

            return ZG;
        }






    }
}
