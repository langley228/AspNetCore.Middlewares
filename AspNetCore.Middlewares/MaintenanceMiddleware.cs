using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AspNetCore.Middlewares
{
    /// <summary>
    /// 維護模式中介軟體，根據環境變數 MAINTENANCE_MODE 判斷是否啟用維護。
    /// </summary>
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;

        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 讀取環境變數 MAINTENANCE_MODE，值為 "true" 時進入維護模式
            var isInMaintenance = 
                System.Environment.GetEnvironmentVariable("MAINTENANCE_MODE")?.ToLower() == "true";

            if (isInMaintenance)
            {
                context.Response.StatusCode = StatusCodes.Status503ServiceUnavailable;
                await context.Response.WriteAsync("系統維護中，請稍後再試。");
                return;
            }
            await _next(context);
        }
    }
}
