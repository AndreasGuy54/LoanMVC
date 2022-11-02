using LoanMVC.Helpers;
using LoanMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoanMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult MortgagePage()
        {
            Loan model = new();

            model.Payment = 0;
            model.TotalInterest = 0;
            model.TotalCost = 0;
            model.Rate = 3.5;
            model.Amount = 15000;
            model.Term = 60;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MortgagePage(Loan model)
        {
            LoanHelper loanHelper = new();

            Loan newLoan = loanHelper.GetPayments(model);
            return View(newLoan);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}