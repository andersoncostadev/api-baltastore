using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests.ValueObjects
{

    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Costa");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}
