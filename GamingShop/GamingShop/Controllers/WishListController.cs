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
    public class WishListController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public WishListController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        [Authorize]
        public IActionResult RemoveFromWishList(int WishListItemId)
        {
            try
            {
                TblWishListItem WishListCartItem = dbGamingShop.Find<TblWishListItem>(WishListItemId);
                int WishListcartid = WishListCartItem.WishCartId;
                dbGamingShop.Remove<TblWishListItem>(WishListCartItem);
                dbGamingShop.SaveChanges();
                return Json(new
                {
                    status = true,
                    totalsum = $"{CalculateTotalSumWishList(WishListcartid):0,0} تومان",
                    count = dbGamingShop.TblPurchaseCartItems.Count(x => x.PurchaseCartId == WishListcartid)
                });
            }
            catch
            {
                return Json(false);
            }
        }
        [Authorize]
        public IActionResult ChangeCountInItem(int WishListItemId, int count)
        {
            var item = dbGamingShop.Find<TblWishListItem>(WishListItemId);
            item.count = count;
            dbGamingShop.Update(item);
            dbGamingShop.SaveChanges();

            return Json(new
            {
                status = true,
                totalsum = $"{CalculateTotalSumWishList(item.WishCartId):0,0} تومان",
                totalsumOfItem = $"{dbGamingShop.Find<TblProduct>(item.ProductId).Price * count:0,0} تومان"
            });
        }

        public async Task<IActionResult> MyWishList()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var purchasecase =
                    dbGamingShop.TblWishLists.FirstOrDefault(x => !x.ispaied && x.CustomerId == user.Id);

                if (purchasecase != null)
                {
                    var items = dbGamingShop.TblWishListItems.Include(x => x.TblProduct).ThenInclude(x => x.TblProductImgs).ThenInclude(x => x.TblProduct).
                        ThenInclude(x => x.TblCategory).Include(x => x.TblProduct).ThenInclude(x => x.TblPlatform).Include(x => x.TblProduct).ThenInclude(x => x.TblAll)
                                    .Where(x => x.WishCartId == purchasecase.Id).ToList();
                    ViewData["TotalSumWishCart"] = CalculateTotalSumWishList(purchasecase.Id);
                    return View(items);
                }
            }
            return View();
        }
        [Authorize]
        public async Task<IActionResult> AddToCart(int cartid)
        {
            var userID = (await userManager.FindByNameAsync(User.Identity.Name)).Id;
            TblWishList WishCart = dbGamingShop.TblWishLists
                .FirstOrDefault(x => x.ispaied == false && x.CustomerId == userID);
            if (WishCart != null)
            {
                if (dbGamingShop.TblWishListItems.Count(x =>
                         x.WishCartId == WishCart.Id && x.ProductId == cartid) > 0)
                {
                    return Json(true);
                }
            }
            if (WishCart == null)
            {
                WishCart = new TblWishList
                {
                    creationDate = DateTime.Now,
                    CustomerId = userID,
                    ispaied = false,
                };
                dbGamingShop.Add(WishCart);
                dbGamingShop.SaveChanges();
            }
            if (dbGamingShop.TblWishListItems.Count(x => x.WishCartId == WishCart.Id && x.ProductId == cartid)
                == 0)
            {
                TblWishListItem WishListCartItem = new TblWishListItem()
                {
                    count = 1,
                    ProductId = cartid,
                    WishCartId = WishCart.Id
                };
                dbGamingShop.Add(WishListCartItem);
                dbGamingShop.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public string CalculateTotalSumWishList(int purchasecartId)
        {
            var items = dbGamingShop.TblWishListItems.Include(x => x.TblProduct)
                .Where(x => x.WishCartId == purchasecartId).ToList();

            //int i = 12345680;
            //$"{i:0,0}"

            return $"{items.Sum(x => x.count * x.TblProduct.Price):0,0}";
        }
    }
}