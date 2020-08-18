using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using GamingShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingShop.Controllers
{
    public class DashboardController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public DashboardController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        [Authorize]
        public IActionResult UserMainDashboard()
        {
            var user = dbGamingShop.ApplicationUsers.FirstOrDefault(x => x.UserName == User.Identity.Name);
            TempData["MyAccountCount"] = dbGamingShop.TblProducts.Where(x => x.UserId == user.Id).Count();
            TempData["MyTicketCount"] = dbGamingShop.TblTickets.Where(x => x.UserId == user.Id).Count();
            //TempData["Factors"] = dbGamingShop.TblFactors.Where(x => x.SellerUserId == user.Id).ToList();
            return View(dbGamingShop.TblFactors.Include(x => x.TblAll).Include(x => x.TblPlatform).Include(x => x.TblCategory).Where(x => x.SellerUserId == user.Id).ToList());
        }
        [Authorize]
        public IActionResult MyAccountCount()
        {
            var user = dbGamingShop.ApplicationUsers.FirstOrDefault(x => x.UserName == User.Identity.Name);

            return View(dbGamingShop.TblProducts.Include(x => x.TblAll).Include(x => x.TblPlatform).Include(x => x.TblCategory).Where(x => x.UserId == user.Id).ToList());
        }
        [Authorize]
        public IActionResult UserDashboardTicket()
        {
            var user = dbGamingShop.ApplicationUsers.FirstOrDefault(x => x.UserName == User.Identity.Name);

            return View();
        }
        public async Task<IActionResult> LogoutFromDashboard()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}