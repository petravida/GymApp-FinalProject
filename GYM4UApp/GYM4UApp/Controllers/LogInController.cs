using System.Web.Http;
using System.Linq;
using System.Security.Claims;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Mvc.RouteAttribute;
using System;

namespace GYM4UApp.Controllers
{
    public class LogInController : ApiController

    {
        //This resource is For all types of role
        [HttpGet]
        //[Route("/resource1")]
        public IHttpActionResult GetResource1()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //return Ok("Hello: " + identity.Name);
            string[] userRoles = new string[] { "SuperAdmin" };
            Console.WriteLine("asd", userRoles);
            return Ok("GetResource 1");
        }

        //This resource is only For Admin and SuperAdmin role
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        //[Route("api/test/resource2")]
        public IHttpActionResult GetResource2()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //var Email = identity.Claims
            //          .FirstOrDefault(c => c.Type == "Email").Value;

            //var UserName = identity.Name;

            //return Ok("Hello " + UserName + ", Your Email ID is :" + Email);
            return Ok("GetResource 2");
        }

        //This resource is only For SuperAdmin role
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        //[Route("api/test/resource3")]
        public IHttpActionResult GetResource3()
        {
            //var identity = (ClaimsIdentity)User.Identity;
            //var roles = identity.Claims
            //            .Where(c => c.Type == ClaimTypes.Role)
            //            .Select(c => c.Value);
            //return Ok("Hello " + identity.Name + "Your Role(s) are: " + string.Join(",", roles.ToList()));
            return Ok("GetResource 3");
        }
        
    }
}