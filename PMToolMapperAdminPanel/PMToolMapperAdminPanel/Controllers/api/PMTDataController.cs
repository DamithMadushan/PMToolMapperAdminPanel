using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using PMToolMapperAdminPanel.Models.DBModels;

namespace PMToolMapperAdminPanel.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMTDataController : ControllerBase
    {
        private readonly ILogger<PMToolController> _logger;
        private readonly PMTDBContext _context;

        public PMTDataController(ILogger<PMToolController> logger, IHttpContextAccessor httpContextAccessor, PMTDBContext context)
        {
            _logger = logger;
            _context = context;

        }

        //[HttpPost]
        //public async Task<JsonResult> getTools()
        //{

        //    var pmtools = _context.pMTools.ToArray();


        //}

    }
}