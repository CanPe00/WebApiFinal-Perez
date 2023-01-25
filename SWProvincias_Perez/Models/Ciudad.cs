using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SWProvincias_Perez.Models
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }
        public Provincia Provincia { get; set; }
        [ForeignKey(nameof(Provincia))]
        public int ProvinciaId { get; set; }
    }
}
