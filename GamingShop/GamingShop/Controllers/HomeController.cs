using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using GamingShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingShop.Controllers
{
    public class HomeController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public HomeController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        public IActionResult Index()
        {
            //TempData["Product"] = dbGamingShop.TblGameProducts.ToList();
            TempData["Platforms"] = dbGamingShop.TblPlatforms.ToList();
            return View(dbGamingShop.TblProducts.Include(x => x.TblProductImgs).Include(x => x.TblAll).Include(X => X.TblCategory).ToList());
        }
        public IActionResult GetProductOnIndex(string value)
        {
            TempData["Platforms"] = dbGamingShop.TblPlatforms.ToList();
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }
    }
}