using Domain.Contracts;
using Domain.Entities;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    public class ProductsCountSpecifications: Specifcation<Product>
    {
        public ProductsCountSpecifications(ProductParameterSpecifications parameters)
           : base(product =>
           (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value)
           &&
           (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value)
           && (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {

        }
    }
}
