using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ToDo.BL.Helper;
using ToDo.BL.Model.AuthSeervices;
using ToDo.BL.Services;
using ToDo.DAL.Extend;

namespace ToDo.Api.Controllers
{
    //[Route("~/api/v1/[controller]")]
    [ApiController]
    public class AuthUserController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthUserController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("~/api/v1/todos/register")]
        public async Task<IActionResult> RegisterAsync(RegisterVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.RegisterAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);
               return Ok(result);
        }

        [HttpPost("~/api/v1/todos/Login")]
        public async Task<IActionResult> LoginAsync(LoginVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }


       
        //[Authorize]
        [HttpPost("~/api/v1/todos/AddUserInRole")]
        public async Task<IActionResult> AddRoleAsync(UserInRoleVM model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await authService.AddRoleAsync(model);

            if (!string.IsNullOrEmpty(result))
                return BadRequest(result);

            return Ok(model);
        }

        ////Save Refersh Token In Cookies
        //private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        //{
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = expires.ToLocalTime()
        //    };

        //    Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        //}

        ////[Authorize]
        //[HttpGet("~/api/v1/todos/refreshToken")]
        //public async Task<IActionResult> RefreshToken()
        //{
        //    var refreshToken = Request.Cookies["refreshToken"];

        //    var result = await authService.RefreshTokenAsync(refreshToken);

        //    if (!result.IsAuthenticated)
        //        return BadRequest(result);

        //    SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

        //    return Ok(result);
        //}


        ////[Authorize]
        //[HttpPost("~/api/v1/todos/logout")]
        //public async Task<IActionResult> RevokeToken(RevokeTokenVM model)
        //{
        //    var token = model.Token ?? Request.Cookies["refreshToken"];

        //    if (string.IsNullOrEmpty(token))
        //        return BadRequest("Token is required!");

        //    var result = await authService.RevokeTokenAsync(token);

        //    if (!result)
        //        return BadRequest("Token is invalid!");

        //    return Ok();
        //}

    }

}
