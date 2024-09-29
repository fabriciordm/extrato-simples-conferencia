using AutoMapper;
using Extrato.Api.Models;
using Extrato.Domain.Interface.Repositories;
using Extrato.Domain.Models;
using Extrato.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using PdfSharpCore;
using PdfSharpCore.Pdf;
using System.Text;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace Extrato.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransacaoRepository _itransacaoRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionService _itransacaoService;
        public TransactionController(ITransacaoRepository itransacaoRepository, IMapper mapper, ITransactionService itransacaoService)
        {
            _itransacaoRepository = itransacaoRepository;
            _mapper = mapper;
            _itransacaoService = itransacaoService;
        }


        [HttpGet]
        [Route("Extrato")]
        public async Task<IActionResult> Extrato(int filtroDias = 5, int pagina = 1, int QtdPorPagina = 5)
        {
            List<TransacaoViewModel> transaction;
            var extratos = await _itransacaoRepository.GetTransactionsByDays(filtroDias);
            transaction = _mapper.Map<List<TransacaoViewModel>>(extratos);

            var pagedExtratos = transaction
               .Skip((pagina - 1) * QtdPorPagina)
               .Take(QtdPorPagina)
               .ToList();

            var totalItems = transaction.Count;

            var result = new
            {
                Page = pagina,
                PageSize = QtdPorPagina,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling(totalItems / (double)QtdPorPagina),
                Data = pagedExtratos
            };

            return Ok(result);


        }



        [HttpGet]
        [Route("generatePdf")]
        public async Task<IActionResult> ExportarPdf(int filtroDias)
        {          
            var extratos = await _itransacaoRepository.GetTransactionsByDays(filtroDias);   
            StringBuilder htmlContent = _itransacaoService.GeneratePdf(_mapper.Map<List<Transacao>>(extratos));

            var document = new PdfDocument();
            PdfGenerator.AddPdfPages(document, htmlContent.ToString(), PageSize.A4);
            byte[]? response = null;

            using (MemoryStream stream = new MemoryStream())
            {
                document.Save(stream);
                response = stream.ToArray();
            }

            string Filename = "extrato_bancario.pdf";

            return File(response, "application/pdf", Filename);
        }

     
    }
}
