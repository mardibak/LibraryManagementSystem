using AppFramework.Application;
using AppFramework.Infrastructure;
using LendManagement.Application.Contract.Lend;
using LendManagement.Domain.LendAgg;
using Library.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace LendManagement.Infrastructure.EFCore.Repositories
{
    public class LendRepository : RepositoryBase<long, Lend>, ILendRepository
    {
        private readonly LibraryContext _libraryContext;
        private readonly LendContext _lendContext;

        public LendRepository(LendContext lendContext, LibraryContext libraryContext) : base(lendContext)
        {
            _lendContext = lendContext;
            _libraryContext = libraryContext;
        }

        public Lend GetBy(long lendId)
        {
            return _lendContext.Lending.FirstOrDefault(x => x.BookId == lendId);
        }

        public EditLend GetDetails(long id)
        {
            return _lendContext.Lending.Select(x => new EditLend
            {
                Id = x.Id,
                BookId = x.BookId,
                Borrower = x.Borrower,
                MembershipCode = x.MembershipCode,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<LendOperationViewModel> GetOperationLog(long lendId)
        {
            var lend = _lendContext.Lending.FirstOrDefault(x => x.Id == lendId);
            return lend.Operations.Select(x => new LendOperationViewModel
            {
                Id = x.Id,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                Operator = "مدیر سیستم",
                OperatorId = x.OrderId,
                OrderId = x.OrderId
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<LendViewModel> Search(LendSearchModel searchModel)
        {
            var books = _libraryContext.Books.Select(x => new { x.Id, x.Name }).ToList();
            var query = _lendContext.Lending.Select(x => new LendViewModel
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                Borrower = x.Borrower,
                MembershipCode = x.MembershipCode,
                ReturnTime = x.ReturnTime,
                Lended = x.Lended,
                BookId = x.BookId,
                CurrentCount = x.CalculateCurrentCount(),
                CreationDate = x.CreationDate.ToFarsi()
            });
            if (searchModel.BookId > 0)
                query = query.Where(x => x.BookId == searchModel.BookId);

            if (searchModel.Lended)
                query = query.Where(x => !x.Lended);

            var lend = query.OrderByDescending(x => x.Id).ToList();

            lend.ForEach(item =>
                item.Book = books.FirstOrDefault(x => x.Id == item.BookId)?.Name);

            return lend;
        }
    }
}
