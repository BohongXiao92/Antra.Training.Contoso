using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface ICourseRepository : IRepository<Course>
    {}
}
