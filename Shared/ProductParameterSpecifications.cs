using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductParameterSpecifications
    {
        public ProductSortOption? sort { get; set; }
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Search { get; set; }
        public int PageIndex { get; set; } = 1;
        private const int MaxpageSize = 10;
        private const int DefaultPageSize = 5;
        private int _pageSize = DefaultPageSize ;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxpageSize ? MaxpageSize:value ;
        }

    }
    public enum ProductSortOption
    {
        NameAsc, NameDesc , PriceAsc , PriceDesc
    }
}
