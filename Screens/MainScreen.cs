namespace Bookcase.Screens;

class MainScreen {
  private bool running = true;
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
          Console.WriteLine("Mostrando todos los libros");
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