using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using Antra.Training.Contoso.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Transactions;

namespace Antra.Training.Contoso.Service
{
    public class StudentService : IStudentService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IPersonRepository personRepository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _personRepository = personRepository;
        }
        public IEnumerable<Instructor> GetAllStudents(int? page, int pageSize, out int totalCount)
        {
            var students = _studentRepository.GetPagedList(out totalCount, page, pageSize, null, null,
                new SortExpression<Instructor>(s => s.FirstName, ListSortDirection.Ascending));
            return students;
        }
        public Instructor GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }
        public IEnumerable<Instructor> GetStudentByName(string name)
        {
            return _studentRepository.GetMany(s => s.LastName.Contains(name) || s.FirstName.Contains(name)).ToList();
        }
        // TODO ...
        public Instructor GetStudentByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }
        public void CreateStudent(Instructor student)
        {
            using (var transaction = new TransactionScope())
            {
                _personRepository.Add(student);
                _personRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateStudent(Instructor student)
        {
            using (var transaction = new TransactionScope())
            {
                _personRepository.Update(student);
                _personRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface IStudentService
    {
        IEnumerable<Instructor> GetAllStudents(int? page, int pageSize, out int totalCount);
        Instructor GetStudentById(int id);
        IEnumerable<Instructor> GetStudentByName(string name);
        Instructor GetStudentByCode(string employeeCode);
        void CreateStudent(Instructor student);
        void UpdateStudent(Instructor student);
    }
}
