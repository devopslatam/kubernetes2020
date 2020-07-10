using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var helper = BuildRequestHelper(context);
                if (helper.HandleByMyself())
                {
                    await context.Response.WriteAsync("Hello from WEB!");
                }
                else
                {
                    HttpClient client = new HttpClient();
                    var response = client.GetStringAsync(helper.BuildServiceUrl());
                    response.Wait();

                    await context.Response.WriteAsync(response.Result);
                }
            });
        }

        RequestHelper BuildRequestHelper(HttpContext context)
        {
            var url = context.Request.Path.Value.Substring(1);
            var path = string.Empty;
            var basePath = string.Empty;
            int i = url.IndexOf('/');
            if (i != -1)
            {
                basePath = url.Substring(0, i);
                path = url.Substring(i);
            }

            return new RequestHelper()
            {
                BasePath = basePath,
                Path = path,
                QueryString = context.Request.QueryString
            };
        }

        class RequestHelper
        {
            public string BasePath { get; set; }
            public string Path { get; set; }
            public QueryString QueryString { get; set; }

            public bool HandleByMyself()
            {
                return string.IsNullOrEmpty(BasePath);
            }

            public string BuildServiceUrl()
            {
                return $"http://{BasePath}:5000{Path}{QueryString.ToString()}";
            }
        }
    }
}
