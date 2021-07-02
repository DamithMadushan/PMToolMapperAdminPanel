using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMToolMapperAdminPanel.Models.DBModels;

namespace PMToolMapperAdminPanel.Controllers
{
    public class ToolFeaturesController : Controller
    {
        private readonly ILogger<PMToolController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PMTDBContext _context;

        public ToolFeaturesController(ILogger<PMToolController> logger, IHttpContextAccessor httpContextAccessor, PMTDBContext context)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                _httpContextAccessor.HttpContext.Session.SetString("User_Name", HttpContext.Session.GetString("UserFullName").ToString());

                return View();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addFeature(string featurename)
        {

            AllFeatures allFeatures = new AllFeatures
            {
                 FeatureName = featurename
            };

            _context.Add(allFeatures);
            await _context.SaveChangesAsync();

            if (allFeatures.FeatureId > 0)
            {
                return Json(new { IsValid = true });
            }
            else
            {
                return Json(new { IsValid = false });
            }

        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> getFeatures()
        {

            var Features = _context.allFeatures.ToList();


            return Json(new { IsValid = true, features = Features });

        }
    }

    public class Features
    {

        public string featurename { get; set; }
    }
}