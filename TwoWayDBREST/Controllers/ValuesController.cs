using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TwoWayDBREST.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            List<EntityFramework.UserInfo> returnedList = new List<EntityFramework.UserInfo>();
            using (EntityFramework.TwoWayDataBindingEntities entities = new EntityFramework.TwoWayDataBindingEntities())
            {
                var r = (from q in entities.UserInfoes
                         select q).ToList();
                returnedList = r;
            }
            string output = JsonConvert.SerializeObject(returnedList);
            return output;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public JObject Post([FromBody]EntityFramework.UserInfo newuser)
        {
            EntityFramework.UserInfo newUInfo = new EntityFramework.UserInfo
            {
                 UserDayPhone = newuser.UserDayPhone,
                 UserStreet = newuser.UserStreet,
                 UserApartment = newuser.UserApartment,
                 UserCity = newuser.UserCity,
                 UserProvince = newuser.UserProvince,
                 UserPostalCode = newuser.UserPostalCode,
                 UserEmail = newuser.UserEmail
            };

            using (EntityFramework.TwoWayDataBindingEntities entities = new EntityFramework.TwoWayDataBindingEntities())
            {
                entities.UserInfoes.Add(newUInfo);
                entities.SaveChanges();
                var jObject = JObject.Parse("{\"status\": \"success\",\"data\": \"OK\",\"message\": null }");
                return jObject;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}