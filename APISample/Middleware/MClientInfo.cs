using APISample.Models.Auth;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        public async Task InvokeAsync(HttpContext httpContext,DatabaseContext db)
        {
            UserMachineDetails(httpContext,db);
            await _next(httpContext);
        }


        public void UserMachineDetails(HttpContext httpContext,DatabaseContext db)
        {
            var remoteIpAddress = httpContext.Connection.RemoteIpAddress?.ToString();
            dynamic address = null!;
            if (remoteIpAddress == "::1")
            {
                string hostname = Dns.GetHostName();
                address = Dns.GetHostAddresses(hostname);
            }
            else
            {
                //for request comes over the internet
            }

            db.SM_HostDetails_Mst.Add(new HostDetails { Ipaddress = address[1].ToString() });
            db.SaveChanges();

        }
    }
}
