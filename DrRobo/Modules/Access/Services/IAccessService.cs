using Refit;
using System.Threading.Tasks;
using DrRobo.Modules.Access.Models;
using DrRobo.Modules.Access.Services.Request;
using DrRobo.Modules.Access.Services.Response;

namespace DrRobo.Modules.Access.Services
{
    public interface IAccessService
    {
        [Post("/Auth/v1/login")]
        Task<TokenResponseDto> PostLogin(AccessRequestDto request);

        [Post("/Auth/v1/refresh")]
        Task<AccessModel> PostRefresh(AccessRequestDto request);

        [Get("/Auth/v1/revoke")]
        Task<AccessModel> PostRevoke();

        [Post("/Register/v1/messages")]
        Task<MessageResponseDto> PostMessage(MessageRequestDto request);
    }
}