using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Store.Models;


namespace Store
{
    public class Program
    {
        public static Сurrency[] _сurrencies;
        public static void Main(string[] args)
        {
            string pathJson = Directory.GetCurrentDirectory();
            pathJson = pathJson + "/wwwroot/json/currency.json";
            string json = File.ReadAllText(pathJson);
            _сurrencies = JsonSerializer.Deserialize<Сurrency[]>(json);
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}