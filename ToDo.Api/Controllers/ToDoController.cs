using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.BL.Filter;
using ToDo.BL.Helper;
using ToDo.BL.Interface;
using ToDo.BL.Model;
using ToDo.BL.Wrappers;
using ToDo.DAL.Database;
using ToDo.DAL.Entity;

namespace ToDo.Api.Controllers
{
    
    //[Route("api/v1/todos/")]
    [ApiController]
    public class ToDoController  : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IToDoRep unit;
        private readonly ApplicationContext db;
        // private readonly IUnitOfWork unit;
        public ToDoController(IMapper mapper, IToDoRep unit,ApplicationContext db)
        {
            this.mapper = mapper;
            this.unit = unit;
            this.db = db;
        }
        
        [HttpGet]
        //[MapToApiVersion("1.0")]
        [Route("~/api/v1/todos/GetAllItem")]
        public async Task<IActionResult>GetAllItem([FromQuery] PaginationFilter filter)
        {  
            try
            {
                //var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
                //var data  = unit.GetAsync(x => x.Titile == "fdfdfdf1", x => x.Id);
                //var res = mapper.Map<IEnumerable<TDVM>>(data);
                //var pagedData =data.Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                //.Take(validFilter.PageSize).ToList();
                //  var totalRecords =  data.Count();
                //  return Ok(new PagedResponse<List<TD>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
                var data = await unit.GetAsync(x => x.Titile == "fdfdfdf1", x => x.Id);
                var res = mapper.Map<IEnumerable<TDVM>>(data);
                return Ok(res);


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
        
        [HttpGet]
        //[MapToApiVersion("1.0")]
        [Route("~/api/v1/todos/GetItemById/{id}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            try
            {
                var data = await unit.GetByIdAsync(x => x.Id == id);
                var result = mapper.Map<TDVM>(data);
                return Ok(new ApiResponse<TDVM>()
                {

                    Code = 200,
                    Status = "Ok",
                    Message = "Data Found",
                    Data = result

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

        [HttpPost]
        //[MapToApiVersion("1.0")]
        [Route("~/api/v1/todos/PostItem")]
        public async Task<IActionResult> PostItem(TDVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var data = mapper.Map<TD>(model);
                    await unit.CreateAsync(data);
                    
                    return Ok(new ApiResponse<string>()
                    {

                        Code = 200,
                        Status = "Created",
                        Message = "Data Created",
                        Data = "No result to return"
                    });
                }

                return BadRequest(new ApiResponse<string>()
                {

                    Code = 400,
                    Status = "Bad Request",
                    Message = "Data invalid",
                    

                });

            }

            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {

                    Code = 400,
                    Status = "Bad Request",
                    Message = "Data Not Saved",
                    Data = ex.Message

                });
            }
        }


        [HttpPut]
        [Route("~/api/v1/todos/PutItem")]
         public async Task<IActionResult> PutEmployee(TDVM model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var data = mapper.Map<TD>(model);
                    await unit.UpdateAsync(data);
                     return Ok(new ApiResponse<string>()
                    {

                        Code = 201,
                        Status = "Updated",
                        Message = "Data Updated",
                        Data = "No result to return"
                    });
                }


                return BadRequest(new ApiResponse<string>()
                {
                    Code = 400,
                    Status = "Bad Request",
                    Message = "Validation Error"
                });



            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {

                    Code = 400,
                    Status = "Bad Request",
                    Message = "Data Not Updated",
                    Data = ex.Message

                });
            }
        }

        [HttpDelete]
        [Route("~/api/v1/todos/Deleteitem")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {

                 await unit.DeleteAsync(id);
                 return Ok(new ApiResponse<string>()
                {
                    Code = 201,
                    Status = "Deleted",
                    Message = "Data Deleted",
                    Data = "No result to return"
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse<string>()
                {

                    Code = 400,
                    Status = "Bad Request",
                    Message = "Data Not Updated",
                    Data = ex.Message

                });
            }
        }

    }
}
