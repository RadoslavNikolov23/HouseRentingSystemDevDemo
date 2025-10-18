using AutoMapper;
using HouseRentingSystem.Services.Infrastructure;
using Microsoft.Extensions.Logging;

namespace HouseRentingSystem.Tests.Mocks
{
    public static class MapperMock
    {
        public static IMapper Instance
        {
            get
            {
                var loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                });

                var mapperConfiguration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<ServiceMappingProfile>(); // make sure this matches your actual profile class
                }, loggerFactory);

                return mapperConfiguration.CreateMapper();

            }
        }
    }
}
