using Extrato.Domain.Interface.Commons;
using Extrato.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extrato.Domain.Interface.Repositories
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> GetTransactionsByDays(int days);
      
    }
}
