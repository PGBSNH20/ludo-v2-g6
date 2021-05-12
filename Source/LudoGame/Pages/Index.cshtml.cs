using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RestApi.Models;

namespace LudoGame.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public int AmountOfPlayers { get; set; }

        public void OnGet()
        {

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
