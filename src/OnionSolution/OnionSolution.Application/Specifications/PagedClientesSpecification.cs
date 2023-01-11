using Ardalis.Specification;
using OnionSolution.Core.Domain.Entities;

namespace OnionSolution.Core.Application.Specifications
{
    public class PagedClientesSpecification : Specification<Client>
    {
        public PagedClientesSpecification(int pageSize, int pageNumber, string name, string surname)
        {
            Query.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);

            if (!string.IsNullOrEmpty(name))
                Query.Search(x => x.Name, "%" + name + "%");

            if (!string.IsNullOrEmpty(surname))
                Query.Search(x => x.Surname, "%" + surname + "%");
        }
    }
}
