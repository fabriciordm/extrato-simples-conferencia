using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extrato.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Extrato.Data.Context
{
    public class TransacaoContext : DbContext
    {


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.Property(e => e.Valor)
                      .HasColumnType("decimal(18,2)"); 
            });

            base.OnModelCreating(modelBuilder);
        }

        public TransacaoContext(DbContextOptions<TransacaoContext> options) : base(options) { }

        public DbSet<Transacao> Transacoes { get; set; }
    }

}
