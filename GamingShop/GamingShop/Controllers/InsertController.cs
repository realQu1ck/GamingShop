using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    public class InsertController : Controller
    {

        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public InsertController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        [Authorize(Policy = "adminpolicy")]
        public IActionResult Insert()
        {
            ViewData["Cat"] = dbGamingShop.TblCategories.ToList();
            ViewData["Pla"] = dbGamingShop.TblPlatforms.ToList();
            ViewData["Gen"] = dbGamingShop.TblGenders.ToList();
            return View();
        }
        public IActionResult InsertProduct()
        {
            ViewData["Cat"] = dbGamingShop.TblCategories.ToList();
            ViewData["Pla"] = dbGamingShop.TblPlatforms.ToList();
            ViewData["Game"] = dbGamingShop.TblAlls.ToList();
            return View();
        }
        public async Task<IActionResult> InsertConfirm(InsertViewModel model)
        {

            TblAll tblAll = new TblAll()
            {
                Name = model.Name,
                ReleaseDate = model.ReleaseDate,
                About = model.About,
                TblImgs = new List<TblImg>(),
                CategoryId = model.CategoryId,
                PlatformId = model.PlatformId,
                GenderId = model.GenderId
            };
            model.Img.ForEach(x =>
            {
                if (x != null)
                {
                    byte[] b = new byte[x.Length];
                    x.OpenReadStream().Read(b, 0, b.Length);
                    var img = Image.FromStream(new MemoryStream(b));
                    Bitmap bitmap = new Bitmap(img, 600, 400 * img.Height / img.Width);
                    MemoryStream thumbnailStream = new MemoryStream();
                    bitmap.Save(thumbnailStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    TblImg productImage = new TblImg
                    {
                        Img = b,
                        ImgThumb = thumbnailStream.ToArray()
                    };
                    tblAll.TblImgs.Add(productImage);
                }
            });

            dbGamingShop.Add(tblAll);
            dbGamingShop.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> InsertProductConfirm(InsertProductViewModel model)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            var userID = (await userManager.FindByNameAsync(User.Identity.Name)).Id;

            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

            var DateTimes = (pc.GetYear(DateTime.Now) + " " + pc.GetMonth(DateTime.Now) + " " + pc.GetDayOfMonth(DateTime.Now));

            TblProduct tblProduct = new TblProduct()
            {
                AllId = model.GameId,
                About = model.About,
                TblProductImgs = new List<TblProductImg>(),
                CategoryId = model.CategoryId,
                PlatformId = model.PlatformId,
                Level = model.Level,
                UserId = userID,
                Price = model.Price,
                SavedDate = DateTimes
            };
            model.Img.ForEach(x =>
            {
                if (x != null)
                {
                    byte[] b = new byte[x.Length];
                    x.OpenReadStream().Read(b, 0, b.Length);
                    var img = Image.FromStream(new MemoryStream(b));
                    Bitmap bitmap = new Bitmap(img, 200, 200 * img.Height / img.Width);
                    MemoryStream thumbnailStream = new MemoryStream();
                    bitmap.Save(thumbnailStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    TblProductImg productImage = new TblProductImg
                    {
                        Img = b,
                        ImgThumb = thumbnailStream.ToArray()
                    };
                    tblProduct.TblProductImgs.Add(productImage);
                }
            });

            dbGamingShop.Add(tblProduct);
            dbGamingShop.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}