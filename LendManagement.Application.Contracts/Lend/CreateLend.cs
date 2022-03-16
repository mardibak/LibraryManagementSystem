using AppFramework.Application;
using Library.Application.Contracts.Book;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LendManagement.Application.Contract.Lend
{
    public class CreateLend
    {
        [Range(1, 100000, ErrorMessage = ValidationMessages.IsRequired)]
        public long BookId { get; set; }
        public string Borrower { get; set; }
        public string MembershipCode { get; set; }
        public string ReturnTime { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }
        public List<BookViewModel> Books { get; set; }
    }
}
