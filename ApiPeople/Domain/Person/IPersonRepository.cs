using ApiPeople.Utils;

namespace ApiPeople.Domain.Person
{
    public interface IPersonRepository : IRepository<PersonQueryForm, PersonEntity, int>
    {
    }
}
