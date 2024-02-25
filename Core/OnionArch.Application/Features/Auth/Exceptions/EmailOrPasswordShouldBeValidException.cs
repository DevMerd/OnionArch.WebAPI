using OnionArch.Application.Bases;

namespace OnionArch.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldBeValidException : BaseException
    {
        public EmailOrPasswordShouldBeValidException(): base("Böyle bir mail adresi bulunmamaktadır !") {}
    }
}
