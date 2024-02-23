using MediatR;

namespace OnionArch.Application.Features.Products.Command.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
