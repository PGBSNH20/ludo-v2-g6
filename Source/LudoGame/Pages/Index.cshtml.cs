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
        public List<GamePlayer> Players { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // ska finnas en get som tar ID som returnerar hela spelat
            string responseContent;
            var baseURL = new Uri("https://localhost:44369/api/Gameboard/newgame");
            var client = new HttpClient();

            List<GamePlayer> gamePlayers = new();
            gamePlayers.AddRange(Players.Where(person => person.Name != null));
            AssignColors(gamePlayers);

            HttpResponseMessage response = await client.PostAsJsonAsync(baseURL.ToString(), gamePlayers);

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                var gameBoard = JsonConvert.DeserializeObject<GameBoard>(responseContent);
                return RedirectToPage("/Forms/Player", new { id = gameBoard.Id.ToString() });

            }
            return Page();
        }

        private static void AssignColors(List<GamePlayer> gamePlayers)
        {
            for (int i = 0; i < gamePlayers.Count; i++)
            {
                if (gamePlayers.Count < 3)
                {
                    if (i == 0)
                    {
                        gamePlayers[i].Color = Color.Red;
                        gamePlayers[i].OrderInGame = i;
                    }
                    if (i == 1)
                    {
                        gamePlayers[i].Color = Color.Yellow;
                        gamePlayers[i].OrderInGame = i;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        gamePlayers[i].Color = Color.Red;
                        gamePlayers[i].OrderInGame = i;
                    }
                    if (i == 1)
                    {
                        gamePlayers[i].Color = Color.Green;
                        gamePlayers[i].OrderInGame = i;
                    }
                    if (i == 2)
                    {
                        gamePlayers[i].Color = Color.Yellow;
                        gamePlayers[i].OrderInGame = i;
                    }
                    if (i == 3)
                    {
                        gamePlayers[i].Color = Color.Blue;
                        gamePlayers[i].OrderInGame = i;
                    }
                }
            }
        }
    }
}
