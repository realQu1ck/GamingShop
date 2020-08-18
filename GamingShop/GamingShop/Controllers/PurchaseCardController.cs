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
    public class PurchaseCardController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public PurchaseCardController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        [Authorize]
        public IActionResult RemoveFromPurchasCart(int purchasecartItemId)
        {
            try
            {
                TblPurchaseCartItem purchaseCartItem = dbGamingShop.Find<TblPurchaseCartItem>(purchasecartItemId);
                int purchasecartid = purchaseCartItem.PurchaseCartId;
                dbGamingShop.Remove<TblPurchaseCartItem>(purchaseCartItem);
                dbGamingShop.SaveChanges();
                return Json(new
                {
                    status = true,
                    totalsum = $"{CalculateTotalSumPurchaseCart(purchasecartid):0,0} تومان",
                    count = dbGamingShop.TblPurchaseCartItems.Count(x => x.PurchaseCartId == purchasecartid)
                });
            }
            catch
            {
                return Json(false);
            }
        }
        [Authorize]
        public async Task<IActionResult> BuyAll()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = dbGamingShop.TblPurchaseCarts.Where(x => x.CustomerId == user.Id).FirstOrDefault();
            cart.ispaied = true;
            dbGamingShop.Update(cart);
            dbGamingShop.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
        [Authorize]
        public IActionResult ChangeCountInItem(int purchasecartItemId, int count)
        {
            var item = dbGamingShop.Find<TblPurchaseCartItem>(purchasecartItemId);
            item.count = count;
            dbGamingShop.Update(item);
            dbGamingShop.SaveChanges();

            return Json(new
            {
                status = true,
                totalsum = $"{CalculateTotalSumPurchaseCart(item.PurchaseCartId):0,0} تومان",
                totalsumOfItem = $"{dbGamingShop.Find<TblProduct>(item.ProductId).Price * count:0,0} تومان"
            });
        }
        [Authorize]
        public async Task<IActionResult> MyPurchaseCard()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var purchasecase =
                    dbGamingShop.TblPurchaseCarts.FirstOrDefault(x => !x.ispaied && x.CustomerId == user.Id);

                if (purchasecase != null)
                {
                    var items = dbGamingShop.TblPurchaseCartItems.Include(x => x.TblProduct).ThenInclude(x => x.TblProductImgs).ThenInclude(x => x.TblProduct).
                        ThenInclude(x => x.TblCategory).Include(x => x.TblProduct).ThenInclude(x => x.TblPlatform).Include(x => x.TblProduct).ThenInclude(x => x.TblAll)
                                    .Where(x => x.PurchaseCartId == purchasecase.Id).ToList();
                    ViewData["TotalSumPurchaseCart"] = CalculateTotalSumPurchaseCart(purchasecase.Id);
                    return View(items);
                }
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> AddToCart(int cartid)
        {
            var userID = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            TblPurchaseCart purchaseCart = dbGamingShop.TblPurchaseCarts
                .FirstOrDefault(x => x.ispaied == false && x.CustomerId == userID);
            if (purchaseCart != null)
            {
                if (dbGamingShop.TblPurchaseCartItems.Count(x =>
                         x.PurchaseCartId == purchaseCart.Id && x.ProductId == cartid) > 0)
                {
                    return Json(true);
                }
            }
            if (purchaseCart == null)
            {
                purchaseCart = new TblPurchaseCart
                {
                    creationDate = DateTime.Now,
                    CustomerId = userID,
                    ispaied = false,
                };
                dbGamingShop.Add(purchaseCart);
                dbGamingShop.SaveChanges();
            }
            if (dbGamingShop.TblPurchaseCartItems.Count(x => x.PurchaseCartId == purchaseCart.Id && x.ProductId == cartid)
                == 0)
            {
                TblPurchaseCartItem purchaseCartItem = new TblPurchaseCartItem()
                {
                    count = 1,
                    ProductId = cartid,
                    PurchaseCartId = purchaseCart.Id
                };
                dbGamingShop.Add(purchaseCartItem);
                dbGamingShop.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        [Authorize]
        public string CalculateTotalSumPurchaseCart(int purchasecartId)
        {
            var items = dbGamingShop.TblPurchaseCartItems.Include(x => x.TblProduct)
                .Where(x => x.PurchaseCartId == purchasecartId).ToList();

            //int i = 12345680;
            //$"{i:0,0}"

            return $"{items.Sum(x => x.count * x.TblProduct.Price):0,0}";
        }

    }
}