using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowCarry.Domain.Abstract;
using WowCarry.Domain.Entities;

namespace WowCarry.Domain.Concrete
{
    public class EFGameRepository : IGameRepository
    {
        WowCarryEntities context = new WowCarryEntities();
        public IEnumerable<ProductGame> Games => context.ProductGame;
    }
}
