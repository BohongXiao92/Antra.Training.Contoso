using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface IRoleRepository : IRepository<Role>
    { }
}
