namespace LendManagement.Application.Contract.Lend
{
    public class ReduceLend
    {
        public long LendId { get; set; }
        public long BookId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderId { get; set; }

        public ReduceLend() { }

        public ReduceLend(long bookId, long count, string description, long orderId)
        {
            BookId = bookId;
            Count = count;
            Description = description;
            OrderId = orderId;
        }
    }
}
