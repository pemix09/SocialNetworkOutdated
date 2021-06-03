using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace SocialNetwork.Services
{
    public class CustomPageFilter : IPageFilter
    {
        public IConfiguration _config;
        public CustomPageFilter(IConfiguration config)
        {
            _config = config;
            int a = 0;
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            int a = 0;
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            int a = 0;
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            int a = 0;
        }
    }
}
