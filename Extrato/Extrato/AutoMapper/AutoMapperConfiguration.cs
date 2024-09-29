using AutoMapper;
using Extrato.AutoMapper;

namespace Extrato.Api.AutoMapper
{
    public class Automapper()
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new DomainToViewModelMappingProfile());
                ps.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
