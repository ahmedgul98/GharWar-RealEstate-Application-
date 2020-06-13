using RealEstateAPIS1.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealEstateAPIS1.Models;

namespace RealEstateAPIS1.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("Login")]
        public bool Login(Login log)
        {

            return Usersecurity.Login(log.username, log.password);
        }

        [HttpPost]
        [Route("api/Register")]
        public bool Signup(user u)
        {

            if(Usersecurity.signup( u.username, u.password, u.email, u.ph))
            {
                //return new HttpResponseMessage(HttpStatusCode.OK);
                return true;
            }
            return false;
           // return new HttpResponseMessage(HttpStatusCode.BadRequest);

        }
        [Route("Api/GetEmails")]
        public List<string> getEmails()
        {

            return Usersecurity.GetEmails();
        }
    }
}
