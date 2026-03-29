using Bookcase.Models;
using Bookcase.Database;

class BookRepository(AppDbContext context) {
  private readonly AppDbContext _context = context;

  public List<BookModel> SelectAll() {
    return _context.Books.ToList();
  }

  public int Delete(int id) {
    var book = _context.Books.Find(id);

    if (book is null) return 0;
    _context.Books.Remove(book);
    return _context.SaveChanges();
  }

  // public BookModel? FindOne(int id) {
  //   var book = _context.Books.Find(id);
  //   if (book is null) return null;

  //   return book;
  // }

  public int Insert(string title, string year, string isbn) {
    var book = new BookModel { Title = title, Year = year, Isbn = isbn };
    _context.Books.Add(book);
    return _context.SaveChanges();
  }

  public int Update(string title, string year, string isbn, int id) {
    var book = _context.Books.Find(id);

    // Es porque el libro existe
    if (book is null) return 0;

    book.Title = title;
    book.Year = year;
    book.Isbn = isbn;

    return _context.SaveChanges();
  }
}