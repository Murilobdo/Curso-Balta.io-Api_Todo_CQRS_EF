using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>
    {

        private readonly ITodoRepository repository;

        public TodoHandler(ITodoRepository repository)
        {
            repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, Comando invalido !", command.Notifications);

            var todoItem = new TodoItem(command.Title, DateTime.Now, command.User);

            repository.Create(todoItem);

            return new GenericCommandResult(true, "Tarefa cadastrada !", todoItem);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, Comando invalido !", command.Notifications);

            var todoItem = new TodoItem(command.Title, DateTime.Now, command.User);

            repository.Update(todoItem);

            return new GenericCommandResult(true, "Tarefa atualizada !", todoItem);
        }
    }
}
