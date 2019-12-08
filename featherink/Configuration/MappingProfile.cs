using featherink.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace featherink.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Art, Art>();
            CreateMap<Comment, Comment>();
            CreateMap<Database.Entities.Task, Database.Entities.Task>();
            CreateMap<Designer, Designer>();
        }

    }
}
