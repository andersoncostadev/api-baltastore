using BaltaStore.Domain.StoreContext.Entites;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using BaltaStore.Domain.StoreContext.Commands.CustomesCommands.Inputs;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Shared.Commands;
using BaltaStore.Domain.StoreContext.Commands.CustomesCommands.Outputs;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerHandler _customerHandler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _customerRepository = repository;
            _customerHandler = handler;
        }


        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration= 15)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _customerRepository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _customerRepository.GetById(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _customerRepository.GetOrders(id);
        } 

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_customerHandler.Handle(command);
            return result;
        }

        //[HttpPut]
        //[Route("customers/{id}")]
        //public Customer Put([FromBody] CreateCustomerCommand command)
        //{
        //    var name = new Name(command.FirstName, command.LastName);
        //    var document = new Document(command.Document);
        //    var email = new Email(command.Email);
        //    var customer = new Customer(name, document, email, command.Phone);
        //    return customer;
        //}


        //[HttpDelete]
        //[Route("customers/{id}")]
        //public object Delete()
        //{
        //    return new { message = "Cliente removido com sucesso!" };
        //}
    }
}
