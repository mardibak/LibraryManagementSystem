using Library.Application.Contracts.BookCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Adminpanel.Pages.Library.Categories
{
    public class IndexModel : PageModel
    {
        public BookCategorySearchModel SearchModel;
        public List<BookCategoryViewModel> BookCategories;
        private readonly IBookCategoryApplication _bookCategoryApplication;

        public IndexModel(IBookCategoryApplication bookCategoryApplication)
        {
            _bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet(BookCategorySearchModel searchModel)
        {
            BookCategories = _bookCategoryApplication.Search(searchModel);
        }
        public PartialViewResult OnGetCreate()
        {
            return Partial("./Create", new CreateBookCategory());
        }

        public JsonResult OnPostCreate(CreateBookCategory command)
        {
            var result = _bookCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var bookCategory = _bookCategoryApplication.GetDetails(id);
            return Partial("Edit", bookCategory);
        }
        public IActionResult OnPostEdit(EditBookCategory command)
        {
            var result = _bookCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}