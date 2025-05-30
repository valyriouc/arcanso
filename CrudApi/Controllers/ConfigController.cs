using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConfigController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(AiConfig config, CancellationToken cancellationToken)
    {
        
    }
    
}

public class GeneralConfig
{
    public string RootPath { get; set; } 
}

public enum AiPlatform
{
    Ollama,
    ChatGpt
}

public class AiConfig
{
    public AiPlatform Platform { get; set; } = AiPlatform.Ollama;
    
    public string ApiUrl { get; set; } = "http://localhost:11434/";

    public string? ApiKey { get; set; }
}