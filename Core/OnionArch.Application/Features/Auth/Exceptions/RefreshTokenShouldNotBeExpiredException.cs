using OnionArch.Application.Bases;

namespace OnionArch.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum açma süresi sona ermiştir.Lütfen tekrar giriş yapın.") { }
    }
}
