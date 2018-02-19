using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System.Collections.Generic;

namespace Antra.Training.Contoso.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
        {
            return _departmentRepository.GetAllDepartmentsIncludeCourses();
        }
    }

    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Department> GetAllDepartmentsIncludeCourses();
    }
}
