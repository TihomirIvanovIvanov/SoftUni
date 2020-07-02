namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using BookShop.Models.Enums;
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            //var input = Console.ReadLine();

            using (var db = new BookShopContext())
            {
                IncreasePrices(db);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            int enumValue = -1;

            switch (command.ToLower())
            {
                case "minor":
                    enumValue = 0;
                    break;
                case "teen":
                    enumValue = 1;
                    break;
                case "adult":
                    enumValue = 2;
                    break;
            }

            var books = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)enumValue)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title)
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(new[] { "\t", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var books = context.Books
                .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var checkDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < checkDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .OrderBy(a => a)
                .ToList();

            var result = String.Join(Environment.NewLine, authors);

            return result.TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var pattern = $"^{input}.*";

            var books = context.Books
                .Where(b => Regex.IsMatch(b.Author.LastName, pattern, RegexOptions.IgnoreCase))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            var result = String.Join(Environment.NewLine, books);

            return result.TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var booksCount = context.Books
                .Where(b => b.Title.Count() > lengthCheck)
                .ToList();

            return booksCount.Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copies = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Select(c => c.Copies).Sum()
                })
                .OrderByDescending(a => a.Copies)
                .Select(a => $"{a.Name} - {a.Copies}")
                .ToList();

            var result = String.Join(Environment.NewLine, copies);

            return result.TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profit = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                })
                .OrderBy(c => c.Name)
                .OrderByDescending(c => c.Profit)
                .Select(c => $"{c.Name} ${c.Profit:F2}")
                .ToList();

            var result = String.Join(Environment.NewLine, profit);

            return result.TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(b => b.Book)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                })
                .ToList();

            var builder = new StringBuilder();

            foreach (var c in categories)
            {
                builder.AppendLine($"--{c.Name}");
                foreach (var b in c.Books)
                {
                    var date = b.ReleaseDate == null ? 
                               "N/A" : 
                               b.ReleaseDate.Value.Year.ToString();

                    builder.AppendLine($"{b.Title} ({date})");
                }
            }

            return builder.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(b => b.Price += 5);

            context.SaveChanges();
        }
    }
}
