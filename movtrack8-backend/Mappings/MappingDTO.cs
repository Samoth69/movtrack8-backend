using AutoMapper;
using movtrack8_backend.DTO;
using movtrack8_backend.Models;

namespace movtrack8_backend.Mappings
{
    public class MappingDTO : Profile
    {
        public MappingDTO()
        {
            CreateMap<EntityBase, BaseDTO>()
                .Include<TOeuvre, OeuvreDTO>();

            CreateMap<TOeuvre, OeuvreDTO>();

            //
            // Reverse mapping
            //
            
            CreateMap<BaseDTO, EntityBase>()
                .Include<OeuvreDTO, TOeuvre>()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.UpdatedAt, opt => opt.Ignore())
                .ForMember(src => src.CreatedAt, opt => opt.Ignore());

            CreateMap<OeuvreDTO, TOeuvre>();
        }
    }
}
