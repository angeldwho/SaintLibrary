using Microsoft.EntityFrameworkCore;
using MyLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.DAL.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
