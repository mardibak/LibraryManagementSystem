using Library.Application;
using Library.Application.Contracts.Book;
using Library.Application.Contracts.BookCategory;
using Library.Domain.BookAgg;
using Library.Domain.BookCategoryAgg;
using Library.Infrastructure.EFCore;
using Library.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Configuration
{
    public class LibraryBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IBookCategoryApplication, BookCategoryApplication>();
            services.AddTransient<IBookCategoryRepository, BookCategoryRepository>();

            services.AddTransient<IBookApplication, BookApplication>();
            services.AddTransient<IBookRepository, BookRepository>();

            services.AddDbContext<LibraryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
