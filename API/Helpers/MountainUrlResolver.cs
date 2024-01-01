using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class MountainUrlResolver : IValueResolver<Mountain, MountainDto, string>
    {
        private readonly IConfiguration _config;
        public MountainUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Mountain source, MountainDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImagePath))
            {
                return _config["ApiUrl"] + source.ImagePath;
            }
            return null;
        }
    }
}