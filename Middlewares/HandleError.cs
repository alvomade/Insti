using Insti.Middlewares;
using System.Reflection.Metadata;

namespace Insti.Middlewares
{

    public class HandleError
    {
        private readonly RequestDelegate _next;
        public HandleError(RequestDelegate next) {
            _next= next;
        }    
        public async Task InvokeAsync(HttpContext context) {
            Console.WriteLine("testing mws");
            try {
                Console.WriteLine("something is wrong" + context.Response.Body);
                await _next(context);

            } catch (Exception e) {
                Console.WriteLine("something is wrong"+ context.Response.Body);
                context.Response.StatusCode = 500;
                Console.WriteLine(e.ToString()); }  
             }
            
            
        }   
    }

    

 
