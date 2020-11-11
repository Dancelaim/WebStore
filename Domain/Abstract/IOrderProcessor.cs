using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WowCarry.Domain.Entities;

namespace WowCarry.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, OrderDetails orderDetails);
    }
}