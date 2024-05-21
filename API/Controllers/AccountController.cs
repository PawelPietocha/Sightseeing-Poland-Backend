using System.Security.Claims;
using API.Dtos;
using API.Errors;
using Core.Entities.Identity;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentuser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto 
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName,
            };
        }

        [HttpGet("getCurrentUser/{email}")]
        public async Task<ActionResult<UserDto>> GetLoggedUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                VoivodeshipId = user.VoivodeshipId,
                Id = user.Id
            };
        }

        [HttpGet("emailsexists")]
        public async Task<ActionResult<bool>> CheckEmailExistsAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null) return Unauthorized(new APIResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized(new APIResponse(401));

            return new UserDto 
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                DisplayName = user.DisplayName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                VoivodeshipId = user.VoivodeshipId,
                Id = user.Id
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto) 
        {
            var user = new AppUser {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                VoivodeshipId = registerDto.VoivodeshipId
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if(!result.Succeeded) return BadRequest(new APIResponse(400));

            return new UserDto {
                DisplayName = user.DisplayName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email,
                DateOfBirth = registerDto.DateOfBirth,
                Gender = registerDto.Gender,
                VoivodeshipId = registerDto.VoivodeshipId,
                Id = user.Id
            };
        }
        [HttpPost("updateUserDetails")]
        public async Task<ActionResult<UserDto>> UpdateUserDetails(UserDto userDto) {

            var user = await _userManager.FindByIdAsync(userDto.Id);

            user.DateOfBirth = userDto.DateOfBirth;
            user.DisplayName = userDto.DisplayName;
            user.Gender = userDto.Gender;
            user.VoivodeshipId = userDto.VoivodeshipId;

            var result = await _userManager.UpdateAsync(user);

            return userDto;

        }

        [HttpPost("updateUserLoginDetails")]
        public async Task<ActionResult<bool>> UpdateUserLoginDetails(UpdateLoginDetailsDto updateLoginDetailsDto) {
            
            var user = await _userManager.FindByIdAsync(updateLoginDetailsDto.Id);

            await _userManager.RemovePasswordAsync(user);
            await _userManager.AddPasswordAsync(user, updateLoginDetailsDto.Password);
            return true;
        }
    }
}