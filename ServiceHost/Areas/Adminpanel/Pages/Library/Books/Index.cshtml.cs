using Library.Application.Contracts.Book;
using Library.Application.Contracts.BookCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Adminpanel.Pages.Library.Books
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public BookSearchModel SearchModel;
        public List<BookViewModel> Books;
        public SelectList BookCategories;

        private readonly IBookApplication _bookApplication;
        private readonly IBookCategoryApplication _bookCategoryApplication;

        public IndexModel(IBookApplication bookApplication, IBookCategoryApplication bookCategoryApplication)
        {
            _bookApplication = bookApplication;
            _bookCategoryApplication = bookCategoryApplication;
        }

        public void OnGet(BookSearchModel searchModel)
        {
            BookCategories = new SelectList(_bookCategoryApplication.GetBookCategories(), "Id", "Name");
            Books = _bookApplication.Search(searchModel);
        }
        public PartialViewResult OnGetCreate()
        {
            var command = new CreateBook
            {
                Categories = _bookCategoryApplication.GetBookCategories()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateBook command)
        {
            var result = _bookApplication.Create(command);
            return new JsonResult(result);
        }

        public PartialViewResult OnGetEdit(long id)
        {
            var book = _bookApplication.GetDetails(id);
            book.Categories = _bookCategoryApplication.GetBookCategories();
            return Partial("Edit", book);
        }
        public JsonResult OnPostEdit(EditBook command)
        {
            var result = _bookApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}