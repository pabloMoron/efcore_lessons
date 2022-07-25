using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OrderDetail
    {
        public int OrderDetailId { get; private set; }
        public Product Product { get; private set; }
        public Order Order { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Iva { get; private set; }
        public decimal SubTotal { get; private set; }
        public decimal Total { get; private set; }
    }
}
