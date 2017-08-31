using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Stock
    {
        public long ArticuloID { get; set; }
        public Articulo Articulo { get; set; }

        public long DepositoID { get; set; }
        public Deposito Deposito { get; set; }


        [Required]
        public decimal Existencia { get; set; }

        [Required]
        public decimal Comprometido { get; set; }

        [Required]
        public decimal PedidoProv { get; set; }

        public Stock()
        {
        }
    }
}
