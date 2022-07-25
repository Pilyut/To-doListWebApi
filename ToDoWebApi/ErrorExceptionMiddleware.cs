using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ToDoWebApi
{
    public class ErrorExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorExceptionMiddleware(RequestDelegate next)
        {
            _next = next;            
        }
        public async Task InvokeAsync(HttpContext context)
        {

        }
    }
}
