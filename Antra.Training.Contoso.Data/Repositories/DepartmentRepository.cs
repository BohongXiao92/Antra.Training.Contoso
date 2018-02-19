using Antra.Training.Contoso.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ContosoDbContext context) : base(context)
        { }

        public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
        {
            var departments = _context.Departments.Include(d => d.Courses).ToList();
            return departments;
        }
    }

    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Department> GetAllDepartmentsIncludeCourses();
    }
}
