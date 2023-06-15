using si730pc2u202110085.Infrastructure.Context;
using si730pc2u202110085.Infrastructure.Infrastructure;
using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2u202110085.Infrastructure;

public class PlanInfrastructure : IPlanInfrastructure
{
    private ProjectContext _context;
    
    public PlanInfrastructure(ProjectContext context)
    {
        _context = context;
    }
    
    public Plan Create(Plan plan)
    {
        _context.Plans.Add(plan);
        _context.SaveChanges();
        return plan;
    }

    public bool ExistsByName(string name)
    {
        return _context.Plans.Any(p => p.Name == name);
    }

    public bool ExistsByIsDefault(int isDefault)
    {
        return _context.Plans.Any(p => p.isDefault == isDefault);
    }
}