using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entitites.DTOs
{
    public  class ProductDetailDto : IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoyName { get; set; }
        public short UnitsInStock { get; set; }

    }
}
