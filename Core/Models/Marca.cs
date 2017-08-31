using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Marca
    {
        [Key]
        public long MarcaID { get; set; }

        [Required]
        [StringLength(20)]
        public string MarcaCodigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public ICollection<Articulo> Articulos { get; set; }

        public Marca()
        {
            this.Articulos = new Collection<Articulo>();
        }
    }
}
