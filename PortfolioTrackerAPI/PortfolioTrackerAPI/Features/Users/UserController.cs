using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioTrackerAPI.Features.Users.DTOs;
using PortfolioTrackerAPI.Features.Users.Service;
using PortfolioTrackerAPI.Shared;

namespace PortfolioTrackerAPI.Features.Users
{
    [Authorize]
    public class UserController(IUserService _userService) : ApiController
    {
        [HttpPut]
        public async Task<IActionResult> CreateOrUpdateUser([FromBody] UserInfo userInfo, CancellationToken cancellationToken)
        {
            await _userService.CreateOrUpdateUserAsync(User, userInfo, cancellationToken);

            return Ok();
        }

        [HttpGet("{authId}")]
        public async Task<IActionResult> GetUserById(string authId, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserByAuthIdAsync(authId, cancellationToken);
            
            return user is null ? NotFound() : Ok(user);
        }
    }
}
