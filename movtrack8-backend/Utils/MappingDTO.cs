using AutoMapper;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;

namespace movtrack8_backend.Utils.Utils
{
    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            CreateMap<EntityBase, BaseDTO>()
                .Include<TOeuvre, OeuvreDTO>()
                .Include<TEpisode, EpisodeDTO>()
                .Include<TWebsite, WebsiteDTO>()
                .ForMember(src => src._IsHttpPatch, opt => opt.Ignore());

            CreateMap<TOeuvre, OeuvreDTO>()
                .ForSourceMember(src => src.Episodes, opt => opt.DoNotValidate());

            CreateMap<TEpisode, EpisodeDTO>()
                .ForSourceMember(src => src.Oeuvre, opt => opt.DoNotValidate())
                .ForSourceMember(src => src.Website, opt => opt.DoNotValidate());

            CreateMap<TWebsite, WebsiteDTO>()
                .ForSourceMember(src => src.Episodes, opt => opt.DoNotValidate());

            //
            // Reverse mapping
            //

            CreateMap<BaseDTO, EntityBase>()
                .Include<OeuvreDTO, TOeuvre>()
                .Include<EpisodeDTO, TEpisode>()
                .Include<WebsiteDTO, TWebsite>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.UpdatedAt, opt => opt.Ignore())
                .ForMember(src => src.CreatedAt, opt => opt.Ignore())
                // saute les champs qui sont null lors du mapping vers le modèle
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<OeuvreDTO, TOeuvre>()
                .ForMember(src => src.Episodes, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<EpisodeDTO, TEpisode>()
                .ForMember(src => src.Oeuvre, opt => opt.Ignore())
                .ForMember(src => src.Website, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<WebsiteDTO, TWebsite>()
                .ForMember(src => src.Episodes, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
