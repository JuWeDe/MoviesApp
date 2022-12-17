using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesApp.Filters;

public class ValidActorsBirthDate : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var startDate = DateTime.Parse(context.HttpContext.Request.Form["DateOfBirth"]);
        if (DateTime.Now.Year - startDate.Year > 99 || DateTime.Now.Year - startDate.Year < 7)
        {
            context.Result = new BadRequestResult();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}