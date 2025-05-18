// src/YurttaYe.WebApi/Controllers/MenuController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YurttaYe.Application.Abstractions.Services;
using YurttaYe.Application.DTOs;
using YurttaYe.Application.Features.Commands;
using YurttaYe.Application.Features.Queries;
using MediatR;

namespace YurttaYe.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly IMediator _mediator;

        public MenuController(IMenuItemService menuItemService, IMediator mediator)
        {
            _menuItemService = menuItemService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _menuItemService.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _menuItemService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] MenuItemCreateDto dto)
        {
            await _mediator.Send(new CreateMenuItemCommand { MenuItem = dto });
            return CreatedAtAction(nameof(GetById), new { id = 0 }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] MenuItemCreateDto dto)
        {
            await _mediator.Send(new UpdateMenuItemCommand { Id = id, MenuItem = dto });
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _menuItemService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("upload")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension != ".pdf" && extension != ".xlsx")
                return BadRequest("Unsupported file format");

            using var stream = file.OpenReadStream();
            var command = new ProcessMenuFileCommand
            {
                FileStream = stream,
                FileExtension = extension
            };

            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok("File processed successfully");
        }
    }
}