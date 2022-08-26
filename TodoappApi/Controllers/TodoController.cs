using Application.DTO;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TodoappApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    { 
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public ActionResult<List<TodoDto>> GetAllItem()
        {
            var result = _todoService.GetAll();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteTask(int id)
        {
            var result = _todoService.DeleteTask(id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<bool> AddTask(TodoDto todoDto)
        {
            var result = _todoService.AddTask(todoDto);
            return Ok(result);
        }

    }
}
