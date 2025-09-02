using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N5API.Domain.Entities
{
    public class Permission
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("NombreEmpleado")]
        public string ForeName { get; set; }
        [Column("ApellidoEmpleado")]
        public string SurName { get; set; }
        [Column("TipoPermiso")]
        public int PermissionId { get; set; }
        [Column("FechaPermiso")]
        public  DateTime Date { get; set; }
        public virtual PermissionType? PermissionType { get; set; }
    }
}
