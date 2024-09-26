#nullable disable

using Core.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class UserModel : Record
    {
        #region Entitiy den alınan özellikler

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public int RoleId { get; set; }

        #endregion
    }
}
