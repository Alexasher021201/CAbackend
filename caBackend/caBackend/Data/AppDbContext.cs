using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<GameResult> GameResults { get; set; }
    public DbSet<User> Users { get; set; } // 添加这一行
}
