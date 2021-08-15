using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using SistemaWebVuelos.Validations;

namespace SistemaWebVuelos.Models
{
    [Table("Vuelo")]
    public class Vuelo
    {
        [Key]
        public int idVuelo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "Date")]
        [CheckValidFecha]
        public DateTime Fecha { get; set; }
        [StringLength(50)]
        [Required]
        public string Destino { get; set; }
        [StringLength(50)]
        [Required]
        public string Origen { get; set; }
        [StringLength(50)]
        [Index(IsUnique = true)]
        [Required]
        public string Matricula { get; set; }
    }
}