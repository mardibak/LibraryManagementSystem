using AppFramework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LendManagement.Domain.LendAgg
{
    public class Lend : EntityBase
    {
        public long BookId { get; private set; }
        public string Borrower { get; private set; }
        public string MembershipCode { get; private set; }
        public string ReturnTime { get; private set; }
        public double UnitPrice { get; private set; }
        public bool Lended { get; private set; }
        public List<LendOperation> Operations { get; private set; }

        public Lend(long bookId, string borrower, string membershipCode, string returnTime, double unitPrice)
        {
            BookId = bookId;
            Borrower = borrower;
            MembershipCode = membershipCode;
            ReturnTime = returnTime;
            UnitPrice = unitPrice;
        }
        public void Edit(long bookId, string borrower, string membershipCode, string returnTime, double unitPrice)
        {
            BookId = bookId;
            Borrower = borrower;
            MembershipCode = membershipCode;
            ReturnTime = returnTime;
            UnitPrice = unitPrice;
        }
        public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count, long operatorId, string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new LendOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            Lended = currentCount > 0;
        }
        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new LendOperation(false, count, operatorId, currentCount, description, orderId, Id);
            Operations.Add(operation);
            Lended = currentCount > 0;
        }
    }
}
