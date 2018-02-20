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
        /*************** Constructor ****************/
        private readonly IPersonRepository _personRepository;
        private readonly IStudentRepository _studentRepository;
        public StudentService(IPersonRepository personRepository, IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            _personRepository = personRepository;
        }
        /*************** Methods ****************/
        public IEnumerable<Student> GetAllStudents(int? page, int pageSize, out int totalCount)
        {
            var students = _studentRepository.GetPagedList(out totalCount, page, pageSize, null, null, new SortExpression<Student>(s => s.FirstName, ListSortDirection.Ascending));
            return students;
        }
        public Student GetStudentById(int id)
        {
            return _studentRepository.GetById(id);
        }
        public IEnumerable<Student> GetStudentByName(string name)
        {
            return _studentRepository.GetMany(s => s.LastName.Contains(name) || s.FirstName.Contains(name)).ToList();
        }
        public Student GetStudentByLastName(string lastName)
        {
            return _studentRepository.GetStudentByLastName(lastName);
        }
        // TODO ... Get Student By Code
        public Student GetStudentByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }
        // TODO ... Get Courses Group By Student
        public IEnumerable<Student> GetAllStudentsIncludeCourses()
        {
            throw new NotImplementedException();
        }
        public void CreateStudent(Student student)
        {
            using (var transaction = new TransactionScope())
            {
                _personRepository.Add(student);
                _personRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateStudent(Student student)
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
        IEnumerable<Student> GetAllStudents(int? page, int pageSize, out int totalCount);
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentByName(string name);
        Student GetStudentByLastName(string lastName);
        Student GetStudentByCode(string employeeCode);
        IEnumerable<Student> GetAllStudentsIncludeCourses();
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
    }
}
