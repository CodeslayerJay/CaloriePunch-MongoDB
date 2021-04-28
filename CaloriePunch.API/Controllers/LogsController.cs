using CaloriePunch.API.Utils;
using CaloriePunch.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CaloriePunch.API.Controllers
{

    public class LogsController : BaseApiController
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService) : base(logService)
        {
            _logService = logService;
        }

        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(_logService.GetLogs());
            }
            catch(Exception ex)
            {
                base.LogError(ex.StackTrace);
                return base.ErrorResponse(ex);
            }
        }

        
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}
    }
}
