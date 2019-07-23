using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevEK.App.ViewModels;

namespace DevEK.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelErro = new ErrorViewModel();

            if (id == 500)
            {
                modelErro.Message = "Something got wrong! Please try agina late or contact our support.";
                modelErro.Title = "An error has occurred!";
                modelErro.ErrorCode = id;
            }
            else if (id == 404)
            {
                modelErro.Message = "The page that you are looking for not exist! <br />Please you have an question, contact our support";
                modelErro.Title = "Ops! Page not found.";
                modelErro.ErrorCode = id;
            }
            else if (id == 403)
            {
                modelErro.Message = "You do not have permission to do it.";
                modelErro.Title = "Access denied";
                modelErro.ErrorCode = id;
            }
            else
            {
                return StatusCode(500);
            }

            return View("Error", modelErro);
        }
    }
}
