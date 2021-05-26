using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestApi.Models;

namespace LudoGame.Pages
{
    public class HistoryModel : PageModel
    {
        public List<GameBoard> gameBoard;
        public async Task<IActionResult> OnGet()
        {
            string responseContent = "[]";
            var baseURL = new Uri("https://localhost:44369/api/Gameboard/History");
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }
                return RedirectToPage("/Forms/LudoHistory", responseContent );
            
        }

    }
}
