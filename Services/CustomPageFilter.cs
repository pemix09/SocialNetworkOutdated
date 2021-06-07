using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace SocialNetwork.Services
{
    public class CustomPageFilter : IPageFilter
    {
        public IConfiguration _config;
        public ILogger<CustomPageFilter> _logger;
        IHttpContextAccessor _httpContextAccessor;
        public CustomPageFilter(IConfiguration config)
        {
            
            _config = config;
            
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
        }

        // Dodajemy do dziennika zdarzeń informację prosto z naszego kodu
        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            
          /*  System.Net.IPAddress ipAddress = _httpContextAccessor.HttpContext.Request.HttpContext.Connection.RemoteIpAddress;
            string absoluteurl = _httpContextAccessor.HttpContext.Request.Path;
            _logger.LogDebug("Użytkownik o adresie:" + ipAddress +  "właśnie wszedł na stronę:" + absoluteurl + DateTime.Now);*/
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
        }
    }
}
