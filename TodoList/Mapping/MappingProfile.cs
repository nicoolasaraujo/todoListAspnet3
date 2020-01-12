using AutoMapper;
using TodoList.Resource;

namespace TodoList.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SaveTodoList, Models.TodoList>();
            CreateMap<TodoListResource, Models.TodoList>();


            CreateMap<Models.TodoList, TodoListResource>();
            CreateMap<Models.TodoList, SaveTodoList>();
            CreateMap<Models.TodoList, TodoListResource>();
        }
        // Resource to Domain
    
    // CreateMap<SaveUserResource, User>();
    // CreateMap<SavePetResource, Pet>().ForMember(pet => pet.PetUser, dto => dto.MapFrom(x => x.Users.Select(user => new UserPet() { UserCode = new Guid(user) })));
    // CreateMap<PetResource, Pet>().ForMember(pet => pet.PetUser, dto => dto.MapFrom(x => x.Users.Select(user => new UserPet() { UserCode = new Guid(user), PetCode = x.Code })));

    // // Domain to Resource
    // CreateMap<User, UserResource>();
    // CreateMap<Pet, SavePetResource>();
    // CreateMap<Pet, PetResource>().ForMember(rscr => rscr.Users, pet => pet.MapFrom(data => data.PetUser.Select(petUser => petUser.UserCode.ToString().ToList())));

    }
}