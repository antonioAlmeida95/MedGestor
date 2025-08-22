using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace MedGestor.Adapter.Driving.Api.Authorization;

public class ApiKeyRequirementHandler : AuthorizationHandler<ApiKeyRequirement>
{
    private const string ApiKeyHeader = "X-Api-Key";
    private const string NonceHeader = "X-Nonce";
    private const string TimestampHeader = "X-Timestamp";
    
    private readonly IMemoryCache _memoryCache;
    
    public ApiKeyRequirementHandler(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
    }
    
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
    {
        if (context.Resource is not HttpContext httpContext ||
            !httpContext.Request.Headers.TryGetValue(ApiKeyHeader, out var apiKey) ||
            !httpContext.Request.Headers.TryGetValue(NonceHeader, out var nonce) ||
            !httpContext.Request.Headers.TryGetValue(TimestampHeader, out var timestampStr))
            return Task.CompletedTask;
        
        //Verifica o tempo de expiração do timestamp
        var timestampValido = ValidaTimestamp(timestampStr);
        if (!timestampValido) 
            return Task.CompletedTask; // Timestamp inválido ou expirado
        
        var nonceValido = ValidaNonce(nonce);
        if (!nonceValido)
            return Task.CompletedTask; // Nonce inválido ou já utilizado
        
        if (!apiKey.Equals(requirement.RequiredApiKey)) return Task.CompletedTask;
        
        context.Succeed(requirement);
        return Task.CompletedTask; // Autorização bem-sucedida
    }
    
    /// <summary>
    ///     Valida o timestamp do cabeçalho X-Timestamp.
    ///     O timestamp deve ser um valor Unix em segundos e não pode ser mais recente que 5 minutos do horário atual.
    ///     Se o timestamp for inválido ou estiver expirado retorna false.
    ///     Caso contrário, retorna true.
    /// </summary>
    /// <param name="timestamp"></param>
    /// <returns>Verificação do timestamp</returns>
    private static bool ValidaTimestamp(string? timestamp)
    {
        if (string.IsNullOrEmpty(timestamp) || 
            !long.TryParse(timestamp, out var timestampValue))
            return false; // Timestamp inválido
        
        var requestTime = DateTimeOffset.FromUnixTimeSeconds(timestampValue);
        return requestTime < DateTimeOffset.UtcNow.AddMinutes(-5);
    }

    /// <summary>
    ///     Valida o nonce do cabeçalho X-Nonce.
    ///     O nonce deve ser único e não pode ser reutilizado.
    ///     Se o nonce já foi utilizado, retorna false (indica um replay attack).
    ///     Caso contrário, armazena o nonce na memória transitória e retorna true.
    ///     O nonce é armazenado na memória transitória por 5 minutos para evitar reutilização.
    /// </summary>
    /// <param name="nonce"></param>
    /// <returns>Verificação do Nonce</returns>
    private bool ValidaNonce(string? nonce)
    {
        if (string.IsNullOrWhiteSpace(nonce)) return false;
        
        var nonceExistente = _memoryCache.TryGetValue(nonce, out _);
        if (nonceExistente) 
            return false; // Nonce já utilizado, é um replay attack!
        
        _memoryCache.Set(nonce, true, TimeSpan.FromMinutes(5));
        return true; // Nonce válido e não utilizado
    }
}