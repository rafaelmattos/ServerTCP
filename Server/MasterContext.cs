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
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Server
{
    public class MasterContext : IdentityDbContext<AppUser>
    {
        public DbSet<RemoteMessage> RemoteMessages { get; set; }
        public DbSet<Details> Details { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<XmlModel> Log { get; set; }
        public DbSet<Linguagens> Linguagens { get; set; }
        public DbSet<UserCliente> UserClientes { get; set; }
        public DbSet<TransacoesViewModel> Transacoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<TransacoesViewModel>().HasNoKey();

            modelBuilder.Entity<UserCliente>()
                .HasKey(uc => new { uc.UserId, uc.ClienteId });

            
        }



        

        


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = string.Empty;

            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("configmastercoin.json", optional: false);
            var config = builder.Build();
               #if (DEBUG)
                   connectionString = config["ConnectionStringLocal"];
               #endif
               #if (!DEBUG)
                         connectionString = config["ConnectionStringServer"];
               #endif


            optionsBuilder.UseSqlServer(connectionString);

        }


        

    }
}
