using System.Threading;
using System.Threading.Tasks;

namespace Progo.Game
{
    // Transport-agnostic contract. The Unity client should call a real HTTPS/auth provider
    // through an implementation of this interface. Passwords must never be persisted locally.
    public interface IAccountService
    {
        Task<PlayerProfile> RegisterAsync(string email, string password, string displayName, CancellationToken cancellationToken);
        Task<PlayerProfile> LoginAsync(string email, string password, CancellationToken cancellationToken);
        Task<PlayerProfile> GetProfileAsync(CancellationToken cancellationToken);
        Task SaveProfileAsync(PlayerProfile profile, CancellationToken cancellationToken);
        Task LogoutAsync(CancellationToken cancellationToken);
    }
}
