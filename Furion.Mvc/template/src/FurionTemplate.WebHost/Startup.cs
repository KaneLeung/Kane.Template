using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FurionTemplate.WebHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // ����Ǩ���� FurionTemplate.WebCore/Startup.cs
            // �����Ҫ������ͼ��̬���룬����services.AddControllersWithViews()�������.AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ����Ǩ���� FurionTemplate.WebCore/Startup.cs
        }
    }
}