using N5API.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace N5API.Infraestructure.Data.Seed
{
    public static class PermissionDataSeed
    {
        public static List<Permission> GetPermission()
        {
            return new List<Permission>
            {
                new Permission()
                {
                    Id = 1,
                    ForeName = "ForeName 1 ",
                    SurName = "SurName 1 ",
                    PermissionId = 1,
                    Date = DateTime.Now
                },
                new Permission()
                {
                    Id = 2,
                    ForeName = "ForeName 2 ",
                    SurName = "SurName 2 ",
                    PermissionId = 1,
                    Date = DateTime.Now
                },
                new Permission()
                {
                    Id = 3,
                    ForeName = "ForeName 3 ",
                    SurName = "SurName 3 ",
                    PermissionId = 2,
                    Date = DateTime.Now
                },
                new Permission()
                {
                    Id = 4,
                    ForeName = "ForeName 4 ",
                    SurName = "SurName 4 ",
                    PermissionId = 3,
                    Date = DateTime.Now
                }
            };
        }

        public static List<PermissionType> GetPermissionsType()
        {
            return new List<PermissionType>
            {
                new PermissionType(){Id = 1, Description = "Permission Type 1"},
                new PermissionType(){Id = 2, Description = "Permission Type 2"},
                new PermissionType(){Id = 3, Description = "Permission Type 3"}
            };
        }
    }
}
