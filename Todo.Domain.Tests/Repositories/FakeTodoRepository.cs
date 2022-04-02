using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        private IList<TodoItem> _todoList;

        public FakeTodoRepository()
        {
            _todoList = new List<TodoItem>();
        }

        public void Create(TodoItem todo)
        {
            throw new NotImplementedException();
        }

        public void Update(TodoItem todo)
        {
            throw new NotImplementedException();
        }
    }
}
