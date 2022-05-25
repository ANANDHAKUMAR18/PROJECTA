using FinalPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FinalPro.DAL;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace FinalPro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AddDoctor()
        {
            return View();
        }
        public IActionResult Successful1()
        {
            return View();
        }
        public IActionResult Successful2()
        {
            return View();
        }
        public IActionResult Successful3()
        {
            return View();
        }
        public IActionResult DoctorAD(AddDoctor AD)
        {
            Pro mobj = new Pro();
            int result = mobj.DoctorAd(AD);
            if (result == 1)
                return RedirectToAction("Successful1");
            else
                return View(" AddDoctor");
        }
  
        public IActionResult AddPatient()
        {
            return View();
        }
        public IActionResult PatientAD(AddPatient AD)
        {
            Pro aobj = new Pro();
            int result = aobj.PatientAD(AD);
            if (result == 1)
                return RedirectToAction("Successful2");
            else
                return View("AddPatient");
        }
        public IActionResult Schedule()
        {
            return View();
        }
        public IActionResult SchedAD(Schedule AD)
        {
            Pro cobj = new Pro();
            int result = cobj.SchedAD(AD);
            if (result == 1)
                return RedirectToAction("Successful3");
            else
                return View("Schedule");
        }
        public IActionResult Homepagee()
        {
            return View();
        }
        public IActionResult Validate(Login us)
        {
            if (ModelState.IsValid)
            {
                Pro pobj = new Pro();
                int result = pobj.CheckUse(us);
                if (result == 1)
                {
                    return View("Homepagee");
                }
                else
                {
                    return View("ValidMsg");
                }

            }
            else
            {
                return View("Index");
            }
        }
      
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Deletee(Schedule C)
        {
            int result;
            int PatientID = C.PatientID;
       
            
                Pro cobj = new Pro();
                result = cobj.DeleteData(C);
                return RedirectToAction("Cancelappo", C);
            


           
        }
        


        public IActionResult Cancelappo()
        {
            Pro custDAL = new Pro();
            List<Schedule> CustomerList = new List<Schedule>();
            CustomerList = custDAL.cancelapp();
            return View(CustomerList);
            //return View();
        }

     






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
    }

