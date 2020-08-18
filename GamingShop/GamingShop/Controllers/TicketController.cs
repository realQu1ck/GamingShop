using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using GamingShop.Models;
using GamingShop.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamingShop.Controllers
{
    public class TicketController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public TicketController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        [Authorize]
        public IActionResult Ticket()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> SendTicketConfirm(TicketViewModel model)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            var userID = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            TblTicket tblTicket = new TblTicket()
            {
                UserId = userID,
                Subject = model.Subject,
                Text = model.Text
            };

            dbGamingShop.Add(tblTicket);
            dbGamingShop.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}