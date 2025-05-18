// src/YurttaYe.WebApi/Pages/Admin/Menu/Edit.cshtml.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.DTOs;

namespace YurttaYe.WebApi.Pages.Admin.Menu
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IMenuItemService _menuItemService;

        public EditModel(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [BindProperty]
        public MenuItemCreateDto MenuItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var item = await _menuItemService.GetByIdAsync(id);
            if (item == null)
                return NotFound();

            MenuItem = new MenuItemCreateDto
            {
                Name = item.Name,
                Category = item.Category,
                GramajValue = item.Gramaj.Value,
                GramajUnit = item.Gramaj.Unit,
                PriceValue = item.Price?.Value,
                PriceCurrency = item.Price?.Currency ?? "TRY",
                CalorieValue = item.Calorie?.Value
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
                return Page();

            await _menuItemService.UpdateAsync(id, MenuItem);
            return RedirectToPage("Index");
        }
    }
}