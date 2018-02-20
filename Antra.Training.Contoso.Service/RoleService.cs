using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Antra.Training.Contoso.Service
{

    public class RoleService : IRoleService
    {
        /*************** Constructor ****************/
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;
        /*************** Methods ****************/
        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAll().ToList();
        }
        public Role GetRoleById(int roleId)
        {
            return _roleRepository.GetById(roleId);
        }
        public IEnumerable<Role> GetRoleByName(string name)
        {
            return _roleRepository.GetMany(r => r.RoleName.Contains(name)).ToList();
        }
        // TODO ... Get Role By Person Id
        public IEnumerable<Role> GetRoleByPersonName(int personId) { throw new NotImplementedException(); }
        public void CreateRole(Role role)
        {
            using (var transaction = new TransactionScope())
            {
                _roleRepository.Add(role);
                _roleRepository.SaveChanges();
                transaction.Complete();
            }
        }
        public void UpdateRole(Role role)
        {
            using (var transaction = new TransactionScope())
            {
                _roleRepository.Update(role);
                _roleRepository.SaveChanges();
                transaction.Complete();
            }
        }
    }

    public interface IRoleService
    {
        List<Role> GetAllRoles();
        Role GetRoleById(int roleId);
        IEnumerable<Role> GetRoleByName(string name);
        IEnumerable<Role> GetRoleByPersonName(int personId);
        void CreateRole(Role role);
        void UpdateRole(Role role);
    }
}
