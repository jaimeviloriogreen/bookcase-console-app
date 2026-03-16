namespace Bookcase.Screens;

class MainScreen(BookService bookService) {
  private bool running = true;
  private readonly BookService _bookService = bookService;
  private readonly (string Text, int Value)[] choices = [
    ("1. Mostrar los libros", 1),
    ("2. Agregar un libro", 2),
    ("3. Eliminar un libro", 3),
    ("4. Actualizar un libro", 4),
    ("5. Salir", 0)
  ];
  public void Show() {
    while (running) {

      // Menu selection
      var selection = new SelectionPrompt<(string Text, int Value)>()
        .Title("Bienvenido a la App")
        .AddChoices(choices)
        .UseConverter(c => $"{c.Text}");

      // Get user choice
      var choiced = AnsiConsole.Prompt(selection);

      // Choose an option from the menu
      switch (choiced.Value) {
        case 1:
          var table = new Table();

          table.AddColumn("Id");
          table.AddColumn("Título");
          table.AddColumn("Fecha");
          table.AddColumn("Isbn");

          foreach (var book in _bookService.SelectAll()) {
            table.AddRow(
              $"{book.Id}",
              $"{book.Title}",
              $"{book.Year}",
              $"{book.Isbn}"
            );
          }
          AnsiConsole.Write(table);
          break;
        case 2:
          AnsiConsole.Clear();
          var name = AnsiConsole.Ask<string>("Nombre del libro: ");
          var year = AnsiConsole.Ask<string>("Año de publicación: ");
          var isbn = AnsiConsole.Ask<string>("Código del libro: ");

          _bookService.Insert(name, year, isbn);

          AnsiConsole.Clear();

          break;
        case 3:
          AnsiConsole.Clear();
          var id = AnsiConsole.Ask<int>("Inserte el id del libro a eliminar: ");
          _bookService.Delete(id);
          AnsiConsole.Clear();
          break;
        case 4:
          AnsiConsole.Clear();
          var updateId = AnsiConsole.Ask<int>("Inserte el id del libro a actualizar: ");
          var updateName = AnsiConsole.Ask<string>("Nombre del libro: ");
          var updateYear = AnsiConsole.Ask<string>("Año de publicación: ");
          var updateIsbn = AnsiConsole.Ask<string>("Código del libro: ");

          _bookService.Update(updateName, updateYear, updateIsbn, updateId);

          AnsiConsole.Clear();
          break;
        case 0:
          AnsiConsole.Clear();
          Console.WriteLine("Saliendo de la app");
          running = false;
          break;
      }
    }
  }
}