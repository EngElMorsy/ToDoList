using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ToDo.BL.Helper;
using ToDo.BL.Interface.Users;
using ToDo.DAL.Database;
using ToDo.DAL.Extend;

namespace ToDo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUser iuser;

        public UsersController(IUser iuser)
        {
            this.iuser = iuser;
        }
        [HttpGet]
        [HttpGet("~/api/v1/todos/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var data = await iuser.GetAllUserAsync();

                return Ok(new ApiResponse<IEnumerable<ApplicationUser>>()
                {

                    Code = 200,
                    Status = "Success",
                    Message = "Data Found",
                    Data = data

                });
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = 404,
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Data = ex.Message

                });
            }
        }

        [HttpPut]
        [HttpPut("~/api/v1/todos/PutUser")]
        public async Task<IActionResult> UpdateUser(ApplicationUser model)
        {
            try
            {
                var result = await userManager.UpdateAsync(model);

                if (result.Succeeded)
                {
                    return Ok(new ApiResponse<string>() {

                        Code = 200,
                        Status = "Success",
                        Message = "Data Updated",
                        
                    });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }


                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(new ApiResponse<string>()
                {

                    Code = 404,
                    Status = "Not Found",
                    Message = "Data Not Found",
                    Data = ex.Message

                });
            }
        }

        [HttpPost]
        [HttpPut("~/api/v1/todos/DeleteUser")]
        public async Task<IActionResult> Delete(ApplicationUser model)
        {

            var data = await userManager.FindByIdAsync(model.Id);

            if (data != null)
            {
                var result = await userManager.DeleteAsync(data);


                if (result.Succeeded)
                {
                    return Ok(new ApiResponse<string>()
                    {

                        Code = 200,
                        Status = "Success",
                        Message = "Data Updated",

                    });
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }

            return Ok();
        }

    }
}
