using MediatR;
using OnionArch.Application.Interfaces.RedisCache;

namespace OnionArch.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>, ICacheableQuery
    {
        public string CacheKey => ("GetAllProducts");

        public double CacheTime => 60;
    }
}
