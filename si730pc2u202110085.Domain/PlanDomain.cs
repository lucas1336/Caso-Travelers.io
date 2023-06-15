using si730pc2u202110085.Domain.Exceptions;
using si730pc2u202110085.Domain.Infrastructure;
using si730pc2u202110085.Infrastructure.Infrastructure;
using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2u202110085.Domain;

public class PlanDomain : IPlanDomain
{
    IPlanInfrastructure _planInfrastructure;
    
    public PlanDomain(IPlanInfrastructure planInfrastructure)
    {
        _planInfrastructure = planInfrastructure;
    }
    
    public Plan Create(Plan plan)
    {
        PlanValidation(plan);
        return _planInfrastructure.Create(plan);
    }

    private void PlanValidation(Plan plan)
    {
        if (plan.Name == null)
            throw new PlanValidationException("Name es obligatorio");
        if (plan.maxUsers <= 0)
            throw new PlanValidationException("maxUsers no puede ser menor ni igual a 0");
        if (plan.isDefault != 0 && plan.isDefault != 1)
            throw new PlanValidationException("isDefault solo puede ser 0 o 1");
        if (_planInfrastructure.ExistsByName(plan.Name))
            throw new PlanValidationException("Ya existe un plan con ese nombre");
        if (plan.isDefault == 1 && _planInfrastructure.ExistsByIsDefault(1))
            throw new PlanValidationException("Ya existe un plan por defecto, isDefualt = 1");
    }
}