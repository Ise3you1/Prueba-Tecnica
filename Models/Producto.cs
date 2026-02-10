using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_Tecnica.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Nombre { get; set; } = null!;

        [MaxLength(250)]
        public string? Descripcion { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int Stock { get; set; }

        // 🔹 Clave foránea
        [Required]
        public int ProveedorId { get; set; }

        // 🔹 Relación: un producto pertenece a un proveedor
        [ForeignKey("ProveedorId")]
        public Proveedor Proveedor { get; set; } = null!;
    }
}