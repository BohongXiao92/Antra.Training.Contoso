using Antra.Training.Contoso.Model;

namespace Antra.Training.Contoso.Data.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ContosoDbContext context) : base(context)
        { }
    }

    public interface IPersonRepository : IRepository<Person>
    { }
}
