using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using PMToolMapperAdminPanel.Models.DBModels;

namespace PMToolMapperAdminPanel.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PMTDataController : ControllerBase
    {
        private readonly ILogger<PMTDataController> _logger;
        private readonly PMTDBContext _context;

        public PMTDataController(ILogger<PMTDataController> logger, PMTDBContext context)
        {
            _logger = logger;
            _context = context;

        }


        [HttpGet("{apiname}", Name = "getTools")]
        public IActionResult getTools()
        {

            var pmtools = _context.pMTools.ToArray().OrderBy(x => x.ToolId);

            return new JsonResult(pmtools);

        }



        [HttpGet]
        public ActionResult getAllFeatures()
        {

            var allfeatures = _context.allFeatures.ToArray().OrderBy(x => x.FeatureId);

            return new JsonResult(new { _allfeatures = allfeatures });

        }



        [HttpGet]
        public ActionResult getToolFeatureCategories()
        {

            var featureCategories = _context.toolFeatureCategories.ToArray().OrderBy(x => x.FeatureCategoryId);

            return new JsonResult(new { _featureCategories = featureCategories });

        }


        [HttpGet]
        public ActionResult getToolFeatures()
        {

            var toolFeatures = _context.toolFeatures.ToArray().OrderBy(x => x.Id);

            return new JsonResult(new { _toolFeatures = toolFeatures });

        }


    }
}