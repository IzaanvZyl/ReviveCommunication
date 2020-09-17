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

namespace RC_API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        //Database connection
        ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();

        [System.Web.Http.Route("api/Login/RegisterPerson")]
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult RegisterPerson([FromBody] Person person)
        {
            db.Configuration.ProxyCreationEnabled = false;

            dynamic toReturn = new ExpandoObject();
            var hash = GenerateHash(ApplySomeSalt(person.Password));


            if (person == null)
            {
                return BadRequest(ModelState);
            }
            try
            {
                person.Activation_Status_ID = 4;
                person.Password = hash;
                db.People.Add(person);
                db.SaveChanges();

                //string n = person.Name;
                //string s = person.Surname;
                //string num = person.Number;
                //string e = person.Email;

                //Person newPerson = db.People.Where(z => z.Name == n && z.Surname == s && z.Number == num && z.Email == e).FirstOrDefault();

                //NMO_Follow_Up newFollowUp = new NMO_Follow_Up();
                //newFollowUp.Person.PersonID = newPerson.PersonID;

                //db.NMO_Follow_Up.Add(newFollowUp);
                //db.SaveChanges();

            }
            catch (Exception e)
            {
                toReturn.Error = e.Message;
                return toReturn;
            }

            return Ok(person);
        }

        //[Route("api/Person/RegisterChild")]
        //[HttpPost]

        //public IHttpActionResult RegisterChild([FromBody] Child child)
        //{
        //    ReviveCommunicationsDBEntities3 db = new ReviveCommunicationsDBEntities3();
        //    db.Configuration.ProxyCreationEnabled = false;


        //    dynamic toReturn = new ExpandoObject();


        //    //public IHttpActionResult PostUser(User data)
        //    {

        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        try
        //        {
        //            db.Children.Add(child);
        //            db.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {

        //            toReturn.Error = e.Message;
        //            return toReturn;

        //        }
        //        return Ok(child);

        //    }


        //}



        //Person Details
        [Route("api/Login/PersonDetails")]
        [HttpPost]

        public object PersonDetails(dynamic sess)
        {
            string SessionID = sess.SessionID;
            var person = db.People.Where(zz => zz.SessionID == SessionID).FirstOrDefault();

            dynamic Person = new ExpandoObject();
            Person.PersonID = person.PersonID;
            Person.Name = person.Name;
            Person.Surname = person.Surname;



            if (person != null)
            {
                person.Password = "You can't see this!";
                return Person;
            }
            else
            {
                dynamic toReturn = new ExpandoObject();
                toReturn.Error = "Invalid token!";
                return toReturn;

            }
        }



        //Login
        [Route("api/Login/Login")]
        [HttpPost]
        public object Login([FromBody] Person person)

        {

            var hash = GenerateHash(ApplySomeSalt(person.Password));
            var p = db.People.Where(zz => zz.Password == hash &&  zz.Username == person.Username ).FirstOrDefault();

            dynamic toReturn = new ExpandoObject();


            try
            {
                if (p != null)
                {
                    if (p.Activation_Status_ID == 1)
                    {

                        Guid g = Guid.NewGuid();
                        p.SessionID = g.ToString();
                        db.Entry(p).State = EntityState.Modified;

                        db.SaveChanges();
                        toReturn.SessionID = g.ToString();
                        return toReturn;
                    }
                    else
                    {
                        toReturn.Error = "Incorrect Username or Password!";
                    }
                }
                else
                {
                    toReturn.Error = "You do not have access.";
                }



            }
            catch (Exception e)
            {
                //dynamic toReturn = new ExpandoObject();

                if (e != null)
                {
                    toReturn.Error = e.Message + e.InnerException;
                    return toReturn;
                }
                else
                {
                    return null;
                }
            }

            return toReturn;
        }

        //----------------------reset password--------------------------------------------
        [HttpPut]
        [Route("ResetPassword")]


        //update password
        public IHttpActionResult ResetPassword([FromBody] Person psn)
        {
            dynamic toReturn = new ExpandoObject();
            var hash = GenerateHash(ApplySomeSalt(psn.Password));
            Person p = db.People.Where(zz => zz.Username == psn.Username && zz.DateOfBirth == psn.DateOfBirth).FirstOrDefault();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (psn != null)
            {
                try
                {
                    Person objEmp = new Person();
                    objEmp = db.People.Find(psn.PersonID);
                    if (objEmp != null)
                    {
                        objEmp.Password = psn.Password;


                    }
                    int i = this.db.SaveChanges();

                }
                catch (Exception e)
                {
                    toReturn.Error = e.Message;
                    return toReturn;
                }
            }
            return Ok(psn);
        }

        //Password hashing

        public static string ApplySomeSalt(string input)
        {
            return input + "ekhounievanuniversiteitnietuksislelikmetmyhelp";
        }

        public static string GenerateHash(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));

            }
            return result.ToString();
        }

        //Send OTP
    }
}