using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "books.json";
        List<Book> books = LoadBooksFromJson(filePath);
        if (books != null)
        {
            // Filter books starting with "The"
            List<Book> filteredBooksByTitle = FilterBooksStartingWithThe(books);

            // Filter books by authors with a 't' in their name
            List<Book> filteredBooksByAuthorWithT = FilterBooksByAuthorWithT(books);

            // Filter books written after 1992
            List<Book> filteredBooksAfter1992 = FilterBooksWrittenAfter1992(books);

            // Filter books written before 2004
            List<Book> filteredBooksBefore2004 = FilterBooksWrittenBefore2004(books);

            // Display filtered books by title
            Console.WriteLine("Books starting with 'The':");
            DisplayBooks(filteredBooksByTitle);

            // Display filtered books by author with 't' in their name
            Console.WriteLine("\nBooks written by authors with 't' in their name:");
            DisplayBooks(filteredBooksByAuthorWithT);

            // Count and display the number of books written after 1992
            Console.WriteLine($"\nNumber of books written after 1992: {filteredBooksAfter1992.Count}");

            // Count and display the number of books written before 2004
            Console.WriteLine($"\nNumber of books written before 2004: {filteredBooksBefore2004.Count}");

            // List ISBN numbers of all books for a given author
            ListISBNByAuthor(books, "Terry Pratchett");

            // List books alphabetically ascending
            List<Book> booksAlphabeticallyAscending = books.OrderBy(book => book.title).ToList();
            Console.WriteLine("\nBooks listed alphabetically ascending:");
            DisplayBooks(booksAlphabeticallyAscending);

            // List books alphabetically descending
            List<Book> booksAlphabeticallyDescending = books.OrderByDescending(book => book.title).ToList();
            Console.WriteLine("\nBooks listed alphabetically descending:");
            DisplayBooks(booksAlphabeticallyDescending);

            // List books chronologically ascending
            List<Book> booksChronologicallyAscending = books.OrderBy(book => book.publication_year).ToList();
            Console.WriteLine("\nBooks listed chronologically ascending:");
            DisplayBooks(booksChronologicallyAscending);

            // List books chronologically descending 
            List<Book> booksChronologicallyDescending = books.OrderByDescending(book => book.publication_year).ToList();
            Console.WriteLine("\nBooks listed chronologically descending:");
            DisplayBooks(booksChronologicallyDescending);

            // List books grouped by author last name
            var booksGroupedByLastName = books.GroupBy(book => book.author.Split(' ').Last()).ToList();
            Console.WriteLine("\nBooks grouped by author last name:");
            foreach (var group in booksGroupedByLastName)
            {
                Console.WriteLine($"Author Last Name: {group.Key}");
                foreach (var book in group)
                {
                    Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
                }
            }

            // List books grouped by author first name
            var booksGroupedByFirstName = books.GroupBy(book => book.author.Split(' ').First()).ToList();
            Console.WriteLine("\nBooks grouped by author first name:");
            foreach (var group in booksGroupedByFirstName)
            {
                Console.WriteLine($"Author First Name: {group.Key}");
                foreach (var book in group)
                {
                    Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
                }
            }
        }
        else
        {
            Console.WriteLine("Failed to load books from JSON.");
        }
    }

    static List<Book> LoadBooksFromJson(string filePath)
    {
        try
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                var json = file.ReadToEnd();
                return JsonSerializer.Deserialize<List<Book>>(json);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading books: {ex.Message}");
            return null;
        }
    }

    static List<Book> FilterBooksStartingWithThe(List<Book> books)
    {
        return books.Where(book => book.title != null && book.title.StartsWith("The", StringComparison.OrdinalIgnoreCase)).ToList();
    }

    static List<Book> FilterBooksByAuthorWithT(List<Book> books)
    {
        return books.Where(book => book.author != null && book.author.IndexOf('t', StringComparison.OrdinalIgnoreCase) != -1).ToList();
    }

    static List<Book> FilterBooksWrittenAfter1992(List<Book> books)
    {
        return books.Where(book => book.publication_year > 1992).ToList();
    }

    static List<Book> FilterBooksWrittenBefore2004(List<Book> books)
    {
        return books.Where(book => book.publication_year < 2004).ToList();
    }

    static void ListISBNByAuthor(List<Book> books, string authorName)
    {
        var booksByAuthor = books.Where(book => book.author.Equals(authorName, StringComparison.OrdinalIgnoreCase)).ToList();
        if (booksByAuthor.Any())
        {
            Console.WriteLine($"\nISBN numbers of books by {authorName}:");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine($"ISBN: {book.isbn}");
            }
        }
        else
        {
            Console.WriteLine($"\nNo books found for author {authorName}.");
        }
    }

    static void DisplayBooks(List<Book> books)
    {
        foreach (var book in books)
        {
            Console.WriteLine($"Title: {book.title}, Author: {book.author}, Publication Year: {book.publication_year}, ISBN: {book.isbn}");
        }
    }
}

class Book
{
    public string title { get; set; }
    public int publication_year { get; set; }
    public string author { get; set; }
    public string isbn { get; set; }
}
