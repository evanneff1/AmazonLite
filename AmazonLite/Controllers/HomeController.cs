using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AmazonLite.Models;

namespace AmazonLite.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }
    
}