﻿using E_Commerce_Repository.Models;
using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Areas.Admin.Controllers
{
    public class AddProductController : BaseController {
        // GET: Admin/AddProduct
        public ActionResult Index()
        {
            return View();
        }

    }
}