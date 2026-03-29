global using Spectre.Console;
// using Bookcase.Database;
using Bookcase.Screens;
using Bookcase.Database;

class Program {
  public static void Main(string[] args) {
    // Database database = new("bookcase.db");
    AppDbContext appDbContext = new("bookcase.db");

    BookRepository bookRepository = new(appDbContext);
    BookService bookService = new(bookRepository);

    MainScreen mainScreen = new(bookService);
    mainScreen.Show();
  }
}