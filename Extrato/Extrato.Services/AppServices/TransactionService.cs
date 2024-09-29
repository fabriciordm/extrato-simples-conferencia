using Extrato.Services.Interfaces;
using Extrato.Domain.Models;
using System.Text;

using PdfSharpCore;
using PdfSharpCore.Pdf;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Extrato.Services.AppServices
{
    public class TransactionService : ITransactionService
    {
        public TransactionService()
        {
          
        }

        public StringBuilder GeneratePdf(List<Transacao> transaction)
        {          
           
            var htmlContent = new StringBuilder();

           
            htmlContent.Append(@"
        <html>
        <head>
            <style>
                body {
                    font-family: Arial, sans-serif;
                    margin: 20px;
                }
                h1 {
                    text-align: center;
                    color: #333;
                }
                table {
                    width: 100%;
                    border-collapse: collapse;
                    margin-bottom: 20px;
                }
                th, td {
                    border: 1px solid #ddd;
                    padding: 8px;
                    text-align: left;
                }
                th {
                    background-color: #f2f2f2;
                    color: #333;
                }
                tr:nth-child(even) {
                    background-color: #f9f9f9;
                }
                .total {
                    font-weight: bold;
                }
            </style>
        </head>
        <body>
            <h1>Extrato Bancário</h1>
            <table>
                <thead>
                    <tr>
                        <th>Data</th>
                        <th>Tipo de Transação</th>
                        <th>Valor</th>
                    </tr>
                </thead>
                <tbody>");

            
            foreach (var transacao in transaction)
            {
                htmlContent.AppendFormat(@"
            <tr>
                <td>{0:dd/MM/yyyy}</td>
                <td>{1}</td>
                <td>{2:C}</td>
            </tr>", transacao.Data, transacao.TipoTransacao, transacao.Valor);
            }

           
            htmlContent.Append(@"
                </tbody>
            </table>
        </body>
        </html>");

            
            return htmlContent;
        }
     
        public List<Transacao> GetTransactions(int days)
        {
           
            return new List<Transacao>
        {
            new Transacao { Data = DateTime.Now.AddDays(-1), TipoTransacao = "Depósito", Valor = 500 },
            new Transacao { Data = DateTime.Now.AddDays(-5), TipoTransacao = "Saque", Valor = -200 },
            new Transacao { Data = DateTime.Now.AddDays(-10), TipoTransacao = "Pagamento", Valor = -300 }
        };
        }
    }
}
