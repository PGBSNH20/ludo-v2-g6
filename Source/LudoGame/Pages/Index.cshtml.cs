using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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

        [BindProperty]
        public GamePlayer RedPlayer { get; set; }

        [BindProperty]
        public GamePlayer YellowPlayer { get; set; }

        [BindProperty]
        public GamePlayer GreenPlayer { get; set; }

        [BindProperty]
        public GamePlayer BluePlayer { get; set; }

        //[BindProperty, FromBody]
        //public List<GamePlayer> GamePlayer { get; set; }

        [BindProperty]
        public string PlayerUrl { get; set; }


        public IActionResult OnGet()
        {

            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(List<GamePlayer> gp)
        public async Task<IActionResult> OnPostAsync()
        {
            // ska finnas en get som tar ID som returnerar hela spelat
            string responseContent = "[]";
            var baseURL = new Uri("https://localhost:5002/api/Gameboard/new%20game");
            var client = new HttpClient();

            // TODO Kolla vilka som är null och skicka resten

            HttpResponseMessage response = await client.PostAsJsonAsync(baseURL.ToString(), new List<GamePlayer> {RedPlayer, BluePlayer});

            //HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                return RedirectToPage("/Forms/Player");
            }

            return Page();
        }
    }
}
