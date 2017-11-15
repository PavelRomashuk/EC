using EC.DataAccess.BLL;
using EC.Models;
using EC.Web.Convertors;
using EC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EC.Web.Controllers
{
    public class AccountController : Controller
    {
        protected UserViewModelToUserCovertor _userViewModelToUserCovertor;
        protected UsersBLL _userBLL;

        public AccountController()
        {
            InitializeMembers();
        }

        private void InitializeMembers()
        {
            _userViewModelToUserCovertor = new UserViewModelToUserCovertor();
            _userBLL = new UsersBLL();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogonModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = _userViewModelToUserCovertor.Convert(model);
                UserLogonResponse response = _userBLL.Logon(model.UserName, model.Password);
                if (response.ResponseStatus == ResponseStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    else
                        return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", response.Message);
            }
            else
                ModelState.AddModelError("", "");
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _userViewModelToUserCovertor.Convert(model);
                _userBLL.CreateUser(user);
            }

            return View(model);
        }

        
    }
}