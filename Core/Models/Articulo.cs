using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Articulo
    {
        [Key]
        public long ArticuloID { get; set; }
        
        [Required]
        [StringLength(20)]
        public string ArticuloCodigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        [StringLength(50)]
        public string CodBarraOriginal { get; set; }

        [StringLength(50)]
        public string CodBarraGenerado { get; set; }

        [Required]
        public decimal ImpuestosInternos { get; set; }

        [Required]
        public decimal Costo { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public bool ControlaStock { get; set; }


        [Required]
        public decimal PuntoDePedido { get; set; }

        [Required]
        public decimal TamanoLotePedido { get; set; }

        [Required]
        public decimal StockMaximo { get; set; }

        [Required]
        public decimal StockMinimo { get; set; }


        [Required]
        public long LineaID { get; set; }
        public Linea Linea { get; set; }

        [Required]
        public long MarcaID { get; set; }
        public Marca Marca { get; set; }

        public ICollection<Stock> Stocks { get; set; }

        public Articulo()
        {
            this.Stocks = new Collection<Stock>();
        }
    }
}
