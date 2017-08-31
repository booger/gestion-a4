using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class Grupo
    {
        [Key]
        public long GrupoID { get; set; }

        [Required]
        [StringLength(20)]
        public string GrupoCodigo { get; set; }

        [Required]
        [StringLength(255)]
        public string Descripcion { get; set; }

        public ICollection<Linea> Lineas { get; set; }

        public Grupo()
        {
            this.Lineas = new Collection<Linea>();
        }
    }
}
