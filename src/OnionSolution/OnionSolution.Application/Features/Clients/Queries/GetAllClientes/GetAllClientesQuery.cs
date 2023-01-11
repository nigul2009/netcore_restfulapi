using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using OnionSolution.Core.Application.DTOs;
using OnionSolution.Core.Application.Interfaces;
using OnionSolution.Core.Application.Specifications;
using OnionSolution.Core.Application.Wrappers;
using OnionSolution.Core.Domain.Entities;
using System.Text;

namespace OnionSolution.Core.Application.Features.Clients.Queries.GetAllClientes
{
    public class GetAllClientesQuery : IRequest<PagedResponse<List<ClientDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }

    public class GetAllClientesQueryHandler : IRequestHandler<GetAllClientesQuery, PagedResponse<List<ClientDto>>>
    {
        private readonly IRepositoryAsync<Client> _repositoryAsync;
        private readonly IMapper _mapper;
        //private readonly IDistributedCache _distributedCache;

        public GetAllClientesQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper/*, IDistributedCache distributedCache*/)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            //_distributedCache = distributedCache;
        }

        public async Task<PagedResponse<List<ClientDto>>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {

            //var cacheKey = $"clientsLst_{request.PageSize}_{request.PageNumber}_{request.Name}_{request.Surname}";
            //string serializedListadoClientes;
           
            //var redisListadoClientes = await _distributedCache.GetAsync(cacheKey);
            List<Client>? clientsLst;
            //if (redisListadoClientes != null)
            //{
            //    serializedListadoClientes = Encoding.UTF8.GetString(redisListadoClientes);
            //    clientsLst = JsonConvert.DeserializeObject<List<Client>>(serializedListadoClientes);
            //}
            //else
            //{
                clientsLst = await _repositoryAsync.ListAsync(new PagedClientesSpecification(request.PageSize, request.PageNumber, request.Name, request.Surname), cancellationToken);
            //    serializedListadoClientes = JsonConvert.SerializeObject(clientsLst);
            //    redisListadoClientes = Encoding.UTF8.GetBytes(serializedListadoClientes);

            //    var options = new DistributedCacheEntryOptions()
            //                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
            //                .SetSlidingExpiration(TimeSpan.FromMinutes(2));

            //    await _distributedCache.SetAsync(cacheKey, redisListadoClientes, options, cancellationToken);
            //}

            var clientesDto = _mapper.Map<List<ClientDto>>(clientsLst);
            return new PagedResponse<List<ClientDto>>(clientesDto, request.PageNumber, request.PageSize);
        }
    }
}

