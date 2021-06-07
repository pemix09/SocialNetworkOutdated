using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace SocialNetwork.Services
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        private readonly IConfiguration _config;
        private readonly RequestDelegate _next;
        //private readonly ILogger _logger;
        XmlDocument xml = new XmlDocument();
        string xmlpath;

        public MyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            xmlpath = configuration.GetValue<string>("AppSettings:XmlLog_path");
            _next = next;
           // _logger = loggerFactory.CreateLogger<MyMiddleware>();
        }

        public Task Invoke(HttpContext httpContext)
        {
            System.Net.IPAddress ipAddress = httpContext.Request.HttpContext.Connection.RemoteIpAddress;
            string absoluteurl = httpContext.Request.Path;

            xml.Load(xmlpath);
            
            XmlElement info = xml.CreateElement("LogInfo");
            info.InnerText = $"[{DateTime.Now}] => Użytkownik o adresie: {ipAddress}  wszedł na stronę: {absoluteurl}";
           

            XmlElement mapElement = (XmlElement)xml.SelectSingleNode(@"//LogInfo[last()]");
            mapElement.AppendChild(info);
            xml.Save(xmlpath);
            //_logger.LogDebug("Użytkownik o adresie:" + ipAddress +  "właśnie wszedł na stronę:" + absoluteurl + DateTime.Now);

            return _next(httpContext);
            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
