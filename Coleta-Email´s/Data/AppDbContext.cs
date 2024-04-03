using Coleta_Email_s.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Coleta_Email_s.Data
{
    public class AppDbContext : DbContext
    {
        //Db Set representação de uma tabela
        public DbSet<EmailModel> Emails { get; set; }

        // string de conexão
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=app.db; Cache=Shared");
        }
    }
}
