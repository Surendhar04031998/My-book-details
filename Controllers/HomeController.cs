using Microsoft.AspNetCore.Mvc;
using MyBookDetails.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;

namespace MyBookDetails.Controllers
{
    public class Book 
    {
        public string title { get; set; }
        public string author { get; set; }
    }

    public class HomeController : Controller
    {
       

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://mocki.io/v1/3732017d-2814-44c5-a125-2f8645d4309c");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                Book[] books = JsonSerializer.Deserialize<Book[]>(jsonString);

                return View(books);
            }
            else { 
                return View(Error); 
            }   
           
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