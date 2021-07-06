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
    public class SetFeaturesController : Controller
    {
        private readonly ILogger<PMToolController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PMTDBContext _context;

        public SetFeaturesController(ILogger<PMToolController> logger, IHttpContextAccessor httpContextAccessor, PMTDBContext context)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _context = context;

        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("LoginStatus") == "Logged")
            {
                _httpContextAccessor.HttpContext.Session.SetString("User_Name", HttpContext.Session.GetString("UserFullName").ToString());

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> getTools()
        {

            var pmtools = _context.pMTools.ToList().OrderBy(x => x.ToolName);


            return Json(new { IsValid = true, tools = pmtools });

        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> getToolFeatureCategory()
        {

            var pmtoolcat = _context.toolFeatureCategories.ToList().OrderBy(x => x.FeatureCategoryName);


            return Json(new { IsValid = true, Categories = pmtoolcat });

        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> getToolFeatures()
        {

            var _features = _context.allFeatures.ToList().OrderBy(x => x.FeatureName);


            return Json(new { IsValid = true, features = _features });

        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> addToolFeatures(ToolFeatures toolFeatures)
        {
            toolFeatures.Date = DateTime.Now;

            _context.Add(toolFeatures);
            await _context.SaveChangesAsync();

            if (toolFeatures.Id > 0)
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
        public async Task<IActionResult> getToolFeatureDetails()
        {
            var _toolFeatures = (from tf in _context.toolFeatures
                                join af in _context.allFeatures on tf.FeatureId equals af.FeatureId
                                join pmt in _context.pMTools on tf.ToolId equals pmt.ToolId
                                join tc in _context.toolFeatureCategories on tf.FeatureCategoryId equals tc.FeatureCategoryId
                                select new { 
                                
                                    tf.Id,
                                    pmt.ToolName,
                                    af.FeatureName,
                                    tc.FeatureCategoryName,
                                    tf.FeatureUrl,
                                    tf.FeatureStatus
                                
                                }).OrderBy(x => x.ToolName).ThenBy(x => x.FeatureName).ToList();

            if (_toolFeatures != null)
            {
                return Json(new { features = _toolFeatures });
            }
            else
            {
                return Json(new { features = "" });
            }

        }

    }
}