using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rationality.Controllers
{
    public class MockupsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AllForums()
        {
            return this.View();
        }

        public IActionResult SingleForum()
        {
            return this.View();
        }

        public IActionResult SingleTopic()
        {
            return this.View();
        }

        public IActionResult Settings()
        {
            return this.View();
        }

        public IActionResult Days()
        {
            return this.View();
        }

        public IActionResult Money()
        {
            return this.View();
        }

        public IActionResult Parameters()
        {
            return this.View();
        }

        public IActionResult Products()
        {
            return this.View();
        }

        public IActionResult Signin()
        {
            return this.View();
        }

        public IActionResult Signup()
        {
            return this.View();
        }

        public IActionResult recipe()
        {
            return this.View();
        }
    }
}
