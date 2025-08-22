using Microsoft.AspNetCore.Authorization;

namespace MedGestor.Adapter.Driving.Api.Authorization;

public class ApiKeyRequirement(string requiredApiKey) : IAuthorizationRequirement
{
    public string RequiredApiKey { get; } = requiredApiKey;
}