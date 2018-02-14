using AutoMapper;
using Kasimir.Core.DataTransferObjects;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.AutoMapperProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<ProductType, BasketDto>();
        }
    }
}
