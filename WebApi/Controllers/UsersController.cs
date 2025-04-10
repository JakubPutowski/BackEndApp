using Infrasctructure.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.Login);
            if (user is null)
            {
                return BadRequest(new {error = "Invalid user or password!"});
            }

            var result = await signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (result.Succeeded)
            {
                //TODO zwrot tokena
                return Ok(new {message = "Login succed!"});
            }
            else
            {
                return BadRequest(new {error = "Invalid user or password!"});
            }
        }
    }
}
