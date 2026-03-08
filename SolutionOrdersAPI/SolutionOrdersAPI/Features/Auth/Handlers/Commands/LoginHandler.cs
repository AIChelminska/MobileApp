using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SolutionOrdersAPI.Features.Auth.Messages.Commands;
using SolutionOrdersAPI.Models.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SolutionOrdersAPI.Features.Auth.Handlers.Commands;

public class LoginHandler(ApplicationDbContext context, IConfiguration configuration)
    : IRequestHandler<LoginCommand, string>
{
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var worker = await context.Workers
            .FirstOrDefaultAsync(w => w.Login == request.Login && w.IsActive, cancellationToken);

        if (worker == null)
            throw new UnauthorizedAccessException("Nieprawidłowy login lub hasło.");

        if (string.IsNullOrEmpty(worker.Password) || !BCrypt.Net.BCrypt.Verify(request.Password, worker.Password))
            throw new UnauthorizedAccessException("Nieprawidłowy login lub hasło.");

        var token = GenerateJwtToken(worker.Login, worker.IdWorker);

        return token;
    }

    private string GenerateJwtToken(string login, int idWorker)
    {
        var jwtKey = configuration["Jwt:Key"]!;
        var jwtIssuer = configuration["Jwt:Issuer"]!;
        var jwtAudience = configuration["Jwt:Audience"]!;
        var expiryMinutes = int.Parse(configuration["Jwt:ExpiryMinutes"]!);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login),
            new Claim("IdWorker", idWorker.ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}