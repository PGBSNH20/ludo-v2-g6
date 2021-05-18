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
        private string responseContent;

        [BindProperty]
        public int AmountOfPlayers { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var baseURL = new Uri("https://localhost:5001/api/Gameboard/");
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync(baseURL.ToString());

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
            }

            return Page();

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("/Forms/Player");
        }
    }
}
