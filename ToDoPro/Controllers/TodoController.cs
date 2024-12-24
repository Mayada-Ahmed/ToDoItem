using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        readonly ITodoItem _todoItem;
        public TodoController(ITodoItem todoItem)
        {
            _todoItem = todoItem;
        }


        [HttpPost]
        public ActionResult Create(TodoItem newItem)
        {
             _todoItem.Create(newItem);
            return Ok(newItem);
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> GetAll()
        {
            return Ok(_todoItem.GetAll());
        }

        [HttpGet("pending")]
        public ActionResult<List<TodoItem>> GetPendingItem()
        {
            return Ok(_todoItem.GetPending());
        }

        [HttpPut("{id}/Complete")]
        public ActionResult todoComplete(int id)
        {
                _todoItem.Update(id);
                return Ok();
        }

    }
}
