using Ispit.API.Models;

namespace Ispit.Data.Interfaces
{
    public interface ITodoRepository
    {
        IEnumerable<TodoList> GetAll();
        TodoList GetToDoById(int id);
        TodoList InsertToDo(TodoList movie);
        TodoList UpdateToDo(TodoList movie);
        TodoList DeleteToDo(int id);
    }
}
