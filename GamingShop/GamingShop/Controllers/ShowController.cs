using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using GamingShop.Classes;
using GamingShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamingShop.Controllers
{
    public class ShowController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public ShowController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        public IActionResult ShowProductByName(int tabid)
        {
            var data = dbGamingShop.TblProducts.Select(x => x.PlatformId == tabid).ToList();
            return View(data);
        }
        public IActionResult ShowXboxProducts()
        {
            return View(dbGamingShop.TblProducts.Where(x => x.PlatformId == 2).Include(x => x.TblProductImgs).Include(x => x.TblAll).Include(X => X.TblCategory).ToList());
        }
        public IActionResult ShowPS4Products()
        {
            return View(dbGamingShop.TblProducts.Where(x => x.PlatformId == 1).Include(x => x.TblProductImgs).Include(x => x.TblAll).Include(X => X.TblCategory).ToList());
        }
        public IActionResult ShowPCProducts()
        {
            return View(dbGamingShop.TblProducts.Where(x => x.PlatformId == 3).Include(x => x.TblProductImgs).Include(x => x.TblAll).Include(X => X.TblCategory).ToList());
        }
        public IActionResult ShowAllProducts()
        {
            return View(dbGamingShop.TblProducts.Include(x => x.TblProductImgs).Include(x => x.TblAll).Include(X => X.TblCategory).ToList());
        }
        public IActionResult CheckQuickView(int cartid)
        {
            var data = dbGamingShop.TblProducts.Where(x => x.Id == cartid).FirstOrDefault();
            TempData["dataprice"] = data.Price;
            ShareInfo.Price = data.Price;
            if (data == null)
            {
                return Json(false);
            }
            else
            {
                TempData["ShowProduct"] = "sda";
                return Json(true);
            }
        }
        public IActionResult QuickView()
        {
            return View();
        }
        public IActionResult ShowAllPlatforms()
        {
            return View(dbGamingShop.TblPlatforms.ToList());
        }
        public IActionResult ShowAllCatogrys()
        {
            return View(dbGamingShop.TblCategories.ToList());
        }
    }
}