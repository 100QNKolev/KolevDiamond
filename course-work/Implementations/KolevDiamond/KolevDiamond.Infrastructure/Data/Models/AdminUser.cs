using KolevDiamond.Infrastructure.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static KolevDiamond.Infrastructure.Constants.DataConstants;

namespace KolevDiamond.Infrastructure.Data.Models
{
    [Comment("Admin user details")]
    public static class AdminUser
    {
        [Comment("Role name for administrator")]
        public const string AdminRoleName = "Administrator";

        [Comment("Administrator's email")]
        public const string AdminEmail = "admin@gmail.com";
    }
}
