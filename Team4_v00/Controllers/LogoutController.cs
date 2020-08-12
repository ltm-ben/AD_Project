﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ben_Project.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            Response.Cookies.Delete("sessionId");
            TempData.Clear();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}