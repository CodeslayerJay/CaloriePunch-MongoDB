using CaloriePunch.Services;
using CaloriePunch.Services.Interfaces;
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
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly ILogService _logger;

        public BaseApiController(ILogService logService)
        {
            _logger = logService;
        }

        protected void LogError(string msg)
        {
            if(string.IsNullOrEmpty(msg) == false)
            {
                _logger.LogError(msg);
            }
        }

        protected void LogMsg(string msg)
        {
            if (string.IsNullOrEmpty(msg) == false)
            {
                _logger.AddLog(msg);
            }
        }

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
