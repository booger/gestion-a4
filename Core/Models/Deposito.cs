using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Deposito
    {
        [Key]
        public long DepositoID { get; set; }

        [Required]
        [StringLength(20)]
        public string DepositoCodigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [StringLength(20)]
        public string CodigoPostal { get; set; }

        [StringLength(200)]
        public string Domicilio { get; set; }

        [StringLength(100)]
        public string Telefonos { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public ICollection<Stock> Stocks { get; set; }

        public Deposito()
        {
            this.Stocks = new Collection<Stock>();
        }
    }
}
