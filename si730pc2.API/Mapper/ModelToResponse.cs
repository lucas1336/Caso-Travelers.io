using AutoMapper;
using si730pc2.API.Response;
using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2.API.Mapper;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<Plan, PlanResponse>();
    }
}