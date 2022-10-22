/*using ContosoUniversity.Models;*/
using System;
using System.Linq;
using BooksAPI.Models;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BookContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Book.Any())
            {
                return;   // DB has been seeded
            }

            var Books = new Book[]
            {
                new Book{Name="Chemistry",publisher="Kim Dong", Category="SGK", author=""},
                new Book{Name="Math",publisher="Kim Dong", Category="SGK", author=""},
                new Book{Name="Conan",publisher="Shogakukan", Category="Truyen", author="Aoyama Gōshō"},
                new Book{Name="Doraemon",publisher="Kim Dong", Category="Truyen", author=""},
                new Book{Name="Dac nhan tam",publisher="", Category="Sách tự lực", author="Dale Carnegie"},
            };
            foreach (Book c in Books)
            {
                context.Book.Add(c);
            }
            context.SaveChanges();
        }
    }
}