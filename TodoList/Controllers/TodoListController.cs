using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Contracts;
using TodoList.Models;
using TodoList.Resource;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private ITodoListRepository repo;
        private readonly IMapper mapper;
        public TodoListController(ITodoListRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todoLists = this.repo.FindByCondition(p => p.Id != 5000);
            var result = this.mapper.Map<IEnumerable<Models.TodoList>, IEnumerable<TodoListResource>>(todoLists);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] SaveTodoList todoList)
        {
            var mapperList = this.mapper.Map<SaveTodoList, Models.TodoList>(todoList);
            try
            {
                var result = this.repo.Create(mapperList);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Erro = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var data = this.repo.FindByCondition(todo => todo.Id == id);
            var result = this.mapper.Map<IEnumerable<Models.TodoList>, IEnumerable<TodoListResource>>(data);
            return Ok(result);
        }
    
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var deletedTodo = this.repo.FindByCondition(todo => todo.Id == id).FirstOrDefault();

            if(deletedTodo == null){
                return BadRequest(new {
                    Message = "Registro não encontrado"
                });
            }
            try
            {
                this.repo.Delete(deletedTodo);
                return Ok(deletedTodo);
            }
            catch(Exception ex)
            {
                return BadRequest(new {
                    Message = ex.Message
                });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TodoListResource todoList)
        {
            var mapperList = this.mapper.Map<TodoListResource, Models.TodoList>(todoList);
            this.repo.Update(mapperList);
            return Ok();
        }
    }
}
