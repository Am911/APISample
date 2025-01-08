using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace APISample.Middleware
{
    public class MClientInfo
    {
        private readonly RequestDelegate _next;
        public MClientInfo(RequestDelegate _next)
        {
                this._next = _next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var localIpAddress = httpContext.Connection.LocalIpAddress?.ToString();

            var remoteIpAddress = httpContext.Connection.RemoteIpAddress?.ToString();


            await _next(httpContext);
        }
    }
}
