using AppFramework.Application;
using System.Collections.Generic;

namespace LendManagement.Application.Contract.Lend
{
    public interface ILendApplication
    {
        OperationResult Create(CreateLend command);
        OperationResult Edit(EditLend command);
        OperationResult Increase(IncreaseLend command);
        OperationResult Reduce(ReduceLend command);
        OperationResult Reduce(List<ReduceLend> command);
        EditLend GetDetails(long id);
        List<LendViewModel> Search(LendSearchModel searchModel);
        List<LendOperationViewModel> GetOperationLog(long inventoryId);
    }
}
