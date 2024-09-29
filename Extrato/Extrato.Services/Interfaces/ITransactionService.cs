using Extrato.Domain.Models;
using System.Text;

namespace Extrato.Services.Interfaces
{
    public interface ITransactionService
    {
        List<Transacao> GetTransactions(int days);
        StringBuilder GeneratePdf(List<Transacao> transaction);
    }
}
