using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ProuctNotFoundException : NotFoundException
    {
        public ProuctNotFoundException(int id) : base($"product with id : {id} not found ")
        {
        }
    }
}
