using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrationAPI.Services;

namespace QuickBooksIntegrationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuickBooksService _quickBooksService;

        public HomeController(IQuickBooksService quickBooksService)
        {
            _quickBooksService = quickBooksService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QueryQuickBooks(string queryType)
        {
            string qbXmlRequest = GetRequestXml(queryType);
            string response = _quickBooksService.QueryQuickBooks(qbXmlRequest);
            return Content(response, "text/xml");
        }
        public IActionResult GetBills()
        {
            string response = _quickBooksService.GetBills();
            return Content(response, "text/xml");
        }

        public IActionResult GetChecks()
        {
            string response = _quickBooksService.GetChecks();
            return Content(response, "text/xml");
        }


        private string GetRequestXml(string queryType)
        {
            // Load XML from files
            string xmlFilePath = queryType switch
            {
                "Bill" => "XmlRequests/BillQueryRq.xml",
                "Check" => "XmlRequests/CheckQueryRq.xml",
                "Company" => "XmlRequests/CompanyQueryRq.xml",
                "Invoice" => "XmlRequests/InvoiceQueryRq.xml",
                "ItemSalesTax" => "XmlRequests/ItemSalesTaxQueryRq.xml",
                _ => throw new ArgumentException("Invalid query type")
            };
            return System.IO.File.ReadAllText(xmlFilePath);
        }
    }
}
