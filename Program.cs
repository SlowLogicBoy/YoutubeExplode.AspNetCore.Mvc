using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspNetYoutubeExplode
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}
