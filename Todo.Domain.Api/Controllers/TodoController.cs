using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        public TodoController() { }

        [HttpPost("")]
        public GenericCommandResult Create([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("")]
        public GenericCommandResult Update([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "Murilo Bernardes";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("MarkAsDone")]
        public GenericCommandResult MarkAsDone([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "Murilo Bernardes";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpPut("MarkAsUndone")]
        public GenericCommandResult MarkAsUndone([FromBody]CreateTodoCommand command, [FromServices]TodoHandler handler)
        {
            command.User = "Murilo Bernardes";
            return (GenericCommandResult)handler.Handle(command);
        }

        [HttpGet("")]
        public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repo)
        {
            var user = User.Claims.FirstOrDefault(p => p.Type == "user_id")?.Value;

            return repo.GetAll(user);
        }

        [HttpGet("Done")]
        public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repo)
        {
            var user = User.Claims.FirstOrDefault(p => p.Type == "user_id")?.Value;

            return repo.GetAllDone(user);
        }

        [HttpGet("GetAllUndone")]
        public IEnumerable<TodoItem> GetAllUndone([FromServices]ITodoRepository repo)
        {
            var user = User.Claims.FirstOrDefault(p => p.Type == "user_id")?.Value;

            return repo.GetAllDone(user);
        }

        [HttpGet("done/today")]
        public IEnumerable<TodoItem> GetDoneForToday([FromServices]ITodoRepository repo)
        {
            var user = User.Claims.FirstOrDefault(p => p.Type == "user_id")?.Value;

            return repo.GetByPeriod(user, DateTime.Now.Date, true);
        }

        [HttpGet("undone/today")]
        public IEnumerable<TodoItem> GetUndoneForToday([FromServices]ITodoRepository repo)
        {
            var user = User.Claims.FirstOrDefault(p => p.Type == "user_id")?.Value;

            return repo.GetByPeriod(user, DateTime.Now.Date, false);
        }

        [HttpGet("done/tomorrow")]
        public IEnumerable<TodoItem> GetDoneForTomorrow([FromServices]ITodoRepository repo)
        {
            var user = User.Claims.FirstOrDefault(p => p.Type == "user_id")?.Value;

            return repo.GetByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }
    }
}