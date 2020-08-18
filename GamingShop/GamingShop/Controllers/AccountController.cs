using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using GamingShop.Areas.Identity.Data;
using GamingShop.Models;
using GamingShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GamingShop.Controllers
{
    public class AccountController : Controller
    {
        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        DBGamingShop dbGamingShop;
        public AccountController(UserManager<ApplicationUser> _userManager
            , DBGamingShop _dbGamingShop, SignInManager<ApplicationUser> _signInManager)
        {
            userManager = _userManager;
            dbGamingShop = _dbGamingShop;
            signInManager = _signInManager;
        }
        public async Task<IActionResult> RegisterConfirm(UserRegisterViewModel model)
        {
            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser.Email = model.Email;
            applicationUser.UserName = model.Username;
            applicationUser.PhoneNumber = model.Tell;

            var status = await userManager.CreateAsync(applicationUser, model.Password);
            if (status.Succeeded)
            {
                string token = await userManager.GenerateEmailConfirmationTokenAsync(applicationUser);
                string href =
                    Url.Action("AccountConfirm", "Register", new { id = applicationUser.Id, token = token }, "https");
                string body = $@"Hello <b>{model.Username} {model.Email}</b><br/>
                                 Click <a href='{href}'>here</a> account Maked";

                System.Net.Mail.MailMessage mailMessage =
                    new System.Net.Mail.MailMessage("mohammadpourmvc@gmail.com", model.Email);
                mailMessage.Subject = "Reset Password ";
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("mohammadpourmvc@gmail.com", "reza_1234567890");
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch
                {
                    TempData["msg"] = "ایمیل تغییر رمز به آدرس شما ارسال نگردید";
                }
                TempData["msg"] = "ایمیل تغییر رمز به آدرس شما ارسال گردید";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("RegisterLogin");
            }
        }

        public IActionResult LoginRegister(string returnurl)
        {
            ViewData["returnurl"] = returnurl;
            return View();
        }
        public IActionResult NotAuthorized(string returnurl)
        {
            ViewData["returnurl"] = returnurl;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
        public async Task<IActionResult> LoginConfirm(UserLoginViewModel model)
        {
            var u = dbGamingShop.ApplicationUsers.FirstOrDefault(x => x.UserName == model.Username);
            var status = await signInManager.PasswordSignInAsync(u, model.Password, model.RememberMe, true);
            if (status.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Account", "Register");
            }
        }
    }
}