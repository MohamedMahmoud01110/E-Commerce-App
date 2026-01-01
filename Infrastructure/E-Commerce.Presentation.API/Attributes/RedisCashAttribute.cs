using E_Commerce.ServiceAbstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace E_Commerce.Presentation.API.Attributes
{
    internal class RedisCashAttribute(int duration = 2) : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //1. get CashService using DI
            var cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();
            //2. Create Cash Key using query string => order query string
            string key = GenerateCashKey(context.HttpContext.Request);
            //3. Search for cash value
            var cashValue = await cashService.GetAsync(key);
            ///3.1 exists => return response && don't invoke the action
            if (cashValue is not null)
            {
                context.Result = new ContentResult
                {
                    Content = cashValue,
                    ContentType = "application/json",
                    StatusCode = StatusCodes.Status200OK //200
                };
                return;
            }
            ///3.2 !exists => invoke the action 
            var actionExecutedContext = await next.Invoke();
            var result = actionExecutedContext.Result;
            // check for ok object result then cash
            if (result is OkObjectResult okResult)
                await cashService.SetAsync(key, okResult.Value!, TimeSpan.FromMinutes(duration));
        }

        private static string GenerateCashKey(HttpRequest request)
        {
            // collection<key , value>
            // order query string
            var sb = new StringBuilder();
            foreach (var Kvp in request.Query.OrderBy(q => q.Key))
            {
                sb.Append($"{Kvp.Key} - {Kvp.Value} - ");
            }
            return sb.ToString().Trim('-');
        }
    }
}
