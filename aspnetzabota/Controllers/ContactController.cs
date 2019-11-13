using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnetzabota.Controllers
{
    public class ContactController : Controller
    {
        public ViewResult Us()
        {
            return View();
        }
    }
}