using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Antra.Training.Contoso.Service
{
    public class OfficeAssignmentService : IOfficeAssignmentService
    {
        /*************** Constructor ****************/
        private readonly IOfficeAssignmentsRepository _officeAssignmentRepository;
        public OfficeAssignmentService(IOfficeAssignmentsRepository officeAssignmentRepository) => _officeAssignmentRepository = officeAssignmentRepository;
        /*************** Methods ****************/
        public List<OfficeAssignment> GetAllOfficeAssignmets()
        {
            return _officeAssignmentRepository.GetAll().ToList();
        }
        public OfficeAssignment GetOfficeAssignmentById(int instructorId)
        {
            return _officeAssignmentRepository.GetById(instructorId);
        }
        public IEnumerable<OfficeAssignment> getOfficeAssignmentByLocation(string location)
        {
            return _officeAssignmentRepository.GetMany(o => o.Location.Contains(location)).ToList();
        }
        public void CreateOfficeAssignmetnt(OfficeAssignment office)
        {
            using (var transaction = new TransactionScope())
            {
                _officeAssignmentRepository.Add(office);
                _officeAssignmentRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateOfficeAssignment(OfficeAssignment office)
        {
            using (var transaction = new TransactionScope())
            {
                _officeAssignmentRepository.Update(office);
                _officeAssignmentRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface IOfficeAssignmentService
    {
        List<OfficeAssignment> GetAllOfficeAssignmets();
        OfficeAssignment GetOfficeAssignmentById(int instructorId);
        IEnumerable<OfficeAssignment> getOfficeAssignmentByLocation(string location);
        void CreateOfficeAssignmetnt(OfficeAssignment office);
        void UpdateOfficeAssignment(OfficeAssignment office);

    }
}
