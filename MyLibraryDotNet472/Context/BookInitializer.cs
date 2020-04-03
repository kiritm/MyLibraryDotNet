using MyLibraryDotNet472.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MyLibraryDotNet472.Context
{
    public class BookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookDBContext>
    {
        protected override void Seed(BookDBContext context)
        {
            // base.Seed(context);
            var bFormats = new List<BFormat>
           {
                new BFormat() { FormatType = "Audio CD" },
                new BFormat() { FormatType = "Audiobook" },
                new BFormat() { FormatType = "Binding" },
                new BFormat() { FormatType = "Ebook" },
                new BFormat() { FormatType = "Hardcover" },
                new BFormat() { FormatType = "Journal" },
                new BFormat() { FormatType = "Large Print" },
                new BFormat() { FormatType = "Magazine" },
                new BFormat() { FormatType = "Newspaper" },
                new BFormat() { FormatType = "Paperback" }
           };
            bFormats.ForEach(b => context.BFormats.Add(b));
            context.SaveChanges();

            var bCategories = new List<BCategory> 
            {
				new BCategory() { BCategoryType = "Art & Photography" },
				 new BCategory() { BCategoryType = "Biographies & Memories" },
				 new BCategory() { BCategoryType = "Business & Money" },
				 new BCategory() { BCategoryType = "Business & Investing" },
				 new BCategory() { BCategoryType = "Children's Books" },
				 new BCategory() { BCategoryType = "Christian Books & Bibles" },
 				 new BCategory() { BCategoryType = "Comedy" },
				 new BCategory() { BCategoryType = "Comics & Graphic Novels" },
				 new BCategory() { BCategoryType = "Computers & Technology" },
				 new BCategory() { BCategoryType = "Cookbooks, Food & Wine" },
				 new BCategory() { BCategoryType = "Crafts, Hobbies & Home" },
				 new BCategory() { BCategoryType = "Education & Teaching" },
				 new BCategory() { BCategoryType = "Engineering & Transportation" },
				 new BCategory() { BCategoryType = "Health, Fitness & Dieting" },
				 new BCategory() { BCategoryType = "History" },
				 new BCategory() { BCategoryType = "Humor & Entertainment" },
				 new BCategory() { BCategoryType = "Law" },
				 new BCategory() { BCategoryType = "Lesbian, Gay, Bisexual & Transgender Books" },
				 new BCategory() { BCategoryType = "Literature & Fiction" },
				 new BCategory() { BCategoryType = "Medical Books" },
				 new BCategory() { BCategoryType = "Mystery & Suspense" },
				 new BCategory() { BCategoryType = "Parenting & Relationships" },
				 new BCategory() { BCategoryType = "Politics & Social Sciences" },
				 new BCategory() { BCategoryType = "Reference" },
				 new BCategory() { BCategoryType = "Religion & Spirituality" },
				 new BCategory() { BCategoryType = "Romance" },
				 new BCategory() { BCategoryType = "Sci-Fi & Fantasy" },
				 new BCategory() { BCategoryType = "Science & Math" },
				 new BCategory() { BCategoryType = "Science Fiction & Fantasy" },
				 new BCategory() { BCategoryType = "Self-Help" },
				 new BCategory() { BCategoryType = "Sports & Outdoors" },
				 new BCategory() { BCategoryType = "Teans and Young Adult" },
				 new BCategory() { BCategoryType = "Test Preparation" },
				 new BCategory() { BCategoryType = "Travel" }
			};
			bCategories.ForEach(b => context.BCategories.Add(b));
			context.SaveChanges();

			var books = new List<Book>
			{
				new Book()
				{
					BookTitle = "When Harry Met Sally",
					BookEdition = "First",
					BookAuthor1 = "Nora Ephron",
					BookAuthor2 = "",
					// BookCategory = "Romantic Comedy",
					BCategoryId = context.BCategories.FirstOrDefault(b=>b.BCategoryType== "Romance").Id,
					//26,
					BookPurchasePrice = 14.99M,
					BookPublisher = "Bloomsbury Publishing PLC",
					BookISBN = "9780747575474",
					BookStatus = "Available",
					BookStorage_Code = "WH123",
					ReleaseDate = DateTime.Now,
					// BookFormat = "Paperback"
					BFormatId =  context.BFormats.FirstOrDefault(b=>b.FormatType =="Paperback").Id //;//.Add// 10,				
				},
					new Book()
					{
						BookTitle = "R. Buckminster Fuller: Pattern-Thinking",
						BookEdition = "First",
						BookAuthor1 = "R. Buckminster Fuller",
						BookAuthor2 = "",
						//  BookCategory = "Art & Photography",
					    BCategoryId = context.BCategories.FirstOrDefault(b=>b.BCategoryType== "Art & Photography").Id,
						//BCategoryId = 1,
						BookPurchasePrice = 27.49M,
						BookPublisher = "Lars Müller Publishers",
						BookISBN = "978-3037786093",
						BookStatus = "Available",
						BookStorage_Code = "AP123",
						ReleaseDate = DateTime.Now,
						//BookFormat = "Paperback"
						//BFormatId = 10
						BFormatId =  context.BFormats.FirstOrDefault(b=>b.FormatType =="Paperback").Id
					},

					new Book()
					{
						BookTitle = "You Are Not Alone",
						BookEdition = "First",
						BookAuthor1 = " Greer Hendricks",
						BookAuthor2 = "Sarah Pekkanen",
						//   BookCategory = "Mystery & Suspense",
						//BCategoryId = 21,
						BCategoryId = context.BCategories.FirstOrDefault(b=>b.BCategoryType== "Mystery & Suspense").Id,
						BookPurchasePrice = 16.79M,
						BookPublisher = "St. Martin's Press",
						BookISBN = "9781250202031",
						BookStatus = "Available",
						BookStorage_Code = "YN123",
						ReleaseDate = DateTime.Now,
						// BookFormat = "Hardcover"
						//BFormatId = 5
						BFormatId =  context.BFormats.FirstOrDefault(b=>b.FormatType =="Hardcover").Id
					}
			};

			books.ForEach(b => context.Books.Add(b));
			context.SaveChanges();
        }
    }
}