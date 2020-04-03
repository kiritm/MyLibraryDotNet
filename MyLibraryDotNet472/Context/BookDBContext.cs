using MyLibraryDotNet472.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyLibraryDotNet472.Context
{
    public class BookDBContext : DbContext
    {
            public BookDBContext():base("BookDBContext")
            {                
            }

            public DbSet<BFormat> BFormats { get; set; }
            public DbSet<BCategory> BCategories {get;set;}
            public DbSet<Book> Books { get; set; }


            protected override void OnModelCreating(DbModelBuilder modelBuilder) 
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                modelBuilder.Entity<Book>()
                    .HasRequired<BFormat>(s => s.BFormat)
                    .WithMany(bf => bf.Books)
                    .HasForeignKey<int>(s => s.BFormatId);

                modelBuilder.Entity<Book>()
                    .HasRequired<BCategory>(bc => bc.BCategory)
                    .WithMany(bb => bb.Books)
                    .HasForeignKey<int>(bc => bc.BCategoryId);
            }
    }
     
}