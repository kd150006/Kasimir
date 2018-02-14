using AutoMapper;
using Kasimir.Core.DataTransferObjects;
using Kasimir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kasimir.WebAPI
{
    public class AutoMapperProfileConfiguration
    {
        public AutoMapperProfileConfiguration()
        {
            Mapper.Initialize(cfg =>
                    cfg.AddProfiles(new[]
                    {
                        "Kasimir.Core"
                    }));
        }
    }
}
