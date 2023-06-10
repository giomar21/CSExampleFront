using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Example.Common.Models
{
    /// <summary>
    /// Modelo con propiedades de un Usuario
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Id del usuario
        /// </summary>
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido paterno
        /// </summary>
        [DisplayName("Apellido Paterno")]
        public string ApellidoPaterno { get; set; }

        /// <summary>
        /// Apellido materno
        /// </summary>
        [DisplayName("Apellido Materno")]
        public string? ApellidoMaterno { get; set; }

        /// <summary>
        /// Salario
        /// </summary>
        public decimal? Salario { get; set; }

        /// <summary>
        /// CURP del usuario
        /// </summary>
        [DisplayName("CURP")]
        public string Curp { get; set; }

        /// <summary>
        /// Teléfono
        /// </summary>
        [DisplayName("Teléfono")]
        public string? Telefono { get; set; }

        /// <summary>
        /// Fecha de creación
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Fecha de actualización
        /// </summary>
        public DateTime? FechaActualizacion { get; set; }

        /// <summary>
        /// Activo
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Devuelve el nombre completo
        /// </summary>
        public string NombreCompleto { get; set; }
    }
}
