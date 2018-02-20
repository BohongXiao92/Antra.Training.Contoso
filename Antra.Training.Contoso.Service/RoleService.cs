using Antra.Training.Contoso.Data.Repositories;
using Antra.Training.Contoso.Model;
using System.Collections.Generic;
using System.Linq;

namespace Antra.Training.Contoso.Service
{

    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository) => _roleRepository = roleRepository;

        public List<Role> GetAllRoles()
        {
            return _roleRepository.GetAll().ToList();
        }

    }

    public interface IRoleService
    {
        List<Role> GetAllRoles();
    }
}
