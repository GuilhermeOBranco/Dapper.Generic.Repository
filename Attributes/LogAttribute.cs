using LogMiddleware.Api.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;
using System.Text.Json;

namespace LogMiddleware.Api.Attributes
{
    public class LogAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LogAttribute> _logger;
        public LogAttribute(ILogger<LogAttribute> logger)
        {
            _logger = logger;
        }

        public override async void OnActionExecuted(ActionExecutedContext context)
        {
            var teste = context.HttpContext.Request.Body.ToString();
            byte[] buffer = new byte[Convert.ToInt64(context.HttpContext.Request.ContentLength)];

            await context.HttpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            _logger.Log(LogLevel.Information, "Log message: " + Encoding.UTF8.GetString(buffer));



        }
    }
}
