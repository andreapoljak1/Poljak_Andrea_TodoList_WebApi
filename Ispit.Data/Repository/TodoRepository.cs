using Ispit.API.Data;
using Ispit.API.Models;
using Ispit.Data.Interfaces;

namespace Ispit.Data.Repository
{
    public class TodoRepository:ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoList> GetAll()
        {
            return _context.TodoList.ToList();
        }

        public TodoList GetToDoById(int id)
        {
            return _context.TodoList.FirstOrDefault(s => s.Id == id);
        }
        public TodoList InsertToDo(TodoList new_todo)
        {
            var searchMovie = _context.TodoList.FirstOrDefault(s => s.Id == new_todo.Id);
           
            var result = _context.TodoList.Add(new_todo);
            _context.SaveChanges();
            return result.Entity;
        }
        public TodoList UpdateToDo(TodoList update_todo)
        {
            var result = _context.TodoList.FirstOrDefault(s => s.Id == update_todo.Id);
             _context.SaveChanges();
            return result;
        }
        public TodoList DeleteToDo(int id)
        {
            var result = _context.TodoList.FirstOrDefault(s => s.Id == id);
            if (result != null)
            {
                _context.TodoList.Remove(result);
                _context.SaveChanges();
            }

            return null;
        }




    }
}
