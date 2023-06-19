using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TALLER_3.Controllers
{
   [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }
    }

}