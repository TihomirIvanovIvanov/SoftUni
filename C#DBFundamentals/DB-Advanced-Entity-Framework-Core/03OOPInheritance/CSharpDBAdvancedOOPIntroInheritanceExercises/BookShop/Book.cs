using System;

public class Book
{
    private string title;
    private string author;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }

    public string Title
    {
        get { return this.title; }
        protected set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            this.title = value;
        }
    }
    public string Author
    {
        get { return this.author; }
        protected set
        {
            string[] args = value.Split();
            if (args.Length == 2)
            {
                char ch = args[1][0];
                if (Char.IsDigit(ch))
                {
                    throw new ArgumentException("Author not valid!");
                }
            }
            this.author = value;
        }
    }
    public decimal Price
    {
        get { return this.price; }
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            this.price = value;
        }
    }
    public override string ToString()
    {
        return $"Type: {this.GetType().Name}" + Environment.NewLine +
            $"Title: {this.Title}" + Environment.NewLine +
            $"Author: {this.Author}" + Environment.NewLine +
            $"Price: {this.Price:f2}" + Environment.NewLine;
    }

}