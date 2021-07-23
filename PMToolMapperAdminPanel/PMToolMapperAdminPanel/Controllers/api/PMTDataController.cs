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


        [HttpGet("{tools}", Name = "getTools")]
        [Route("getTools")]
        public IActionResult getTools()
        {

            var pmtools = _context.pMTools.ToArray().OrderBy(x => x.ToolId);

            return new JsonResult(pmtools);

        }



        [HttpGet("{AllFeatures}", Name = "getAllFeatures")]
        [Route("getAllFeatures")]
        public IActionResult getAllFeatures()
        {

            var allfeatures = _context.allFeatures.ToArray().OrderBy(x => x.FeatureId);

            return new JsonResult(allfeatures);

        }



        [HttpGet("{ToolFeatureCategories}", Name = "getToolFeatureCategories")]
        [Route("getToolFeatureCategories")]
        public IActionResult getToolFeatureCategories()
        {

            var featureCategories = _context.toolFeatureCategories.ToArray().OrderBy(x => x.FeatureCategoryId);

            return new JsonResult(featureCategories);

        }


        [HttpGet("{ToolFeatures}", Name = "getToolFeatures")]
        [Route("getToolFeatures")]
        public IActionResult getToolFeatures()
        {

            var toolFeatures = _context.toolFeatures.ToArray().OrderBy(x => x.Id);

            return new JsonResult(toolFeatures);

        }


    }
}