using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using ValidationExample.Models;

namespace ValidationExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValidator<UserDto> _validator;

        public HomeController(IValidator<UserDto> validator)
        {
            _validator = validator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
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

