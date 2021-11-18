using AutoMapper;

namespace va.techinical.challenge.Ioc.Mapeamentos
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(c =>
            {
                c.AddProfile(new ProfileMapping());
            });
        }
    }
}
