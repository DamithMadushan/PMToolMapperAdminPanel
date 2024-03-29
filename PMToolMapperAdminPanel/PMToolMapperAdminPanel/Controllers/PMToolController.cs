﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PMToolMapperAdminPanel.Models.DBModels;

namespace PMToolMapperAdminPanel.Controllers
{
    public class PMToolController : Controller
    {
        private readonly ILogger<PMToolController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PMTDBContext _context;

        public PMToolController(ILogger<PMToolController> logger, IHttpContextAccessor httpContextAccessor, PMTDBContext context)
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
        public async Task<IActionResult> addTool(string toolname)
        {

            PMTool pMTool = new PMTool
            {
                ToolName =toolname
            };

            _context.Add(pMTool);
            await _context.SaveChangesAsync();

            if (pMTool.ToolId > 0)
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
        public async Task<IActionResult> getTools()
        {

            var pmtools = _context.pMTools.ToList();


            return Json(new { IsValid = true, tools = pmtools });

        }
    }

    public class Tool { 
    
        public string toolname { get; set; }
    }
}