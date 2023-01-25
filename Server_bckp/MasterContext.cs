using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace Server
{
    public class MasterContext : DbContext
    {
        public DbSet<RemoteMessage> RemoteMessages { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<XmlModel> Log { get; set; }

        public DbSet<TransacoesViewModel> Transacoes { get; set; }

        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // var conexao = ConfigurationManager.ConnectionStrings["masterlocal"].ToString();
            
            //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["masterlocal"].ConnectionString);
            
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=McConnect;Persist Security Info=True;User Id=connect;Password=Bzq3WGmZMA1h;");
            //optionsBuilder.UseSqlServer(@"Data Source=evo.mastercoin.com.br;Initial Catalog=McConnect;Persist Security Info=True;User Id=connect;Password=Bzq3WGmZMA1h;");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransacoesViewModel>().HasNoKey();
        }

    }
}
