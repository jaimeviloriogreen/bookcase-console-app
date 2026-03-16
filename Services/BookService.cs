class BookService(BookRepository bookRepository) {
  private readonly BookRepository _bookRepository = bookRepository;

  public List<BoookModel> SelectAll() {
    return _bookRepository.SelectAll();
  }
  public int Delete(int id) {
    return _bookRepository.Delete(id);
  }
  public int Insert(string title, string year, string isbn) {
    return _bookRepository.Insert(title, year, isbn);
  }

  public int Update(string title, string year, string isbn, int id) {
    return _bookRepository.Update(title, year, isbn, id);
  }
}