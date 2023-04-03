using BaltaStore.Domain.StoreContext.Services;

namespace BaltaStore.Tests.Mocks
{
    public class MockEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}
