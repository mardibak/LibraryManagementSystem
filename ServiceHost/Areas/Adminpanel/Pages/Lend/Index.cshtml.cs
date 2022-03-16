using LendManagement.Application.Contract.Lend;
using Library.Application.Contracts.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Adminpanel.Pages.Lend
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public LendSearchModel SearchModel;
        public List<LendViewModel> Lend;
        public SelectList Books;

        private readonly IBookApplication _bookApplication;
        private readonly ILendApplication _lendApplication;
        public IndexModel(IBookApplication bookApplication, ILendApplication lendApplication)
        {
            _bookApplication = bookApplication;
            _lendApplication = lendApplication;
        }

        public void OnGet(LendSearchModel searchModel)
        {
            Books = new SelectList(_bookApplication.GetBooks(), "Id", "Name");
            Lend = _lendApplication.Search(searchModel);
        }
        public PartialViewResult OnGetCreate()
        {
            var command = new CreateLend
            {
                Books = _bookApplication.GetBooks()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateLend command)
        {
            var result = _lendApplication.Create(command);
            return new JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var lend = _lendApplication.GetDetails(id);
            lend.Books = _bookApplication.GetBooks();
            return Partial("Edit", lend);
        }
        public JsonResult OnPostEdit(EditLend command)
        {
            var result = _lendApplication.Edit(command);
            return new JsonResult(result);
        }
        public PartialViewResult OnGetIncrease(long id)
        {
            var command = new IncreaseLend()
            {
                LendId = id
            };
            return Partial("Increase", command);
        }
        public JsonResult OnPostIncrease(IncreaseLend command)
        {
            var result = _lendApplication.Increase(command);
            return new JsonResult(result);
        }
        public PartialViewResult OnGetReduce(long id)
        {
            var command = new ReduceLend()
            {
                LendId = id
            };
            return Partial("Reduce", command);
        }
        public JsonResult OnPostReduce(ReduceLend command)
        {
            var result = _lendApplication.Reduce(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLog(long id)
        {
            var log = _lendApplication.GetOperationLog(id);
            return Partial("OperationLog", log);
        }
    }
}