using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICoursepository
    {
        public CourseRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface ICoursepository : IRepository<Course>
    {}
}
