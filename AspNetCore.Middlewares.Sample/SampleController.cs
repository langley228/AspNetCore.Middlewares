// filepath: AspNetCore.Middlewares.Sample/Controllers/SampleController.cs
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class SampleController : ControllerBase
{
    /// <summary>
    /// 範例 POST，回傳收到的原始請求內容。
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Post()
    {
        if (Request.Body.CanSeek)
        {
            Request.Body.Position = 0;
        }

        using var reader = new StreamReader(Request.Body, Encoding.UTF8, leaveOpen: true);
        var body = await reader.ReadToEndAsync();

        if (Request.Body.CanSeek)
        {
            Request.Body.Position = 0;
        }

        return Ok(new { Received = body });
    }

    /// <summary>
    /// 啟用維護模式（無法關閉）
    /// </summary>
    [HttpPost("maintenance/on")]
    public IActionResult EnableMaintenance()
    {
        System.Environment.SetEnvironmentVariable("MAINTENANCE_MODE", "true");
        return Ok(new { Maintenance = true });
    }
}