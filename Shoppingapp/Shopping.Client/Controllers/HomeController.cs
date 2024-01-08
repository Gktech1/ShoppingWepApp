using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shopping.Client.Data;
using Shopping.Client.Dtos;
using Shopping.Client.Models;
using Shopping.Client.Shared;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientService _httpClientService;
        private IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IHttpClientService httpClientService, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientService = httpClientService;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {

           // Url = _config.GetSection("ExternalApis")["IMAL"] + "/GetAccountTypes",
            var request = new GetRequest
            {
                Url = _configuration.GetSection("ExternalApis")["BaseUrl"] + "/Product/getproducts",

            };
            var response = await _httpClientService.SendGetRequest<IEnumerable<Product>>(request);

            return View(response);
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