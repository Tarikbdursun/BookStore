using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
             using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
             {   
                context.Authors.AddRange
                (
                    new Author 
                    {
                        Name = "Eric",
                        LastName = "Ries",
                        Birthdate = new DateTime(1978,9,22)
                    },
                    new Author 
                    {
                        Name = "Charlotte Perkins",
                        LastName = "Gilman",
                        Birthdate = new DateTime(1860,7,3)
                    },
                    new Author 
                    {
                        Name = "Frank",
                        LastName = "Herbert",
                        Birthdate = new DateTime(1920,2,11)
                    }
                );
                
                context.Genres.AddRange
                (
                    new Genre
                    {
                        Name="Personal Growth"
                    },
                    new Genre
                    {
                        Name="Science Fiction"
                    },
                    new Genre
                    {
                        Name="Romance"
                    }   
                );

                context.Books.AddRange
                (

                    new Book
                    {
                        //Id = 1,
                        Title = "Lean StartUp",
                        GenreId = 1,//personal Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2,//Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2,//Science Fiction
                        PageCount = 540,
                        PublishDate = new DateTime(2001, 12, 23)
                    }
                );
                  
                //context.SaveChanges();
            }
        }
    }
}