using AutoMapper;
using Extrato.Domain.Models;
using Extrato.Models;

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
