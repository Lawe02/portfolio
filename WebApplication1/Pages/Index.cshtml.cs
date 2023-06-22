using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SuperLibrary.Models;
using SuperLibrary.Services;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly WeatherForecastService _weatherForecastService;
        private readonly ItemService _itemService;
        public IndexModel(ILogger<IndexModel> logger, WeatherForecastService service, ItemService iservice)
        {
            _logger = logger;
            _weatherForecastService = service;
            _itemService = iservice;
        }

        public float Temprature { get; set; }
        public List<PortfolioItem> PortfolioItems { get; set; }
        public async Task OnGet()
        {
            Temprature = await _weatherForecastService.GetWeatherAsync(); 
            PortfolioItems = await _itemService.GetPortfolioItems();
        }

    }
}