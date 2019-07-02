using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LedTestPreview.Models;
using LedTestPreview.ViewModels;

namespace LedTestPreview.Controllers
{
    public class LedController : Controller
    {
        static LedViewModel ledVM = new LedViewModel();

        public IActionResult Index()
        {
            ledVM.Ports = Device.GetPorts();
            return View(ledVM);
        }

        public IActionResult Connect(string port)
        {

            ledVM.dev.Port = port;
            return RedirectToAction("Main");
        }

        public IActionResult Main()
        {
            return View(ledVM);
        }

            public IActionResult Start()
        {
            Device.Initializing(ledVM.dev.Port);
            Device.Start();
            return RedirectToAction("Main");
        }

        public IActionResult Stop()
        {
            Device.Stop();
            return RedirectToAction("Main");
        }

        public IActionResult Send(string symbol)
        {
            Device.Send(symbol);
            Console.Beep(1000,1000);

            

            return RedirectToAction("Main");

        }



    }
}