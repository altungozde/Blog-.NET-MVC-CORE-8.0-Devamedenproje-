#nullable disable

using Core.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class RoleModel : Record
    {
        #region

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        #endregion
    }
}
