using System;
using Microsoft.AspNetCore.Http;

namespace AspNetCore.Middlewares
{
    /// <summary>
    /// 提供 HttpContext 相關的擴充方法。
    /// </summary>
    internal static class HttpContextExtensions
    {
        /// <summary>
        /// 判斷系統是否處於維護模式。
        /// 透過檢查環境變數 "IsMaintenance" 是否為 "1" 來決定。
        /// 若為 "1" 則表示系統進入維護狀態，否則為正常狀態。
        /// </summary>
        /// <param name="context">HTTP 請求內容。</param>
        /// <returns>若為維護模式則回傳 true，否則回傳 false。</returns>
        public static bool IsMaintenance(this HttpContext context)
        {
            return Environment.GetEnvironmentVariable("IsMaintenance") == "1";
        }
    }
}
