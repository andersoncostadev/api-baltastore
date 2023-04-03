using BaltaStore.Domain.StoreContext.Commands.CustomesCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomesCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entites;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _customerRepository= repository;
            _emailService= emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF já existe na base
            if (_customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF ja está em uso");

            //Verificar se o Email já existe na base
            if (_customerRepository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail ja está em uso");

            //Criar os VOs
            var name = new Name(command.LastName, command.FirstName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar as Entidades
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return new CommandResult(
                    false, "Por favor, corrija os campos abaixo", Notifications);

            //Persistir o cliente no banco
            _customerRepository.Save(customer);

            //Enviar um E-mail de boas vindas
            _emailService.Send(email.Address, "andersonmtb88@gmail.com", "Bem vindo", "Seja bem vindo ao Balta Store!");

            return new CommandResult(true, "Bem vindo ao Balta Store", new 
            {
                Id = customer.Id,
                Name = name.ToString(),
                Email = email.Address

            });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
