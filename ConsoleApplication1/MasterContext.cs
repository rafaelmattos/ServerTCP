using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Models;
using ConsoleApplication1.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using ConfigurationBuilder = Microsoft.Extensions.Configuration.ConfigurationBuilder;

namespace ConsoleApplication1
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

            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=McConnect;Persist Security Info=True;User Id=connect;Password=SENHABD;");
            //optionsBuilder.UseSqlServer(@"Data Source=evo.mastercoin.com.br;Initial Catalog=McConnect;Persist Security Info=True;User Id=connect;Password=SENHBD;");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransacoesViewModel>().HasNoKey();
        }

    }
}
