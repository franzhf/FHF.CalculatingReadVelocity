using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackerActivity.Infrastructure.Repositories;
using TrackerActivity.Domain.Activity;
using TrackerActivity.Domain.ReadingActivity;
using System;

namespace ActivityManager.Infrastructure.UnitTesting
{
    [TestClass]
    public class BookRepositoryTest
    {
        [TestMethod]
        public void Add_CheckNumberofElements()
        {
            BookRepository bookRepository = new BookRepository();
            Book b1 = new Book
            {
                ISBN = "1232132",
                Title = "Clean Code"
            };

            bookRepository = new BookRepository();
            Book b2 = new Book
            {
                ISBN = "3232",
                Title = "Refactoring"
            };

            bookRepository.Add(b1);
            bookRepository.Add(b2);
            Assert.AreEqual(2, bookRepository.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Book  is not valid!!!")]

        public void ThrowException_WhenBookPreconditionDontFulfill()
        {
            BookRepository bookRepository = new BookRepository();
            Book b2 = new Book
            {
                ISBN = "3232",
            };
            bookRepository.Add(b2);
        }
    }
}
