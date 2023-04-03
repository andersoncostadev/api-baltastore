using BaltaStore.Domain.StoreContext.ValueObjects;

namespace BaltaStore.Tests;

[TestClass]
public class DocumentTests
{
    private Document validDocument;
    private Document invalidDocument;
    public DocumentTests()
    {
        validDocument = new Document("34097049062");
        invalidDocument = new Document("12345678910");
    }

    [TestMethod]
    public void ShouldReturnNotificationWhenDocumentIsNotValid()
    {
        Assert.AreEqual(false, invalidDocument.IsValid);
        Assert.AreEqual(1, invalidDocument.Notifications.Count);
    }

    [TestMethod]
    public void ShouldReturnNotNotificationWhenDocumentIsValid()
    {
        Assert.AreEqual(true, validDocument.IsValid);
        Assert.AreEqual(0, validDocument.Notifications.Count);
    }
}