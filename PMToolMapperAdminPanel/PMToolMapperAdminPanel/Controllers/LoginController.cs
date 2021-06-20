using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PMToolMapperAdminPanel.Models.DBModels;

namespace PMToolMapperAdminPanel.Controllers
{
    public class LoginController : Controller
    {

        private readonly PMTDBContext _context;

        public LoginController(PMTDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return Json(new { status = true }); ;
        }


        [HttpPost]
        public async Task<IActionResult> CheckUser(string userName,string password)
        {
            try
            {

                if (IsValidUserAndPasswordCombination(userName, password))
                {

                    var userLogin = await _context.userLogins.FirstOrDefaultAsync(m => m.UserName == userName && m.Paswword == password);
                    if (userLogin == null)
                    {
                        HttpContext.Session.Clear();

                        return Json(new { IsValid = false, message = "User not found!", token = "" });
                    }
                    else
                    {
                        //set sessions
                        HttpContext.Session.SetString("UserFullName", userLogin.UserFullName);
                        HttpContext.Session.SetString("UserName", userLogin.UserName);


                        return Json(new { IsValid = true, message = "", token = GenerateToken(userName) });

                    }


                }
                else
                {
                    HttpContext.Session.Clear();

                    return Json(new { IsValid = false, message = "Username or password is empty!", token = "" });

                }

            }
            catch(Exception ex)
            {

                return Json(new { IsValid = false, message = ex, token = "" });

            }

                

        }

        private bool IsValidUserAndPasswordCombination(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString()),
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret Key You Devise")),
                                             SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
