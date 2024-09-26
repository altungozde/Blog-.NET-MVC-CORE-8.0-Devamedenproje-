#nullable disable

using Core.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class TagModel : Record
    {
        #region Entitiy den alınan özellikler

        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        public bool IsPopular { get; set; }

        #endregion

        #region View gösterim ve veri girişi için

        [DisplayName("Is Popular")]
        public string IsPopularDisplay { get; set; }
        #endregion
    }
}
