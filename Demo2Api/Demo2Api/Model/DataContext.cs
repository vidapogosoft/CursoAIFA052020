using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Demo2Api.Model.Entidades;

namespace Demo2Api.Model
{
    public class DataContext : DbContext
    {

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DTORegistrados> DTORegister { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                          .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                          .AddJsonFile("appsettings.json")
                          .Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("database"));
            }
        }

    }
}
