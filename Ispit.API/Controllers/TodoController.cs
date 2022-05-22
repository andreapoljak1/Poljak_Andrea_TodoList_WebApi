using Ispit.API.Models;
using Ispit.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ispit.API.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        //konstruktor
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        // GET: api/<TodoController>
        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> GetTodoList()
        {
            try
            {
                return Ok(_todoRepository.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public IActionResult FindTodo(int id)
        {
            try
            {
                var todo = _todoRepository.GetToDoById(id);
                if (todo == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Rezultat nije pronađen");
                }
                return Ok(todo);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Nije moguće prikazati rezultate, dogodila se greška!");
            }

        }

        // POST api/<TodoController>
        [HttpPost]
        public ActionResult PostTodo(TodoList new_todo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var created_todo = _todoRepository.InsertToDo(new_todo);
                return Ok("Zapis je kreiran");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public ActionResult PutTodo(int id, TodoList update_todo)
        {
            try
            {

                if (id != update_todo.Id)
                {
                    return BadRequest("Parametri ID se ne poklapaju");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Podaci nisu validni!");
                }
                var idExist = _todoRepository.GetToDoById(id);
                if (idExist == null)
                {
                    return NotFound("Zapis nije pronađen");
                }

                return Ok(_todoRepository.UpdateToDo(update_todo));


            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Greška kod ažuriranja podataka");
            }

        }


        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Id nije dobar");
                }
                var todoDelete = _todoRepository.DeleteToDo(id);
                return Ok("Zapis je obrisan");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
