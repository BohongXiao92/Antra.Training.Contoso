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
    public class InstructorService : IInstructorService
    {

        /*************** Constructor ****************/
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository) => _instructorRepository = instructorRepository;
        /*************** Methods ****************/
        public IEnumerable<Instructor> GetAllInstructors(int? page, int pageSize, out int totalCount)
        {
            var instructors = _instructorRepository.GetPagedList(out totalCount, page, pageSize, null, null, new SortExpression<Instructor>(s => s.FirstName, ListSortDirection.Ascending)).ToList();
            return instructors;
        }
        public Instructor GetInstructorById(int id)
        {
            return _instructorRepository.GetById(id);
        }
        public IEnumerable<Instructor> GetInstructorByName(string name)
        {
            return _instructorRepository.GetMany(s => s.LastName.Contains(name) || s.FirstName.Contains(name)).ToList();
        }
        // TODO ... Get Instructor By Code
        public Instructor GetInstructorByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }
        // TODO ... Get Courses Group By Instructor
        public IEnumerable<Instructor> GetAllInstructorIncludeCourses()
        {
            throw new NotImplementedException();
        }
        public void CreateInstructor(Instructor instructor)
        {
            using (var transaction = new TransactionScope())
            {
                _instructorRepository.Add(instructor);
                _instructorRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateInstructor(Instructor instructor)
        {
            using (var transaction = new TransactionScope())
            {
                _instructorRepository.Update(instructor);
                _instructorRepository.SaveChanges();
                transaction.Complete();
            }
        }

    }

    public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllInstructors(int? page, int pageSize, out int totalCount);
        Instructor GetInstructorById(int id);
        IEnumerable<Instructor> GetInstructorByName(string name);
        Instructor GetInstructorByCode(string employeeCode);
        IEnumerable<Instructor> GetAllInstructorIncludeCourses()
        void CreateInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
    }
}
