using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace N5API.Domain.Entities
{
    public class PermissionType
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Descripcion")]
        public string Description { get; set; }

        public ICollection<Permission>? Permissions { get; set; }

    }
}
