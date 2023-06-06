﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SuperLibrary.Services
{
    public class WeatherForecastService
    {
        public async Task<float> GetWeatherAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherapi-com.p.rapidapi.com/current.json?q=59.334591%2C18.063240"),
                Headers =
                {
                    { "X-RapidAPI-Key", "c8abfd10d9msh99d66d7d8e8d14bp164a1ajsn33df2cee019c" },
                    { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<WeatherResponse>(body);
                return responseObject.Current.TemperatureInCelsius;
            }
        }
    }
    public class WeatherResponse
    {
        [JsonProperty("current")]
        public CurrentWeather Current { get; set; }
    }

    public class CurrentWeather
    {
        [JsonProperty("temp_c")]
        public float TemperatureInCelsius { get; set; }
    }
}


