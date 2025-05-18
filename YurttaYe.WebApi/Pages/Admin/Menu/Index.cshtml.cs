// src/YurttaYe.WebApi/Pages/Admin/Menu/Index.cshtml.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.DTOs;

namespace YurttaYe.WebApi.Pages.Admin.Menu
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IMenuItemService _menuItemService;

        public IndexModel(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        public IEnumerable<MenuItemDto> MenuItems { get; set; }

        public async Task OnGetAsync()
        {
            MenuItems = await _menuItemService.GetAllAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            await _menuItemService.DeleteAsync(id);
            return RedirectToPage();
        }
    }
}