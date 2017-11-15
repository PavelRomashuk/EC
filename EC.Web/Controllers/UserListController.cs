using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EC.Web.Controllers
{
    public class UserListController : Controller
    {
        // GET: UserList
        public ActionResult Index()
        {
            return View();
        }
    }
}