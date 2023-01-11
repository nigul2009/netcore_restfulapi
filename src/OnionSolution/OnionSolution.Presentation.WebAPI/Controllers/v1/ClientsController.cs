using Microsoft.AspNetCore.Mvc;
using OnionSolution.Core.Application.Features.Clients.Commands.CreateClientCommand;
using OnionSolution.Core.Application.Features.Clients.Queries.GetAllClientes;

namespace OnionSolution.Presentation.WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClientsController : BaseApiController
    {
        // GET: api/<ClientsController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllClientesParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllClientesQuery
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Name = filter.Name,
                Surname = filter.Surname
            }));
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateClienteCommand command)
        {
            //{
            //    "name": "jorge",
            //    "surname": "garcia",
            //    "dateOfBirth": "1983-06-21",
            //    "telephone": "555555666",
            //    "email":  "jorge@gg.es",
            //    "address": "ave vicente ferrer 17"
            //}
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
