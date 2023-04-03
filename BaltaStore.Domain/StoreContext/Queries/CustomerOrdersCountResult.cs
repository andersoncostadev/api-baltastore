namespace BaltaStore.Domain.StoreContext.Queries
{
    public class CustomerOrdersCountResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Orders { get; set; }
    }
}
