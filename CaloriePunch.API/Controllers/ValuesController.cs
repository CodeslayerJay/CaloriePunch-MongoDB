using CaloriePunch.API.Utils;
using CaloriePunch.Data;
using CaloriePunch.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaloriePunch.API.Controllers
{

    public class ValuesController : BaseApiController
    {
        private readonly ILogService _logger;

        public ValuesController(ILogService logService)
        {
            _logger = logService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(AppConstants.GenericErrorMsg);
            }
        }

    }
}
