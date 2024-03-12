using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Mountain, MountainDto>()
                .ForMember(d => d.Voivodeship, o => o.MapFrom(s => s.Voivodeship.Name))
                .ForMember(d => d.MountainsRange, o => o.MapFrom(s => s.MountainsRange.Name))
                .ForMember(d => d.ImagePath, o => o.MapFrom<MountainUrlResolver>());

            CreateMap<MountainDto, Mountain>()
                .ForMember(d => d.Voivodeship, o => o.MapFrom(s => new Voivodeship() {
                    Name = s.Voivodeship, 
                    Id = s.VoivodeshipId
                    }))
                .ForMember(d => d.MountainsRange, o => o.MapFrom(s => new MountainsRange() {
                    Name = s.MountainsRange, 
                    Id = s.MountainsRangeId
                    }));
                
        }
    }
}