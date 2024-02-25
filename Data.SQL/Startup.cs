using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.SQL
{
    public class Startup
    {
        public void RegisterDbContext(IServiceCollection services)
        {
            var connectionString = "Data Source=.;Initial Catalog=PetProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<WebContext>(op => op.UseSqlServer(connectionString));
        }
    }
}
