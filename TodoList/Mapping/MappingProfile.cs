using AutoMapper;
using TodoList.Models;
using TodoList.Resource;

namespace TodoList.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Resource to Domain
            CreateMap<SaveTodoList, Models.TodoList>();
            CreateMap<TodoListResource, Models.TodoList>();
            CreateMap<SaveItemResource, TodoItem>().ForMember(todoItem => todoItem.TodoList, dto => dto.MapFrom(x => new Models.TodoList() { Id = x.TodoList}));
            CreateMap<TodoItemResource, TodoItem>().ForMember(todoItem => todoItem.TodoList, dto => dto.MapFrom(x => new Models.TodoList() { Id = x.TodoList}));

            // Domain to Resource
            CreateMap<Models.TodoList, TodoListResource>();
            CreateMap<Models.TodoList, SaveTodoList>();
            CreateMap<TodoItem, TodoItemResource>().ForMember(resource => resource.TodoList, item => item.MapFrom(data => data.TodoList.Id));
        }
    }
}