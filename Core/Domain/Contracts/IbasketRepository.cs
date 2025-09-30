using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IbasketRepository
    {
        // Get Basket
        Task<CustomerBasket> GetBasketAsync(string id);
        // Delete Basket 
        Task<CustomerBasket> DeleteBasketAsync(string id);
        // create Or Update Basket 
        Task<CustomerBasket?> UpdateBasket(CustomerBasket basket, TimeSpan? timeSpan = null);

    }
}
