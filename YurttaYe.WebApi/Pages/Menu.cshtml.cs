// src/YurttaYe.WebApi/Pages/Menu.cshtml.cs

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Repositories;
using YurttaYe.Domain.Entities;
using YurttaYe.Domain.ValueObjects;
using System;

namespace YurttaYe.WebApi.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Menu> Menus { get; set; }

        public async Task OnGetAsync()
        {
            var items = await _unitOfWork.MenuItems.GetAllAsync();

            var menu = new Menu(
                new DateTime(2025, 5, 5),
                "Pazartesi",
                new CalorieRange(
                    new Calorie(850),
                    new Calorie(1135))
            );

            foreach (var item in items)
            {
                menu.AddItem(item);
            }

            Menus = new List<Menu> { menu };
        }
    }
}