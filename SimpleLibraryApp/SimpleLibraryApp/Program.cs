using System;
using System.Collections.Generic;
using System.Linq;

// Custom attribute: user defined behaviour to caterogrize the types of items
[AttributeUsage(AttributeTargets.Class)]
public class LibraryItemAttribute : Attribute
{
    public string Category { get; set; }
    public LibraryItemAttribute(string category)
    {
        Category = category;
    }
}

// Base class for library items
[LibraryItem("General")]
public class LibraryItem
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }

    // Operator overloading for comparing library items
    public static bool operator ==(LibraryItem a, LibraryItem b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;
        return a.Title == b.Title && a.Author == b.Author && a.Year == b.Year;
    }

    public static bool operator !=(LibraryItem a, LibraryItem b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is LibraryItem item)
            return this == item;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Title, Author, Year);
    }
}

[LibraryItem("Book")]
public class Book : LibraryItem
{
    public int Pages { get; set; }
}

[LibraryItem("Magazine")]
public class Magazine : LibraryItem
{
    public int Issue { get; set; }
}

public class Library
{
    private List<LibraryItem> items = new List<LibraryItem>();

    public void AddItem(LibraryItem item)
    {
        items.Add(item);
    }

    public void PrintCatalog()
    {
        Console.WriteLine("Library Catalog:");
        foreach (var item in items)
        {
            var type = item.GetType();
            var attribute = (LibraryItemAttribute)Attribute.GetCustomAttribute(type, typeof(LibraryItemAttribute));
            Console.WriteLine($"{attribute.Category}: {item.Title} by {item.Author} ({item.Year})");
        }
    }

    public void QueryItems()
    {
        // Using LINQ to query items
        var query = from item in items
                    where item.Year > 2000
                    orderby item.Title
                    select new { item.Title, item.Author };

        Console.WriteLine("\nItems published after 2000:");
        foreach (var result in query)
        {
            Console.WriteLine($"{result.Title} by {result.Author}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        // Using dynamic type
        dynamic newBook = new Book
        {
            Title = "C# in Depth",
            Author = "Jon Skeet",
            Year = 2019,
            Pages = 528
        };
        library.AddItem(newBook);

        // Using anonymous type
        var anonymousBook = new { Title = "Anonymous Book", Author = "Unknown", Year = 2022 };
        library.AddItem(new Book { Title = anonymousBook.Title, Author = anonymousBook.Author, Year = anonymousBook.Year });

        library.AddItem(new Magazine { Title = "C# Monthly", Author = "Various", Year = 2023, Issue = 1 });

        library.PrintCatalog();
        library.QueryItems();
    }
}