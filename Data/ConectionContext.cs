using Microsoft.EntityFrameworkCore;


public class ConnectionContext : DbContext
{
    public DbSet<ItemModel> Item { get; set; }
    public DbSet<HistoricoModel> Historicos { get; set; }
    public DbSet<TransactionHistory> TransactionHistory { get; set; }
    public DbSet<AuthUser> AuthUser { get; set; }

    public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
    {
    }
}

