using AutoMapper;
using Extrato.Api.Models;
using Extrato.Domain.Models;


namespace Extrato.AutoMapper
{
    public class DomainToViewModelMappingProfile:Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Transacao, TransacaoViewModel>();
        }

    }
}
