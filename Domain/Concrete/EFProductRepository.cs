using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WowCarry.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        WowCarryEntities context = new WowCarryEntities();
        public IEnumerable<Product> Products => context.Product;
    }
}
