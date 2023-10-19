using System.Diagnostics;

namespace WebTimer.Middlewares
{
    public class PerformanceMiddleware
    {
        public RequestDelegate _next;

        public PerformanceMiddleware(RequestDelegate next) {  _next = next; }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Restart();


            await _next(context);

            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 300)
            {
                Console.WriteLine($"WebTimer: long running request ... {stopwatch.ElapsedMilliseconds} MS");
                return;
            }
            Console.WriteLine($"WebTimer: Running request ... {stopwatch.ElapsedMilliseconds} MS");

        }
    }
}
