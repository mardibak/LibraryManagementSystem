using System;

namespace LendManagement.Domain.LendAgg
{
    public class LendOperation
    {
        public long Id { get; private set; }
        public bool Operation { get; private set; }
        public long Count { get; private set; }
        public long OperatorId { get; private set; }
        public DateTime OperationDate { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; set; }
        public long OrderId { get; private set; }
        public long LendId { get; private set; }
        public Lend Lend { get; private set; }
        protected LendOperation() { }

        public LendOperation(bool operation, long count, long operationId,
            long currentCount, string descriotion, long orderId, long lendId)
        {
            Operation = operation;
            Count = count;
            OperatorId = operationId;
            CurrentCount = currentCount;
            Description = descriotion;
            OrderId = orderId;
            LendId = lendId;
            OperationDate = DateTime.Now;
        }
    }
}
