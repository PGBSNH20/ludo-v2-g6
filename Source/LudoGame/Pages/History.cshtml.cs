using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestApi.Models;

namespace LudoGame.Pages
{
    public class HistoryModel : PageModel
    {
        public List<GameBoardDto> GameBoardHistory;
        public async Task<IActionResult> OnGet()
        {

            var baseURL = new Uri("https://localhost:44369/api/Gameboard/History");
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<GameBoardDto>>(responseContent);

                GameBoardHistory = result;
            }
            return Page();
        }
    }
}
