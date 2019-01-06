namespace AspNetCoreMvcTemplate.Common.Mapping
{
    using AutoMapper;

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
