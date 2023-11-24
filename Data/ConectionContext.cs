using Microsoft.EntityFrameworkCore;

public class ConnectionContext : DbContext
    {
        public DbSet<ItemModel> Item { get; set; }
        public DbSet<HistoricoModel> Historicos  { get; set; }
        public DbSet<HistoricoDoisModel> HistoricoDois  { get; set; }
       
       
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = 
                    "Server=localhost;" +
                    "Database=StorEase;" +
                    "User=SA;" +
                    "Password=992534@Tx;" +
                    "Encrypt=false;TrustServerCertificate=true;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        
    }

    