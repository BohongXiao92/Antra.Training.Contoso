using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Antra.Training.Contoso.Service
{
    public class DepartmentService : IDepartmentService
    {
        /*************** Constructor ****************/
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;
        /*************** Methods ****************/
        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }
        public Department GetDepartmentById(int id)
        {
            return _departmentRepository.GetById(id);
        }
        public IEnumerable<Department> GetDepartmentByName(string name)
        {
            return _departmentRepository.GetMany(d => d.Name.Contains(name)).ToList();
        }
        public IEnumerable<Department> GetAllDepartmentsIncludeCourses()
        {
            return _departmentRepository.GetAllDepartmentsIncludeCourses();
        }
        public void CreateDepartment(Department dep)
        {
            using (var transaction = new TransactionScope())
            {
                _departmentRepository.Add(dep);
                _departmentRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateDepartment(Department dep)
        {
            using (var transaction = new TransactionScope())
            {
                _departmentRepository.Update(dep);
                _departmentRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface IDepartmentService
    {
        IEnumerable<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        IEnumerable<Department> GetDepartmentByName(string name);
        IEnumerable<Department> GetAllDepartmentsIncludeCourses();
        void UpdateDepartment(Department dep);
        void CreateDepartment(Department dep);
    }
}
