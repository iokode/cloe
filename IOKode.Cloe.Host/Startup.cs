using IOKode.Cloe.Application;
using IOKode.Cloe.Application.Posts.UseCases;
using IOKode.Cloe.InMemoryPersistence;
using IOKode.Cloe.Rest.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOKode.Cloe.Host
{
    internal class Startup
    {
        private readonly IConfiguration _Configuration;

        public Startup(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddControllers().AddApplicationPart(typeof(PostController).Assembly);

            services.AddTransient<CreatePostUseCase>();
            services.AddInMemoryPersistence();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}