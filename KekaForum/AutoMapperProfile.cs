using AutoMapper;
using KekaForum.Models.Core;
using KekaForum.Services.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KekaForum
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Models.Core.User, Services.Models.Data.User>().ReverseMap();
            CreateMap<Models.Core.Question, Services.Models.Data.Question>().ReverseMap();
        }
    }
}
