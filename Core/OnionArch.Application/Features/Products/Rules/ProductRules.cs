using OnionArch.Application.Bases;
using OnionArch.Application.Features.Products.Exceptions;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Features.Products.Rules
{
    public class ProductRules : BaseRules
    {
        public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
        {
            if (products.Any(p => p.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
            return Task.CompletedTask;
        }
    }
}