using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Users.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Users
{
    [Authorize]
    public class UserController(IUserService _userService) : ApiController
    {
        [HttpGet("me")]
        public async Task<IActionResult> GetOrCreateUser(CancellationToken cancellationToken)
        {
            var user = await _userService.GetOrCreateUserAsync(User, cancellationToken);

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByIdAsync(id, cancellationToken);
            
            return user is null ? NotFound() : Ok(user);
        }
    }
}
