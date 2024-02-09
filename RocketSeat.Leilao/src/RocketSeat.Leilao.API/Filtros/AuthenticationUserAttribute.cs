using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeat.Leilao.API.Repositories.Contracts;

namespace RocketSeat.Leilao.API.Filtros;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly IUserRepository _userRepository;

    public AuthenticationUserAttribute(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = Token(context.HttpContext.Request);
            var user = await _userRepository.RecuperarUserPeloToken(token);
            if (user is null)
            {
                context.Result = new UnauthorizedObjectResult("Não Autorizado!");
            }
            else
            {
                context.HttpContext.Response.Headers.Add("userId", user.Id.ToString());
            }

        }
        catch (Exception ex)
        {
            context.Result = new BadRequestObjectResult(ex.Message);
        }
    }

    private string Token(HttpRequest request)
    {
        return request
            .Headers
            .Authorization
            .ToString()
            .Replace("Bearer", string.Empty)
            .Trim();
    }
}
