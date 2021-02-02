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

            CreateMap<Services.Models.Data.Question,Models.Core.Question>()
                .ForMember(coreModel=>coreModel.IsResolved,
                   m=>m.MapFrom(dataModel=>dataModel.IsResolved==1 ? true:false));

            CreateMap<Services.Models.Data.AnswerModel, Models.Core.AnswerModel>()
                .ForMember(coreModel => coreModel.IsBestAnswer,
                    m => m.MapFrom(dataModel => dataModel.IsBestAnswer == 1 ? true : false));
        }
    }
}
