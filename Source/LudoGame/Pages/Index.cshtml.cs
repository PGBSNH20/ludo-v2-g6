using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestApi.Models;

namespace LudoGame.Pages
{
    public class IndexModel : PageModel
    {


        [BindProperty, FromBody]
        public List<GamePlayer> GamePlayer { get; set; }

        [BindProperty]
        public string PlayerUrl { get; set; }


        public IActionResult OnGet()
        {

            return Page();
        }

        public async Task<IActionResult> OnPost(List<GamePlayer> gp)
        {
            // ska finnas en get som tar ID som returnerar hela spelat
            string responseContent = "[]";
            var baseURL = new Uri("https://localhost/api/Gameboard/new%20game");
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                return RedirectToPage("/Forms/Player");
            }

            return Page();
        }
    }
}
