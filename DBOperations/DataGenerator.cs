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
                InitializeGenres(context);
                InitializeAuthors(context);
                InitializeBooks(context);
                
                context.SaveChanges();
            }
        }

        private static void InitializeBooks(BookStoreDbContext context)
        {
            if(context.Books.Any())
                return;
            
            context.Books.AddRange
            (
                new Book
                {
                    //Id = 1,
                    Title = "Lean StartUp",
                    GenreId = 1,//personal Growth
                    AuthorId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)
                },
                new Book
                {
                    //Id = 2,
                    Title = "Herland",
                    GenreId = 2,//Science Fiction
                    AuthorId = 2,
                    PageCount = 250,
                    PublishDate = new DateTime(2010, 05, 23)
                },
                new Book
                {
                    //Id = 3,
                    Title = "Dune",
                    GenreId = 2,//Science Fiction
                    AuthorId = 3,
                    PageCount = 540,
                    PublishDate = new DateTime(2001, 12, 23)
                }
            );
        }

        private static void InitializeGenres(BookStoreDbContext context)
        {
            if(context.Genres.Any())
                return;

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
        }

        private static void InitializeAuthors(BookStoreDbContext context)
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
        }
    }
}