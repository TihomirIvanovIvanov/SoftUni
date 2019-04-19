namespace BookShop
{
    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text;

    public class StartUp
    {
        static void Main()
        {
            var input = Console.ReadLine();

            using (var context = new BookShopContext())
            {
                Console.WriteLine(GetBookTitlesContaining(context, input));
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

            var bookByAgeRes = context.Books
                .Where(b => b.AgeRestriction == (AgeRestriction)enumValue)
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            var result = String.Join(Environment.NewLine, bookByAgeRes);

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBook = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToArray();

            var result = String.Join(Environment.NewLine, goldenBook);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var bookByPrice = context.Books
                .OrderByDescending(p => p.Price)
                .Where(b => b.Price > 40)
                .Select(b => $"{b.Title} - ${b.Price:F2}")
                .ToArray();

            var result = String.Join(Environment.NewLine, bookByPrice);

            return result;
        }

        public static string GetBooksNotRealeasedIn(BookShopContext context, int year)
        {
            var booksByYear = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            var result = String.Join(Environment.NewLine, booksByYear);

            return result;
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(new[] { "\t", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            var booksByCat = context.Books
                .Where(b => b.BookCategories.Any
                (c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            var result = String.Join(Environment.NewLine, booksByCat);

            return result;
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime checkDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var books = context.Books
                .Where(b => b.ReleaseDate < checkDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToArray();

            var result = String.Join(Environment.NewLine, books);

            return result;
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var pattern = $"{input.ToLower()}";

            var books = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .Where(a => a.FirstName.ToLower().EndsWith(pattern))
                .ToArray();

            var result = String.Join(Environment.NewLine, books
                .Select(a => $"{a.FirstName} {a.LastName}").OrderBy(a => a));

            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var pattern = $@"^.*{input}.*";

            var booksTitle = context.Books
                .Where(b => Regex.IsMatch(b.Title, pattern, RegexOptions.IgnoreCase))
                .OrderBy(b => b.Title)
                .Select(b => b.Title).ToArray();

            var result = String.Join(Environment.NewLine, booksTitle);

            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var pattern = $"^{input}.*";

            var books = context.Books
                .Where(b => Regex.IsMatch(b.Author.LastName, pattern, RegexOptions.IgnoreCase))
                .OrderBy(b => b.BookId).Select(a => new
                {
                    a.Title,
                    Name = $"{a.Author.FirstName} {a.Author.LastName}"
                }).ToArray();

            var result = String.Join(Environment.NewLine, books.Select(a => $"{a.Title} ({a.Name})"));

            return result.Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var titles = context.Books
                .Where(t => t.Title.Count() > lengthCheck)
                .ToArray();

            int result = titles.Count();

            return result;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var totalCopies = context.Authors
                .Select(a => new
                {
                    Name = $"{a.FirstName} {a.LastName}",
                    Copies = a.Books.Select(c => c.Copies).Sum()
                })
                .OrderByDescending(c => c.Copies)
                .ToArray();

            var authorsName = totalCopies.Select(a => $"{a.Name} - {a.Copies}").ToArray();

            var result = String.Join(Environment.NewLine, authorsName);

            return result;
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var totalMoney = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(e => e.Book.Copies * e.Book.Price)
                })
                .OrderBy(c => c.Name)
                .OrderByDescending(p => p.Profit)
                .ToArray();

            var profit = totalMoney.Select(c => $"{c.Name} ${c.Profit}").ToArray();

            var result = String.Join(Environment.NewLine, profit);

            return result;
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    c.Name,
                    Books = c.CategoryBooks.Select(cb => cb.Book)
                    .OrderByDescending(b => b.ReleaseDate)
                    .Take(3)
                })
                .ToArray();

            var builder = new StringBuilder();

            foreach (var c in categories)
            {
                builder.AppendLine($"--{c.Name}");
                foreach (var b in c.Books)
                {
                    string date = null;

                    if (b.ReleaseDate == null)
                    {
                        date = "N/A";
                    }
                    else
                    {
                        date = b.ReleaseDate.Value.Year.ToString();
                    }

                    builder.AppendLine($"{b.Title} ({date})");
                }
            }

            return builder.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var increase = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var money in increase)
            {
                money.Price += 5m;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return books.Count();
        }
    }
}
