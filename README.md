# AspNetCore.Middlewares

本方案包含 ASP.NET Core 中介軟體元件與範例專案。

## 專案結構

- **AspNetCore.Middlewares**  
  提供可重複使用的 ASP.NET Core 中介軟體（Middleware），如維護模式與請求主體緩衝。

- **AspNetCore.Middlewares.Sample**  
  範例專案，展示如何在 ASP.NET Core 應用程式中註冊與使用這些中介軟體。

## 主要中介軟體

### MaintenanceMiddleware（維護模式）

- 依據環境變數 `MAINTENANCE_MODE` 判斷是否進入維護狀態。
- 當變數值為 `"true"` 時，所有 API 請求會回傳 503 維護中。
- 可透過 `/sample/maintenance/on` API 啟用維護模式（無法透過 API 關閉）。

### RequestBodyBufferingMiddleware（請求主體緩衝）

- 讓 `Request.Body` 支援多次讀取，方便日誌、驗證等需求。

## 範例用法

1. 在 `Program.cs` 註冊中介軟體：

   ```csharp
   app.UseMiddleware<AspNetCore.Middlewares.MaintenanceMiddleware>();
   app.UseMiddleware<AspNetCore.Middlewares.RequestBodyBufferingMiddleware>();
   ```