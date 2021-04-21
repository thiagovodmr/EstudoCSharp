using CAP.ApplicationCore.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAP.WebApplication.MappingConfig
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(EntityToViewModelMappingProfile), typeof(ViewModelToEntityMappingProfile));
        }
    }
}
