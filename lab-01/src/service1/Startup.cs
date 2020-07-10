using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace service1
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var result = "Hello from [SERVICE1]! " +
                            $"path={context.Request.Path}, " + 
                            $"query={context.Request.QueryString.ToString()}";
                await context.Response.WriteAsync(result);
            });
        }
    }
}
