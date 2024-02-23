using OnionArch.Application.Bases;

namespace OnionArch.Application.Features.Products.Exceptions
{
    public class ProductTitleMustNotBeSameException : BaseExceptions
    {
        public ProductTitleMustNotBeSameException() : base("Ürün başlığı zaten var !") { }
    }
}