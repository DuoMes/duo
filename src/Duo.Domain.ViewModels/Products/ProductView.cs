using System;

namespace Duo.Domain.ViewModels.Products
{
    public class ProductView
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Thickness { get; set; }
    }
}
