using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;


namespace SocialNetwork.Services
{
    //w tym filtrze dodamy obsługę loggera, czegoś do robienia dzienników, 
    //kto, i gdzie wchodzi
    public class CustomFilter : ResultFilterAttribute
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext pageContext)
        {
            int a = 0;

        }
        public void OnPageHandlerExecuting(PageHandlerExecutingContext pageContext)
        {
            int a = 0;
        }
        public void OnPageHandlerExecuted(PageHandlerExecutedContext pageContext)
        {
            int a = 0;
        }
    }
}
