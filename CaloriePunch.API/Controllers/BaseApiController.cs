using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CaloriePunch.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        public string UserId
        {
            get
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {

                    var claim = identity.FindFirst(q => q.Issuer == "CaloriePunch");

                    return claim.Value ?? "";

                }

                return "";
            }
        }
    }
}
