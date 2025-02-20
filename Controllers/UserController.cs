using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ValidationExample.Models;

namespace ValidationExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IValidator<UserDto> _validator;

        public UserController(IValidator<UserDto> validator)
        {
            _validator = validator;
        }

        [HttpPost("validate")]
        public IActionResult ValidateUser([FromBody] UserDto user)
        {
            var result = _validator.Validate(user);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));
            }

            return Ok("Дані успішно пройшли валідацію");
        }
    }
}
