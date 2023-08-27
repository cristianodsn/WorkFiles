using System;

namespace IoException.Entities.MyExceptions
{
    class ProductExceptions : ApplicationException
    {
        public ProductExceptions(string message) : base(message) { }
    }
}
