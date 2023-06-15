using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using si730pc2.API.Input;
using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2.API.Mapper;

public class InputToModel : Profile
{
    public InputToModel()
    {
        CreateMap<PlanInput, Plan>();
    }
}