using MediatR;

namespace OnionArch.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; }
    }
}
