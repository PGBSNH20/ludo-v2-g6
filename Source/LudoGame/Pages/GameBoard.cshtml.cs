using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestApi.Models;

namespace LudoGame.Pages
{
    public class GameBoardModel : PageModel
    {
        public GameBoard gameBoard;
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(ModelState.IsValid== false)
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}