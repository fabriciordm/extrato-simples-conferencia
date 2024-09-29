using Extrato.Data.Context;
using Extrato.Domain.Interface.Repositories;
using Extrato.Domain.Models;
using Extrato.Models;
using Extrato.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Options;

using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using AutoMapper;
using System.Text;

namespace Extrato.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;  
        private readonly ITransacaoRepository _itransacaoRepository;
        private readonly IMapper _mapper;
        private readonly ITransactionService _itransacaoService;
        private readonly LoginViewModel _login;

        public int dias;

        public HomeController(ILogger<HomeController> logger, 
            TransacaoContext context,
            ITransacaoRepository itransacaoRepository,
            IMapper mapper, 
            ITransactionService itransacaoService,
             IOptions<LoginViewModel> login)
        {
            _logger = logger;          
            _itransacaoRepository = itransacaoRepository;
            _mapper = mapper;
            _itransacaoService = itransacaoService;
            _login = login.Value;
         
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Extrato(int filtroDias )
        {          
            var extratos = await _itransacaoRepository.GetTransactionsByDays(filtroDias);
            ViewData["filtroDias"] = filtroDias;
            dias = filtroDias;

            return View(extratos);
        }

        public IActionResult login()
        {

            var loginViewModel = new LoginViewModel
            {
                Banco = _login.Banco,  
                Agencia = _login.Agencia, 
                Senha = _login.Senha 
            };

            return View(loginViewModel);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {              
                return RedirectToAction("Extrato");
            }
           
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExportarPDF(int filtroDias)
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

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
