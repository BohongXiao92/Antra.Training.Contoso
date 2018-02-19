using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System;
using System.Collections.Generic;

namespace Antra.Training.Contoso.Service
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public IEnumerable<Instructor> GetAllInstructors(int? page, int pageSize, out int totalCount)
        {
            throw new NotImplementedException();
        }

        public Instructor GetInstructorById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Instructor> GetInstructorByName(string name)
        {
            throw new NotImplementedException();
        }

        public Instructor GetInstructorByCode(string employeeCode)
        {
            throw new NotImplementedException();
        }

        public void CreateInstructor(Instructor instructor)
        {
            _instructorRepository.Add(instructor);
        }

        public void UpdateInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }

    public interface IInstructorService
    {
        IEnumerable<Instructor> GetAllInstructors(int? page, int pageSize, out int totalCount);
        Instructor GetInstructorById(int id);
        IEnumerable<Instructor> GetInstructorByName(string name);
        Instructor GetInstructorByCode(string employeeCode);
        void CreateInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
    }
}
