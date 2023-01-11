using AutoMapper;
using MediatR;
using OnionSolution.Core.Application.Interfaces;
using OnionSolution.Core.Application.Wrappers;
using OnionSolution.Core.Domain.Entities;

namespace OnionSolution.Core.Application.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClienteCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var nuevoRegistro = _mapper.Map<Client>(request);
            var data = await _repositoryAsync.AddAsync(nuevoRegistro);

            return new Response<int>(data.Id);
        }
    }
}
