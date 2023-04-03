using BaltaStore.Domain.StoreContext.Commands.CustomesCommands.Inputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Tests.Mocks;
using System.Runtime.Intrinsics.Arm;

namespace BaltaStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Anderson";
            command.LastName = "Costa";
            command.Document = "88567483042";
            command.Email = "anderson@email.com";
            command.Phone= "14998757511";

            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new MockCustomerRepository(), new MockEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }

    }
}
