﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace YMYPHibritGroup.API.Filters
{
    public class MyActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("OnActionExecuting çalıştı");

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("OnActionExecuted çalıştı");
        }

        
    }
}
