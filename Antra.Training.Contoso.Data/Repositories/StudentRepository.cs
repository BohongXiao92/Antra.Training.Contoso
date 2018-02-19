using Antra.Training.Contoso.Model;
using System.Linq;

namespace Antra.Training.Contoso.Data.Repositories
{
    class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ContosoDbContext context) : base(context)
        {}

        public Student GetStudentByLastName(string lastName)
        {
            var student = _context.Persons.OfType<Student>().FirstOrDefault(s => s.LastName == lastName);
            return student;
        }
    }

    public interface IStudentRepository : IRepository<Student>
    {
        Student GetStudentByLastName(string lastName);
    }
}
