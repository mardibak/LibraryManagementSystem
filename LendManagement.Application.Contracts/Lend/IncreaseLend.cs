namespace LendManagement.Application.Contract.Lend
{
    public class IncreaseLend
    {
        public long LendId { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
    }
}
