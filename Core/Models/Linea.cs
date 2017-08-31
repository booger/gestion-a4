using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Linea
    {
        [Key]
        public long LineaID { get; set; }

        [Required]
        [StringLength(20)]
        public string LineaCodigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }


        [Required]
        public long GrupoID { get; set; }
        public Grupo Grupo { get; set; }

        public ICollection<Articulo> Articulos { get; set; }

        public Linea()
        {
            this.Articulos = new Collection<Articulo>();
        }
    }
}
