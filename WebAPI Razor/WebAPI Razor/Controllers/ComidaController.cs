﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_Razor.Controllers
{
    public class ComidaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
