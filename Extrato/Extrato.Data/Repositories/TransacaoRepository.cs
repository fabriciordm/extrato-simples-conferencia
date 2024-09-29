using Extrato.Data.Context;
using Extrato.Domain.Interface.Repositories;
using Extrato.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Extrato.Data.Repositories
{
    public  class TransacaoRepository : ITransacaoRepository
    {
        private readonly TransacaoContext _context;

        public TransacaoRepository(TransacaoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transacao>> GetTransactionsByDays(int days)
        {
            DateTime dataFiltro = DateTime.Now.AddDays(-days);
            return await _context.Transacoes
                                 .Where(e => e.Data >= dataFiltro)
                                 .ToListAsync();
        }
      
    }
}
