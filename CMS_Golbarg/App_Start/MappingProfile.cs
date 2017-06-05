using AutoMapper;
using CMS_Golbarg.Dtos;
using CMS_Golbarg.Areas.Admin.Models;
using CMS_Golbarg.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS_Golbarg.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Content, ContentDto>();
            Mapper.CreateMap<ContentDto, Content>();

            Mapper.CreateMap<HairColor, HairColorViewModel>();
            Mapper.CreateMap<HairColorViewModel, HairColor>();

            //Mapper.CreateMap<Mixer, CreateMixerViewModel>();
            //Mapper.CreateMap<CreateMixerViewModel, Mixer>();
        }
    }
}