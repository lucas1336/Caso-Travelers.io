using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2u202110085.Domain.Infrastructure;

public interface IPlanDomain
{
    public Plan Create(Plan plan);
}