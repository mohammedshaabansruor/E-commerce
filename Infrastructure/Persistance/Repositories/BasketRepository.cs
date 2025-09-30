using Domain.Contracts;
using Domain.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connectionMultiplexer) : IbasketRepository
    {
        public Task<CustomerBasket> DeleteBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> GetBasketAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket?> UpdateBasket(CustomerBasket basket, TimeSpan? timeSpan = null)
        {
            throw new NotImplementedException();
        }
    }
}
