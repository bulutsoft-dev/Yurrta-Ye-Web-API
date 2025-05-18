// src/YurttaYe.WebApi/Pages/Admin/Menu/Upload.cshtml.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using YurttaYe.Application.Features.Commands;
using MediatR;

namespace YurttaYe.WebApi.Pages.Admin.Menu
{
    [Authorize(Roles = "Admin")]
    public class UploadModel : PageModel
    {
        private readonly IMediator _mediator;

        public UploadModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string Message { get; set; }
        public bool Success { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                Message = "No file uploaded";
                Success = false;
                return Page();
            }

            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension != ".pdf" && extension != ".xlsx")
            {
                Message = "Unsupported file format. Only PDF and Excel files are allowed.";
                Success = false;
                return Page();
            }

            using var stream = file.OpenReadStream();
            var command = new ProcessMenuFileCommand
            {
                FileStream = stream,
                FileExtension = extension
            };

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                Message = result.ErrorMessage;
                Success = false;
                return Page();
            }

            Message = "File processed successfully";
            Success = true;
            return Page();
        }
    }
}