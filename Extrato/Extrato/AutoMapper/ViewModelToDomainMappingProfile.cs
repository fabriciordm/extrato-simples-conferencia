using AutoMapper;
using Extrato.Domain.Models;
using Extrato.Models;

namespace Extrato.AutoMapper
{
    public class ViewModelToDomainMappingProfile:Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TransacaoViewModel, Transacao>();
        }
    }
}
