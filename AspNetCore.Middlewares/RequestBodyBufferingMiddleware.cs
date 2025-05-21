using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore.Middlewares
{
    /// <summary>
    /// 啟用 Request.Body 可重複讀取的中介軟體。
    /// 允許後續中介軟體或控制器多次讀取請求主體。
    /// </summary>
    public class RequestBodyBufferingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestBodyBufferingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 啟用 Buffering，讓 Request.Body 可多次讀取
            context.Request.EnableBuffering();

            // 呼叫下一個中介軟體
            await _next(context);
        }
    }
}
