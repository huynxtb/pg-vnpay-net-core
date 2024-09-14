using CodeMegaVNPay.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CodeMegaVNPay.Services;

namespace CodeMegaVNPay.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVnPayService _vnPayService;

        public HomeController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePaymentUrl(PaymentInformationModel model)
        {
            var url = _vnPayService.CreatePaymentUrl(model, HttpContext);
            
            return Redirect(url);
        }
        
        public IActionResult PaymentCallback()
        {
            var response = _vnPayService.PaymentExecute(Request.Query);
            
            return Json(response);
        }
    }
}