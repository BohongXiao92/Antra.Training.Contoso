using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface IInstructorRepository : IRepository<Instructor>
    { }
}
