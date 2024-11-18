using Microsoft.AspNetCore.Mvc;
using QuickBooksIntegrationAPI.Services;

namespace QuickBooksIntegrationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuickBooksApiController : ControllerBase
    {
        private readonly IQuickBooksService _quickBooksService;

        public QuickBooksApiController(IQuickBooksService quickBooksService)
        {
            _quickBooksService = quickBooksService;
        }

        [HttpGet("bills")]
        public IActionResult GetBills()
        {
            string response = _quickBooksService.GetBills();
            return Content(response, "text/xml");
        }

        [HttpGet("checks")]
        public IActionResult GetChecks()
        {
            string response = _quickBooksService.GetChecks();
            return Content(response, "text/xml");
        }

        [HttpGet("invoices")]
        public IActionResult GetInvoices()
        {
            string response = _quickBooksService.QueryQuickBooks(System.IO.File.ReadAllText("XmlRequests/InvoiceQueryRq.xml"));
            return Content(response, "text/xml");
        }
        [HttpPost("update-task")]
        public IActionResult UpdateTask([FromBody] string qbXmlRequest)
        {
            string response = _quickBooksService.UpdateTask(qbXmlRequest);
            return Content(response, "text/xml");
        }
    }
}
