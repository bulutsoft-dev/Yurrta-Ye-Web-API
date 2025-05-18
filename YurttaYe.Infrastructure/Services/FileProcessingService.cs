// src/YurttaYe.Infrastructure/Services/FileProcessingService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using OfficeOpenXml;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Domain.Entities;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Infrastructure.Services
{
    public class FileProcessingService : IFileProcessingService
    {
        public async Task<List<Menu>> ProcessFileAsync(Stream fileStream, string fileExtension)
        {
            var menus = new List<Menu>();

            if (fileExtension == ".xlsx")
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using var package = new ExcelPackage(fileStream);
                var worksheet = package.Workbook.Worksheets[0];

                var dateStr = worksheet.Cells[1, 1].Text.Replace("Tarih:", "").Trim();
                var day = worksheet.Cells[2, 1].Text.Replace("Gün:", "").Trim();
                var calorieStr = worksheet.Cells[worksheet.Dimension.Rows, 1].Text.Replace("Toplam Kalori:", "").Trim();
                var calorieRange = ParseCalorieRange(calorieStr);

                var menu = new Menu(DateTime.Parse(dateStr), day, calorieRange);

                for (int row = 4; row <= worksheet.Dimension.Rows - 1; row++)
                {
                    var name = worksheet.Cells[row, 1].Text;
                    var gramajStr = worksheet.Cells[row, 2].Text;
                    var category = worksheet.Cells[row, 3].Text;

                    if (string.IsNullOrWhiteSpace(name))
                        continue;

                    var gramaj = ParseGramaj(gramajStr);
                    var menuItem = new MenuItem(name, category, gramaj, null, null, DateTime.Parse(dateStr));
                    menu.AddItem(menuItem);
                }

                menus.Add(menu);
            }
            else
            {
                throw new NotSupportedException("Only Excel (.xlsx) files are supported for now");
            }

            return await Task.FromResult(menus);
        }

        private Gramaj ParseGramaj(string gramajStr)
        {
            var parts = gramajStr.Split(' ');
            if (parts.Length != 2 || !decimal.TryParse(parts[0], out var value))
                throw new ArgumentException("Invalid gramaj format");
            return new Gramaj(value, parts[1]);
        }

        private CalorieRange ParseCalorieRange(string calorieStr)
        {
            var parts = calorieStr.Replace(" kkal", "").Split('-');
            if (parts.Length != 2 || !decimal.TryParse(parts[0], out var min) || !decimal.TryParse(parts[1], out var max))
                throw new ArgumentException("Invalid calorie range format");
            return new CalorieRange(new Calorie(min), new Calorie(max));
        }
    }
}