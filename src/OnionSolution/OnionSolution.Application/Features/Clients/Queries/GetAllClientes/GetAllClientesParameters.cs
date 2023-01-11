using OnionSolution.Core.Application.Parameters;

namespace OnionSolution.Core.Application.Features.Clients.Queries.GetAllClientes
{
    public class GetAllClientesParameters : RequestParameter
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
