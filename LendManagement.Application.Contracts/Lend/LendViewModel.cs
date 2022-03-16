namespace LendManagement.Application.Contract.Lend
{
    public class LendViewModel
    {
        public long Id { get; set; }
        public string Book { get; set; }
        public long BookId { get; set; }
        public string Borrower { get; set; }
        public string MembershipCode { get; set; }
        public string ReturnTime { get; set; }
        public double UnitPrice { get; set; }
        public bool Lended { get; set; }
        public long CurrentCount { get; set; }
        public string CreationDate { get; set; }
    }
}
