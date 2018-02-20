using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class OfficeAssignmentsRepository : GenericRepository<OfficeAssignment>, IOfficeAssignmentsRepository
    {
        public OfficeAssignmentsRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface IOfficeAssignmentsRepository : IRepository<OfficeAssignment>
    { }
}
