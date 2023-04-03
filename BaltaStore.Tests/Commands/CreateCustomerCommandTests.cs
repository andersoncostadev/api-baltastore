using BaltaStore.Domain.StoreContext.Commands.CustomesCommands.Inputs;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Anderson";
            command.LastName = "Costa";
            command.Document = "75018481064";
            command.Email = "anderson@email.com";
            command.Phone = "(69) 98910-9878";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
