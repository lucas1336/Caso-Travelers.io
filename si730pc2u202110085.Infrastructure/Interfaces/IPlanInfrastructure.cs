using si730pc2u202110085.Infrastructure.Models;

namespace si730pc2u202110085.Infrastructure.Infrastructure;

public interface IPlanInfrastructure
{
    public Plan Create(Plan plan);
    public bool ExistsByName(string name);
    public bool ExistsByIsDefault(int isDefault);
}