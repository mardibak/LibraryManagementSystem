using AppFramework.Application;
using LendManagement.Application.Contract.Lend;
using LendManagement.Domain.LendAgg;
using System.Collections.Generic;

namespace LendManagement.Application
{
    public class LendApplication : ILendApplication
    {
        private readonly ILendRepository _lendRepository;

        public LendApplication(ILendRepository lendRepository)
        {
            _lendRepository = lendRepository;
        }

        public OperationResult Create(CreateLend command)
        {
            var operation = new OperationResult();
            if (_lendRepository.Exists(x => x.BookId == command.BookId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var lend = new Lend(command.BookId, command.Borrower, command.MembershipCode, command.ReturnTime, command.UnitPrice);
            _lendRepository.Create(lend);
            _lendRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Edit(EditLend command)
        {
            var operation = new OperationResult();
            var lend = _lendRepository.Get(command.Id);
            if (lend == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_lendRepository.Exists(x => x.BookId == command.BookId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            lend.Edit(command.BookId,command.Borrower,command.MembershipCode,command.ReturnTime, command.UnitPrice);
            _lendRepository.SaveChanges();
            return operation.Succeeded();
        }

        public EditLend GetDetails(long id)
        {
            return _lendRepository.GetDetails(id);
        }

        public List<LendOperationViewModel> GetOperationLog(long operationId)
        {
            return _lendRepository.GetOperationLog(operationId);
        }

        public OperationResult Increase(IncreaseLend command)
        {
            var operation = new OperationResult();
            var lend = _lendRepository.Get(command.LendId);
            if (lend == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            const long operatorId = 1;
            lend.Increase(command.Count, operatorId, command.Description);
            _lendRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Reduce(ReduceLend command)
        {
            var operation = new OperationResult();
            var lend = _lendRepository.Get(command.LendId);
            if (lend == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            const long operatorId = 1;
            lend.Reduce(command.Count, operatorId, command.Description, 0);
            _lendRepository.SaveChanges();
            return operation.Succeeded();
        }

        public OperationResult Reduce(List<ReduceLend> command)
        {
            var operation = new OperationResult();
            const long operatorId = 1;
            foreach (var item in command)
            {
                var lend = _lendRepository.GetBy(item.BookId);
                lend.Reduce(item.Count, operatorId, item.Description, item.OrderId);
            }
            _lendRepository.SaveChanges();
            return operation.Succeeded();
        }

        public List<LendViewModel> Search(LendSearchModel searchModel)
        {
            return _lendRepository.Search(searchModel);
        }
    }
}
