using Antra.Training.Contoso.Data;
using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Student> GetAllStudents()
        {
            var students = _studentRepository.GetAll().ToList();
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

        public Student GetStudentByCode(string employeeCode)
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
            throw new NotImplementedException();
        }

    }

    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        IEnumerable<Student> GetStudentByName(string name);
        Student GetStudentByCode(string employeeCode);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
    }
}
