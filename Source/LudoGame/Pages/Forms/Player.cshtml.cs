using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestApi.Models;

namespace LudoGame.Pages.Forms
{
    public class PlayerModel : PageModel
    {
        [BindProperty]
        public GameBoard GameBoard { get; set; }

        public async Task<IActionResult> OnGetAsync(GameBoard gameBoard)
        {
            GameBoard = gameBoard;

            await Task.Delay(1);


            //string responseContent;
            //var baseURL = new Uri($"https://localhost:5002/api/Gameboard/game/");
            //var client = new HttpClient();
            
            //HttpResponseMessage response = await client.GetAsync(baseURL + id);

            //if (response.IsSuccessStatusCode)
            //{
            //    responseContent = await response.Content.ReadAsStringAsync();
            //    return RedirectToPage("/Forms/Player", responseContent);
            //}

            return Page();
        }
    }
}
