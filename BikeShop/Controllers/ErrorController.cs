using Microsoft.AspNetCore.Mvc;

namespace BikeShop.Controllers;

[Route("error")]
public class ErrorController : Controller
{
    [HttpGet("not-found")]
    public IActionResult NotFoundResult()
    {
        return View();
    }
}