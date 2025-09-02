using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5API.Domain.DTO
{
    public class PermissionCreateDTO
    {
        public int Id { get; set; }
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public int PermissionId { get; set; }
        public DateTime Date { get; set; }

        public PermissionCreateDTO(PermissionDTO _permission)
        {
            Id = _permission.Id;
            ForeName = _permission.ForeName;
            SurName = _permission.SurName;
            PermissionId = _permission.PermissionId;
            Date = _permission.Date;
        }
    }

    public class PermissionModifyDTO
    {
        public int Id { get; set; }
        public string ForeName { get; set; }
        public string SurName { get; set; }
        public int PermissionId { get; set; }
        public DateTime Date { get; set; }

        public PermissionModifyDTO(PermissionDTO _permission)
        {
            Id = _permission.Id;
            ForeName = _permission.ForeName;
            SurName = _permission.SurName;
            PermissionId = _permission.PermissionId;
            Date = _permission.Date;
        }
    }
}
