namespace LasMarias.WareHouse.Controllers;

using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Net;    
using System.Net.Http;    
using System.Web;    
using LasMarias.WareHouse.Domain.Repositories;
using Orun;

[Route("")]
public class HomeController: Controller
{
    public IActionResult Index()
    {
        return Ok("this is suppose to be the index page");
    }
}