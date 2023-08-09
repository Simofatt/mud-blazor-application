using AutoMapper;
using DTO.DataModels;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MappingProfiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Author, AuthorDto>();
        }
    }
}
