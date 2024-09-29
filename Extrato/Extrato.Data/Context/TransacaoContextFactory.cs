using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Extrato.Data.Context
{
    public class TransacaoContextFactory : IDesignTimeDbContextFactory<TransacaoContext>
    {
        public TransacaoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TransacaoContext>();

            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

           
            var connectionString = configuration.GetConnectionString("TransacaoConnection");

           
            optionsBuilder.UseSqlServer(connectionString);

            return new TransacaoContext(optionsBuilder.Options);
        }
    }


    

}
