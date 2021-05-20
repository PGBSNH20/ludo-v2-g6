using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestApi.Models;

namespace LudoGame.Pages.Forms
{
    public class PlayerModel : PageModel
    {

        public GameBoard GameBoard { get; set; }
        public List<GamePlayer> GamePlayer { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
           
            string responseContent;
            var baseURL = new Uri($"https://localhost:5002/api/Gameboard/game?id=");
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseURL + id);

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<GameBoard>(responseContent);
                GameBoard = result;

                await Task.Delay(1);

                GamePlayer = result.GamePlayer.ToList();
            }

            return Page();

        }
    }
}
