global using Spectre.Console;
using Bookcase.Database;
using Bookcase.Screens;

class Program {
  public static void Main(string[] args) {
    Database database = new("bookcase.db");
    BookRepository bookRepository = new(database);
    BookService bookService = new(bookRepository);

    MainScreen mainScreen = new(bookService);
    mainScreen.Show();
  }
}