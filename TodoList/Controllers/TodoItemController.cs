using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoList.Contracts;
using TodoList.Models;
using TodoList.Resource;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoItemController : ControllerBase
    {
        private ITodoItemRepository itemRepo;
        private IMapper mapper;
        public TodoItemController(ITodoItemRepository itemRepo, IMapper mapper)
        {
            this.itemRepo = itemRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = this.itemRepo.FindAll().ToList();
            var result = this.mapper.Map<List<TodoItem>, List<TodoItemResource>>(data);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var data = this.itemRepo.FindByCondition(item => item.Id == id).ToList();
            var result = this.mapper.Map<List<TodoItem>, List<TodoItemResource>>(data);
            return Ok(result);
        }

        [HttpGet, Route("itembylist/{ListId}")]
        public IActionResult GetByListId([FromRoute] int ListId)
        {
            var data = this.itemRepo.FindByCondition(item => item.TodoList.Id == ListId).ToList();
            var result = this.mapper.Map<List<TodoItem>, List<TodoItemResource>>(data);
            return Ok(data);
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] SaveItemResource item)
        {
            var mappedItem = this.mapper.Map<SaveItemResource, TodoItem>(item);
            var domainItem = this.itemRepo.Create(mappedItem);
            var result = this.mapper.Map<TodoItem, TodoItemResource>(domainItem);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveItem([FromRoute] int id)
        {
            var itemToDelete = this.itemRepo.FindByCondition(item => item.Id == id).FirstOrDefault();
            if (itemToDelete == null)
            {
                return BadRequest(new
                {
                    Message = "Item não encontrado!"
                });
            }
            try
            {
                this.itemRepo.Delete(itemToDelete);
                var result = this.mapper.Map<TodoItem, TodoItemResource>(itemToDelete);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(
                    new
                    {
                        Message = "Erro ao remover item!",
                        Exception = ex.Message
                    }
                );
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem([FromRoute] int id, [FromBody] TodoItemResource item)
        {
            var itemToUpdate = this.itemRepo.FindByCondition(item => item.Id == id).FirstOrDefault();
            if (itemToUpdate == null)
            {
                return BadRequest(new
                {
                    Message = "Item não encontrado!"
                });
            }
            var mappedItem = this.mapper.Map<TodoItemResource, TodoItem>(item);
            mappedItem.Id = id;
            this.itemRepo.Update(mappedItem);
            return Ok();

        }
    }
}