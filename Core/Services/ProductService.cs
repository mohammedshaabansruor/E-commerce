using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Services.Specifications;
using Services_Abstraction;
using Shared;
using Shared.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService(IUniteOfWork _UniteOfWork, IMapper _mapper) : IProductService
    {
      
        public async Task<IEnumerable<BrandRsult_DTO>> GetAllBrandAsync()
        {

            // 1- retrieve for all brands ==> Unite of work
            // 2- Mapping to BrandResult_DTO ==> IMapper
            // 3- Return  
            var brand = await _UniteOfWork.GetRepository<Product, int>().GetAllAsync();
            var brandresult = _mapper.Map<IEnumerable<BrandRsult_DTO>>(brand);
            return brandresult;
        }

        public async Task<PaginatedResult<ProductResult_DTO>> GetAllProductAsync(ProductParameterSpecifications parameters)
        {
            var products = await _UniteOfWork.GetRepository<Product, int>().GetAllAsync(new ProductWithBrandAndTypeSpecifcations(parameters));
            var totalcount = await _UniteOfWork.GetRepository<Product, int>().CountAsync(new ProductsCountSpecifications (parameters));
            var productsresult = _mapper.Map<IEnumerable<ProductResult_DTO>>(products);
            // return productsresult;
            var result = new PaginatedResult<ProductResult_DTO>(
                parameters.PageSize ,
                parameters.PageIndex,
                totalcount ,
                productsresult
                );
                return result;
        }

        public async Task<ProductResult_DTO> GetProductByIdAsync(int id)
        {
            var product = await _UniteOfWork.GetRepository<Product, int>().GetByIdAsync(new ProductWithBrandAndTypeSpecifcations(id));
            //var productresult = _mapper.Map<ProductResult_DTO>(product);
            //return productresult;
             return product is null ? throw new ProuctNotFoundException(id): _mapper.Map<ProductResult_DTO>(product);
        }

        public async Task<IEnumerable<TypeResult_DTO>> GetAllTypeAsync()
        {
            // 1- retrieve for all Product ==> Unite of work
            //    // 2- Mapping to ProductResult_DTO ==> IMapper
            //    // 3- Return 
            var type = await _UniteOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typeresult = _mapper.Map<IEnumerable<TypeResult_DTO>>(type);
            return typeresult;
        }
    }
}
