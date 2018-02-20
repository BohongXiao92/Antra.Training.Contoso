using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface IEnrollmentRepository : IRepository<Enrollment>
    { }
}
