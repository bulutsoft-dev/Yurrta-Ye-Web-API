// src/YurttaYe.Infrastructure/Services/FileProcessingService.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Domain.Entities;
using YurttaYe.Domain.ValueObjects;

namespace YurttaYe.Infrastructure.Services
{
    public class FileProcessingService : IFileProcessingService
    {
        public FileProcessingService()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // EPPlus lisansı
        }

        public List<Menu> ProcessFile(Stream fileStream, string fileExtension)
        {
            return fileExtension.ToLower() switch
            {
                ".pdf" => ProcessPdf(fileStream),
                ".xlsx" => ProcessExcel(fileStream),
                _ => throw new NotSupportedException("Unsupported file format")
            };
        }

        private List<Menu> ProcessPdf(Stream fileStream)
        {
            var menus = new List<Menu>();
            using (var pdf = PdfReader.Open(fileStream, PdfDocumentOpenMode.ReadOnly))
            {
                foreach (var page in pdf.Pages)
                {
                    var text = ExtractTextFromPdfPage(page);
                    var menu = ParseMenuText(text);
                    if (menu != null)
                        menus.Add(menu);
                }
            }
            return menus;
        }

        private List<Menu> ProcessExcel(Stream fileStream)
        {
            var menus = new List<Menu>();
            using (var package = new ExcelPackage(fileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int row = 2; // Başlık satırını atla
                while (!string.IsNullOrEmpty(worksheet.Cells[row, 1].Text))
                {
                    var dateStr = worksheet.Cells[1, 2].Text; // Örneğin, 5/5/2025
                    var dayOfWeek = worksheet.Cells[row, 1].Text.Contains("PAZARTESİ") ? "Pazartesi" : "Salı";
                    var date = DateTime.Parse(dateStr);
                    var totalCalorieStr = worksheet.Cells[row, 9].Text; // Örneğin, "850-1135 kkal"
                    var calorieParts = totalCalorieStr.Replace(" kkal", "").Split('-').Select(x => decimal.Parse(x.Trim())).ToArray();
                    var totalCalorie = new CalorieRange(new Calorie(calorieParts[0]), new Calorie(calorieParts[1]));

                    var menu = new Menu(date, dayOfWeek, totalCalorie);

                    // Yemek çeşitlerini oku (örnek: Sebze Çorbası, Tavuk Çökertme)
                    for (int col = 1; col <= 7; col += 2)
                    {
                        var name = worksheet.Cells[row, col].Text;
                        var gramajStr = worksheet.Cells[row, col + 1].Text; // Örneğin, "250 g"
                        if (!string.IsNullOrEmpty(name))
                        {
                            var gramajParts = gramajStr.Split(' ');
                            var gramajValue = decimal.Parse(gramajParts[0]);
                            var gramajUnit = gramajParts[1] == "g" ? "g" : "ml";
                            var category = col switch
                            {
                                1 => "Çorba",
                                3 => "Ana Yemek",
                                5 => "Yan Yemek",
                                7 => "Salata/Tatlı",
                                _ => "Ek Ürün"
                            };

                            menu.AddItem(new MenuItem(
                                name: name,
                                category: category,
                                gramaj: new Gramaj(gramajValue, gramajUnit)
                            ));
                        }
                    }

                    // Ek ürünler (Su, Ekmek)
                    menu.AddItem(new MenuItem("Su", "Ek Ürün", new Gramaj(500, "ml")));
                    menu.AddItem(new MenuItem("Çeyrek Ekmek", "Ek Ürün", new Gramaj(50, "g")));

                    menus.Add(menu);
                    row++;
                }
            }
            return menus;
        }

        private string ExtractTextFromPdfPage(PdfPage page)
        {
            // PdfSharp ile basit metin çıkarma (gerçek uygulamada iText veya Tesseract önerilir)
            return "Sample extracted text"; // Örnek için, gerçek implementasyonda PDF metni çıkarılmalı
        }

        private Menu ParseMenuText(string text)
        {
            // Örnek: Satır bazlı ayrıştırma
            var lines = text.Split('\n');
            var date = DateTime.Now; // PDF’den tarih çıkarılmalı
            var dayOfWeek = "Pazartesi"; // PDF’den çıkarılmalı
            var totalCalorie = new CalorieRange(new Calorie(850), new Calorie(1135)); // PDF’den çıkarılmalı
            var menu = new Menu(date, dayOfWeek, totalCalorie);

            foreach (var line in lines)
            {
                var parts = line.Split('-').Select(p => p.Trim()).ToArray();
                if (parts.Length >= 3)
                {
                    var name = parts[0];
                    var category = parts[1];
                    var gramajStr = parts[2].Split(' ')[0];
                    var gramajUnit = parts[2].Contains("ml") ? "ml" : "g";
                    var gramajValue = decimal.Parse(gramajStr);

                    menu.AddItem(new MenuItem(
                        name: name,
                        category: category,
                        gramaj: new Gramaj(gramajValue, gramajUnit)
                    ));
                }
            }

            return menu;
        }
    }
}