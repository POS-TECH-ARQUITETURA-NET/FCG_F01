using API_FCG_F01.Application.DTOs;
using API_FCG_F01.Domain.Entities;
using AutoMapper;

namespace API_FCG_F01.Application.Mappings;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Usuario, UsuarioDto>();
        CreateMap<Jogo, JogoDto>();
        CreateMap<BibliotecaJogosItem, BibliotecaItemDto>()
            .ForMember(dest => dest.JogoId, opt => opt.MapFrom(src => src.JogoId))
            .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.Jogo != null ? src.Jogo.Titulo : string.Empty));
        CreateMap<BibliotecaJogos, BibliotecaDto>()
            .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.Itens));
    }
}
