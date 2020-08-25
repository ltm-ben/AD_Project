﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ben_Project.DB;
using Ben_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ben_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly LogicContext _dbContext;

        public LoginController(LogicContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string hashPasswd)
        {
            Employee user = _dbContext.Employees.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            if (user.Password != hashPasswd)
            {
                return RedirectToAction("Index");
            }

            
            HttpContext.Session.SetString("username", user.Name);
            HttpContext.Session.SetString("loginName", user.Username);
            HttpContext.Session.SetInt32("Id", user.Id);
            HttpContext.Session.SetString("Role", user.Role.ToString());

            if (user.Role == DeptRole.StoreClerk) {
                return RedirectToAction("BarChart", "Store");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}