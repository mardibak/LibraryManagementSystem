namespace LendManagement.Application.Contract.Lend
{
    public class LendSearchModel
    {
        public long BookId { get; set; }
        public string Borrower { get; set; }
        public string MembershipCode { get; set; }
        public bool Lended { get; set; }
    }
}
