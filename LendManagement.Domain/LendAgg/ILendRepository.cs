using AppFramework.Domain;
using LendManagement.Application.Contract.Lend;
using System.Collections.Generic;

namespace LendManagement.Domain.LendAgg
{
    public interface ILendRepository : IRepository<long, Lend>
    {
        EditLend GetDetails(long id);
        Lend GetBy(long bookId);
        List<LendViewModel> Search(LendSearchModel searchModel);
        List<LendOperationViewModel> GetOperationLog(long lendId);
    }
}
