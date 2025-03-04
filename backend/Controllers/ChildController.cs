using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NutriApp.DTOs;
using NutriApp.Services;
using NutriApp.DTOs.Children;

namespace NutriApp.Controllers
{
    [Route("api/children")]
    [ApiController]
    public class ChildController : ControllerBase
    {
        private readonly IChildService _childService;

        public ChildController(IChildService childService)
        {
            _childService = childService;
        }

        // Pobierz wszystkie dzieci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChildDTO>>> GetAllChildren()
        {
            var children = await _childService.GetAllChildrenAsync();
            return Ok(children);
        }

        // Pobierz dziecko po ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ChildDTO>> GetChildById(Guid id)
        {
            var child = await _childService.GetChildByIdAsync(id);
            if (child == null) return NotFound();
            return Ok(child);
        }

        // Pobierz dzieci użytkownika
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<ChildDTO>>> GetChildrenByUserId(Guid userId)
        {
            var children = await _childService.GetChildrenByUserIdAsync(userId);
            return Ok(children);
        }

        // Utwórz nowe dziecko
        [HttpPost]
        public async Task<ActionResult<ChildDTO>> CreateChild([FromBody] ChildDTO childDto)
        {
            var createdChild = await _childService.CreateChildAsync(childDto);
            return CreatedAtAction(nameof(GetChildById), new { id = createdChild.Id }, createdChild);
        }

        // Aktualizuj dziecko
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChild(Guid id, [FromBody] ChildDTO childDto)
        {
            if (id != childDto.Id) return BadRequest("ID w URL nie zgadza się z ID w ciele żądania.");

            await _childService.UpdateChildAsync(childDto);
            return NoContent();
        }

        // Usuń dziecko
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChild(Guid id)
        {
            await _childService.DeleteChildAsync(id);
            return NoContent();
        }
    }
}
