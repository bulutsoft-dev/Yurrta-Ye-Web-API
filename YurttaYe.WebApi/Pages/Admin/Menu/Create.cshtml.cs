// src/YurttaYe.WebApi/Pages/Admin/Menu/Create.cshtml.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.DTOs;

namespace YurttaYe.WebApi.Pages.Admin.Menu
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IMenuItemService _menuItemService;

        public CreateModel(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [BindProperty]
        public MenuItemCreateDto MenuItem { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _menuItemService.AddAsync(MenuItem);
            return RedirectToPage("Index");
        }
    }
}