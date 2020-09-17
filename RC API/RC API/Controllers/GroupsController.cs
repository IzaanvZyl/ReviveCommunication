using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RC_API.Models;
using System.Web.Http.Cors;
using System.IO;
using System.Web.Hosting;
using System.Net.Http.Headers;
using System.Data;
using System.Dynamic;
using System.Data.Entity;
using System.Globalization;
using System.Text;
using System.Security.Cryptography;
using System.Security.Policy;

namespace RC_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GroupsController : ApiController
    {
        //*********GROUPS START************// -- Izaan

        //3.19 View Organisational group - Izaan
        //Read all groups
        [System.Web.Http.Route("api/Groups/getAllGroups")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllGroups()
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
                return getAllGroupsReturnList(db.Organisational_Group.ToList());
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e;
                return toReturn;
            }
        }


        //Groups list - Izaan
        public List<dynamic> getAllGroupsReturnList(List<Organisational_Group> allGroups)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicGroups = new List<dynamic>();

            try
            {
                foreach (Organisational_Group thisGroup in allGroups)
                {
                    dynamic dynamicGroup = new ExpandoObject();
                    dynamicGroup.OrgGroupID = thisGroup.OrgGroupID;
                    dynamicGroup.GroupTypeID = thisGroup.GroupTypeID;
                    dynamicGroup.Description = thisGroup.Description;
                    dynamicGroup.Size = thisGroup.Size;
                    dynamicGroup.Address = thisGroup.Address;
                    dynamicGroup.SuburbID = thisGroup.SuburbID;

                    dynamicGroups.Add(dynamicGroup);
                }
            }
            catch (Exception e)
            {

            }


            return dynamicGroups;
        }

        //Get church name by ID - Izaan
        [System.Web.Http.Route("api/Groups/getGroupID")]
        [System.Web.Mvc.HttpGet]

        public Organisational_Group getGroupID(int OrgGroupID)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            Organisational_Group thisGroup = db.Organisational_Group.Where(z => z.OrgGroupID == OrgGroupID).FirstOrDefault();

            try
            {
                return thisGroup;
            }
            catch (Exception err)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = err;
                return toReturn;
            }
        }

        //3.18 Add Organisational group - Izaan
        [System.Web.Http.Route("api/Groups/addOrgGroup")]
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult addOrgGroup(Organisational_Group orgGroup)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //db.Organisational_Group.Add(orgGroup);

            try
            {
                Organisational_Group groupObj = new Organisational_Group();
                groupObj = db.Organisational_Group.Where(x => x.Description == orgGroup.Description).FirstOrDefault();
                if (groupObj != null)
                {

                }
                else
                {

                    Organisational_Group dynamicGroup = new Organisational_Group();
                    dynamicGroup.Description = orgGroup.Description;
                    dynamicGroup.Size = orgGroup.Size;
                    dynamicGroup.Address = orgGroup.Address;
                    dynamicGroup.GroupTypeID = orgGroup.GroupTypeID;
                    dynamicGroup.SuburbID = orgGroup.SuburbID;


                    db.Organisational_Group.Add(dynamicGroup);

                    Audit_Trail auditLog = new Audit_Trail();
                    auditLog.PersonID = 18;
                    auditLog.EventDescription = "Created Organisational Group with ID:";
                    auditLog.EventDateTime = DateTime.Now;
                    db.Audit_Trail.Add(auditLog);

                    db.SaveChanges();
                }

            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e.Message;
                return toReturn;
            }
            return Ok(orgGroup);
        }

        //3.19 Maintain Organisational group - Izaan
        //Update organisational group
        [System.Web.Http.Route("api/Groups/updateOrgGroup")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> updateOrgGroup([FromBody] Organisational_Group currentGroup)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            Organisational_Group thisOrgGroup = db.Organisational_Group.Where(a => a.OrgGroupID == currentGroup.OrgGroupID).FirstOrDefault();

            try
            {
                thisOrgGroup.OrgGroupID = currentGroup.OrgGroupID;
                thisOrgGroup.GroupTypeID = currentGroup.GroupTypeID;
                thisOrgGroup.Description = currentGroup.Description;
                thisOrgGroup.Size = currentGroup.Size;
                thisOrgGroup.Address = currentGroup.Address;
                thisOrgGroup.SuburbID = currentGroup.SuburbID;

                Audit_Trail auditLog = new Audit_Trail();
                auditLog.PersonID = 18;
                auditLog.EventDescription = "Updated Organisational Group with ID:";
                auditLog.EventDateTime = DateTime.Now;
                db.Audit_Trail.Add(auditLog);

                db.SaveChanges();
                return getAllGroups();
            }
            catch (Exception e)
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = e;
                return toReturn;
            }
        }

        //Retrieev group types - Izaan
        [System.Web.Http.Route("api/Groups/getAllGroupTypes")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllGroupTypes()
        {

            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            // !!--User Management--!!
            //string sessionId = Request.Headers.Authorization.ToString();
            //var user = db.Where(o => o.SessionID == sessionId).FirstOrDefault();
            //if(user != null)

            return getAllGroupTypesReturnList(db.Group_Type.ToList());

        }

        //Group type list - Izaan
        public List<dynamic> getAllGroupTypesReturnList(List<Group_Type> allGroupTypes)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            //Creating dynamic list
            List<dynamic> dynamicGroupTypes = new List<dynamic>();

            try
            {
                foreach (Group_Type gType in allGroupTypes)
                {
                    //Creating dynmaic object
                    dynamic dynamicGroupType = new ExpandoObject();
                    dynamicGroupType.GroupTypeID = gType.GroupTypeID;
                    dynamicGroupType.GroupTypeName = gType.GroupTypeName;

                    //Adding dynamic object to dynamic lits
                    dynamicGroupTypes.Add(dynamicGroupType);
                }
            }
            catch (Exception)
            {

            }

            return dynamicGroupTypes;
        }

        //Add suburb - Izaan
        [System.Web.Http.Route("api/Groups/addSuburb")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> addSuburb([FromBody] Suburb suburb)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            db.Suburbs.Add(suburb);
            db.SaveChanges();
            return getAllSuburbs();
        }

        //Get suburbs - Izaan
        [System.Web.Http.Route("api/Groups/getAllSuburbs")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllSuburbs()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            return getAllSuburbsList(db.Suburbs.ToList());
        }

        //Sububrb List - Izaan
        public List<dynamic> getAllSuburbsList(List<Suburb> suburbList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicSuburbs = new List<dynamic>();

            try
            {
                foreach (Suburb s in suburbList)
                {
                    dynamic dynamicSuburb = new ExpandoObject();
                    dynamicSuburb.SuburbID = s.SuburbID;
                    dynamicSuburb.SuburbName = s.SuburbName;
                    dynamicSuburb.CityID = s.CityID;

                    dynamicSuburbs.Add(dynamicSuburb);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicSuburbs;
        }

        //Retrieve ll cities - Izaan
        [System.Web.Http.Route("api/Groups/getAllCities")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllCities()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            return getAllCityList(db.Cities.ToList());
        }

        //City list - Izaan
        public List<dynamic> getAllCityList(List<City> cityList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicCities = new List<dynamic>();
            foreach (City c in cityList)
            {
                dynamic dynamicCity = new ExpandoObject();
                dynamicCity.CityID = c.CityID;
                dynamicCity.CityName = c.CityName;
                dynamicCity.ProvinceID = c.ProvID;

                dynamicCities.Add(dynamicCity);
            }
            return dynamicCities;
        }

        //Retrieve provinces - Izaan
        [System.Web.Http.Route("api/Groups/getAllProvinces")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllProvinces()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            return getAllProvinesList(db.Provinces.ToList());
        }

        //Province list - Izaan
        public List<dynamic> getAllProvinesList(List<Province> provinceList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicProvinces = new List<dynamic>();
            foreach (Province p in provinceList)
            {
                dynamic dynamicProvince = new ExpandoObject();
                dynamicProvince.ProvinceID = p.ProvinceID;
                dynamicProvince.ProvinceName = p.ProvinceName;
                dynamicProvince.CountryID = p.CountryID;

                dynamicProvinces.Add(dynamicProvince);
            }
            return dynamicProvinces;
        }

        //Retrieve all countries - Izaan
        [System.Web.Http.Route("api/Groups/getAllCountries")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getAllCountries()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            return getAllCountries(db.Countries.ToList());
        }

        //Country list - Izaan
        public List<dynamic> getAllCountries(List<Country> countryList)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicCountries = new List<dynamic>();
            foreach (Country country in countryList)
            {
                dynamic dynamicCountry = new ExpandoObject();
                dynamicCountry.CountryID = country.CountryID;
                dynamicCountry.CountryName = country.CountryName;

                dynamicCountries.Add(dynamicCountry);
            }
            return dynamicCountries;
        }

        //2.11 Request to transfer groups - Izaan
        [System.Web.Http.Route("api/Groups/TransferGroups")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> TransferGroups([FromBody] Organisational_Structure_Position currentgroup)
        {
            //Database connection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            //Configure proxy to eliminate memory overload
            db.Configuration.ProxyCreationEnabled = false;

            Organisational_Structure_Position thisOrgStructPso = db.Organisational_Structure_Position.Where(z => z.OrgStructID == currentgroup.OrgStructID).FirstOrDefault();



            try
            {
                thisOrgStructPso.OrgGroupID = currentgroup.OrgGroupID;

                db.SaveChanges();
                return getAllGroups();
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

        [System.Web.Http.Route("api/Groups/getGroupByPerson")]
        [System.Web.Mvc.HttpGet]
        public List<dynamic> getGroupByPerson()
        {
            //Databse conncection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<Organisational_Structure_Position> thisPersonGroup = db.Organisational_Structure_Position.Include(z => z.Organisational_Group).ToList();

            try
            {
                return PersonGroup(thisPersonGroup);
            }
            catch (Exception e)
            {
                dynamic toRetrun = new ExpandoObject();
                toRetrun.Error = e;
                return toRetrun;
            }
        }

        public List<dynamic> PersonGroup(List<Organisational_Structure_Position> allgroups)
        {
            //Database conncection
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            List<dynamic> dynamicPersonGroups = new List<dynamic>();

            try
            {
                foreach (Organisational_Structure_Position stuctureposition in allgroups)
                {
                    dynamic dynamicPersonGroup = new ExpandoObject();
                    dynamicPersonGroup.OrgStructID = stuctureposition.OrgStructID;
                    dynamicPersonGroup.OrgStructLevel = stuctureposition.OrgStructLevel;
                    dynamicPersonGroup.AssignLeader = stuctureposition.AssignLeader;
                    dynamicPersonGroup.Description = stuctureposition.Description;
                    dynamicPersonGroup.PersonID = stuctureposition.PersonID;
                    dynamicPersonGroup.Name = db.People.Where(x => x.PersonID == stuctureposition.PersonID).Select(o => o.Name).FirstOrDefault();
                    dynamicPersonGroup.Surname = db.People.Where(x => x.PersonID == stuctureposition.PersonID).Select(o => o.Surname).FirstOrDefault();
                    dynamicPersonGroup.OrgStructTypeID = stuctureposition.OrgStructTypeID;
                    dynamicPersonGroup.OrgIndivPosId = stuctureposition.OrgIndivPosID;
                    dynamicPersonGroup.OrgStructIDReportsTo = stuctureposition.OrgStructIDReportsTo;
                    dynamicPersonGroup.OrgGroupID = stuctureposition.OrgGroupID;
                    dynamicPersonGroup.Description = db.Organisational_Group.Where(z => z.OrgGroupID == stuctureposition.OrgGroupID).Select(c => c.Description).FirstOrDefault();
                    dynamicPersonGroup.GroupID1 = stuctureposition.OrgGroupID1;
                    dynamicPersonGroup.GroupID2 = stuctureposition.OrgGroupID2;
                    dynamicPersonGroup.GroupID3 = stuctureposition.OrgGroupID3;

                    dynamicPersonGroups.Add(dynamicPersonGroup);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicPersonGroups;
        }



        //*********GROUPS START************// -- Marno

        //3.7 Add group type-Marno

        [System.Web.Http.Route("api/Groups/AddGroupType")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> AddGroupType([FromBody] Group_Type AddGroupType)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                if (AddGroupType != null)
                {

                    db.Configuration.ProxyCreationEnabled = false;
                    db.Group_Type.Add(AddGroupType);
                    db.SaveChanges();

                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

            }
            return GetGroupTypes();
        }


        //3.8 Search group type -Marno (This is also a view)
        [System.Web.Http.Route("api/Groups/GetGroupTypes")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> GetGroupTypes()
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            db.Configuration.ProxyCreationEnabled = false;
            return GetGroupTypeList(db.Group_Type.ToList());
        }

        private List<dynamic> GetGroupTypeList(List<Group_Type> forClient)
        {
            List<dynamic> dynamicGroupTypes = new List<dynamic>();

            try
            {
                foreach (Group_Type grouptype in forClient)
                {
                    dynamic dynamicGroupType = new ExpandoObject();
                    //assign
                    dynamicGroupType.GroupTypeID = grouptype.GroupTypeID;
                    dynamicGroupType.GroupTypeName = grouptype.GroupTypeName;

                    //add to origional
                    dynamicGroupTypes.Add(dynamicGroupType);
                }
            }
            catch (Exception e)
            {

            }

            return dynamicGroupTypes;
        }


        //3.9 Update group type - Marno
        [System.Web.Http.Route("api/Groups/UpdateGroupType")]
        [System.Web.Mvc.HttpPost]
        public List<dynamic> UpdateFood([FromBody] Group_Type newGroupType)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                Group_Type updater = db.Group_Type.Where(x => x.GroupTypeID == newGroupType.GroupTypeID).FirstOrDefault();
                updater.GroupTypeName = newGroupType.GroupTypeName;

                db.Group_Type.Attach(updater);
                db.Entry(updater).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

            return GetGroupTypes();
        }

        //3.10 Delete group Type - Marno
        [System.Web.Http.Route("api/Groups/RemoveGroupType")]
        [System.Web.Mvc.HttpDelete]
        public List<dynamic> RemoveGroupType([FromBody] Group_Type groups)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

            try
            {
                Group_Type group = db.Group_Type.Where(x => x.GroupTypeID == groups.GroupTypeID).FirstOrDefault();
                db.Group_Type.Remove(group);
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }

            return GetGroupTypes();
        }

        //Get GroupType by ID
        [System.Web.Http.Route("api/Groups/GetGroupTypeByID/{GroupTypeID}")]
        [System.Web.Mvc.HttpGet]
        public dynamic GetGroupTypeByID(int GroupTypeID)
        {
            ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
            db.Configuration.ProxyCreationEnabled = false;

            //retrieve object where id is equal to id received
            Group_Type thisGroupType = db.Group_Type.Where(x => x.GroupTypeID == GroupTypeID).FirstOrDefault();

            try
            {
                return thisGroupType;//return object
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
