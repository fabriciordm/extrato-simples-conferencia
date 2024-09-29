using AutoMapper;
using Extrato.Api.Models;
using Extrato.Domain.Models;


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
