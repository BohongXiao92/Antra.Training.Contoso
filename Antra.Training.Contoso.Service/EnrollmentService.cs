using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Antra.Training.Contoso.Service
{

    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        public EnrollmentService(IEnrollmentRepository enrollmentRepository) => _enrollmentRepository = enrollmentRepository;
        public List<Enrollment> GetAllEnrollments()
        {
            return _enrollmentRepository.GetAll().ToList();
        }
        public Enrollment GetEnrollmentById(int roleId)
        {
            return _enrollmentRepository.GetById(roleId);
        }
        // TODO ... Get Role By Course Id
        public IEnumerable<Enrollment> GetEnrollmentByCourseId(int courseId) { throw new NotImplementedException(); }
        // TODO ... Get Role By student Id
        public IEnumerable<Enrollment> GetEnrollmentByStudentId(int studentId) { throw new NotImplementedException(); }
        public void CreateEnrollment(Enrollment enroll)
        {
            using (var transaction = new TransactionScope())
            {
                _enrollmentRepository.Add(enroll);
                _enrollmentRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateRole(Enrollment enroll)
        {
            using (var transaction = new TransactionScope())
            {
                _enrollmentRepository.Update(enroll);
                _enrollmentRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface IEnrollmentService
    {
        List<Enrollment> GetAllEnrollments();
    }
}
