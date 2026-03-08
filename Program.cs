global using Spectre.Console;
using Bookcase.Screens;

class Program
{
  public static void Main(string[] args)
  {
    // El arranque de la aplicación vive
    MainScreen mainScreen = new();
    mainScreen.Show();
  }
}