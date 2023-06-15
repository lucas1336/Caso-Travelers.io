using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using si730pc2.API.Input;
using si730pc2.API.Response;
using si730pc2u202110085.Domain.Exceptions;
using si730pc2u202110085.Domain.Infrastructure;
using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2.API.Controllers
{
    [Route("api/v1/plan")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        // Inject IPlanDomain
        IPlanDomain _planDomain;
        IMapper _mapper;
        
        public PlanController(IPlanDomain planDomain, IMapper mapper)
        {
            _planDomain = planDomain;
            _mapper = mapper;
        }
        
        // POST: api/Plan
        [HttpPost]
        public ActionResult<PlanResponse> Post([FromBody] PlanInput planInput)
        {
            Plan plan = _mapper.Map<PlanInput, Plan>(planInput);
            try
            { 
                _planDomain.Create(plan);
                PlanResponse planResponse = _mapper.Map<Plan, PlanResponse>(plan);
                return Created("", planResponse);
            }
            catch (PlanValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }
    }
}
