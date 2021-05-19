using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // ska finnas en get som tar ID som returnerar hela spelat
            string responseContent;
            var baseURL = new Uri("https://localhost:5002/api/Gameboard/newgame");
            var client = new HttpClient();
            List<GamePlayer> gamePlayers = new();

            if (!(RedPlayer.Name is null))
                gamePlayers.Add(RedPlayer); 
            if (!(YellowPlayer.Name is null))
                gamePlayers.Add(YellowPlayer);
            if (!(GreenPlayer.Name is null))
                gamePlayers.Add(GreenPlayer);
            if (!(BluePlayer.Name is null))
                gamePlayers.Add(BluePlayer);


            // TODO Kolla vilka som är null och skicka resten

            HttpResponseMessage response = await client.PostAsJsonAsync(baseURL.ToString(), gamePlayers);

            //HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();

                var gameBoard = JsonConvert.DeserializeObject<GameBoard>(responseContent);
                
                return RedirectToPage("/Forms/Player", new { id = gameBoard.Id.ToString() });

            }
            return Page();
        }
    }
}
