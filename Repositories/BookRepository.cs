using Bookcase.Database;

class BookRepository(Database db) {
  private readonly Database _db = db;

  public List<BoookModel> SelectAll() {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      SELECT * FROM book;
    ";

    using var reader = command.ExecuteReader();

    List<BoookModel> books = [];

    while (reader.Read()) {
      books.Add(
        new BoookModel() {
          Id = reader.GetInt32(0),
          Title = reader.GetString(1),
          Year = reader.GetString(2),
          Isbn = reader.GetString(3)
        }
      );
    }

    return books;

  }

  public int Delete(int id) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      DELETE FROM book WHERE id_book = @id;
    ";
    command.Parameters.AddWithValue("@id", id);

    int rowDeleted = command.ExecuteNonQuery();

    return rowDeleted;
  }

  public int Insert(string title, string year, string isbn) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      INSERT INTO
        book (title, year, isbn)
      VALUES (@title,@year,@isbn);
    ";

    command.Parameters.AddWithValue("@title", title);
    command.Parameters.AddWithValue("@year", year);
    command.Parameters.AddWithValue("@isbn", isbn);

    int rowInserted = command.ExecuteNonQuery();

    return rowInserted;
  }

  public int Update(string title, string year, string isbn, int id) {
    using var connection = _db.GetConnection();
    using var command = connection.CreateCommand();

    command.CommandText = @"
      UPDATE 
        book 
      SET title = @title, year = @year, isbn = @isbn
      WHERE id_book = @id;
    ";

    command.Parameters.AddWithValue("@title", title);
    command.Parameters.AddWithValue("@year", year);
    command.Parameters.AddWithValue("@isbn", isbn);
    command.Parameters.AddWithValue("@id", id);

    int rowUpdated = command.ExecuteNonQuery();

    return rowUpdated;
  }
}