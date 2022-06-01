using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        /// <summary>
        /// Para la PK entity framework lo identifica con el nombre de la clase seguido de Id
        /// </summary>
        public string OrderId { get; set; }
        public Client? Client { get; set; }
        public decimal Iva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
