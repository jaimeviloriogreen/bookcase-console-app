using Bookcase.Models;
using Microsoft.EntityFrameworkCore;
namespace Bookcase.Database;

public class AppDbContext(string dbPath) : DbContext {
  private readonly string _dbPath = dbPath;

  public DbSet<BookModel> Books { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options) {
    options.UseSqlite($"Data Source={_dbPath}");
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.Entity<BookModel>().ToTable("book");
  }
}