using Antra.Training.Contoso.Model;
using System.Linq;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class StudentRepository : GenericRepository<Instructor>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext context) : base(context)
        {}

        public Instructor GetStudentByLastName(string lastName)
        {
            var student = _context.Persons.OfType<Instructor>().FirstOrDefault(s => s.LastName == lastName);
            return student;
        }
    }

    public interface IStudentRepository : IRepository<Instructor>
    {
        Instructor GetStudentByLastName(string lastName);
    }
}
