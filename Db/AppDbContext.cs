using Microsoft.EntityFrameworkCore;
using VideoGameCharacterAPI.Models;

namespace VideoGameCharacterAPI.Db;

public class AppDbcontext(DbContextOptions<AppDbcontext> options) : DbContext(options)
{
    public DbSet<Character> Characters => Set<Character>();
}