using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstwebMVC.Models;

namespace FirstwebMVC.Controllers;

public class PersonController : Controller
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

}
