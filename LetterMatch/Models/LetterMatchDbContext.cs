namespace LetterMatch.Models;
using Microsoft.EntityFrameworkCore;


public class LetterMatchDbContext : DbContext
{
    public DbSet<Game>? Games { get; set; }
    public string? DbPath { get; }

    public string? GetDatabaseName() {
      string? DatabaseNameArg = Environment.GetEnvironmentVariable("DATABASE_NAME");

      if( DatabaseNameArg == null)
      {
        System.Console.WriteLine(
          "DATABASE_NAME is null. Defaulting to test database."
        );
        return "lettermatch_csharp_test";
      }
      else
      {
        System.Console.WriteLine(
          "Connecting to " + DatabaseNameArg
        );
        return DatabaseNameArg;
      }
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=Levelgres;Password=1234;Database=" + GetDatabaseName());

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // modelBuilder.Entity<Level>()
    //     //   .Navigation(Level => Level.User)
    //     //   .AutoInclude();
    // }
}
