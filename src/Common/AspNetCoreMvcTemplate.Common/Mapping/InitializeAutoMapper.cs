using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreMvcTemplate.Common.Mapping
{
    public class InitializeAutoMapper
    {
        public static void AddCurrentProfile()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(typeof(AutoMapperProfile));
            });
        }
    }
}
