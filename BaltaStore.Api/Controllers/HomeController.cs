﻿using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Version 0.0.1";
        }
    }
}
