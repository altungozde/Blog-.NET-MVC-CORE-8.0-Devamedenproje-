#nullable disable

using Core.Records.Bases;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class BlogModel : Record
    {
        #region Entitiy den alınan özellikler
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [Required]
        [StringLength(350)]
        public string Content { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        [Range(1, 5)]
        public byte? Score { get; set; }

        [DisplayName("User")]
        [Required]
        public int UserId { get; set; }

        #endregion

        #region View gösterim ve veri girişi için
        [DisplayName("Create Date")]
        public string CreateDateDisplay { get; set; }

        [DisplayName("Update Date")]
        public string UpdateDateDisplay { get; set; }

        [DisplayName("User")]
        public string UserNameDisplay { get; set; }

        [DisplayName("Tags")]
        public string TagsDisplay { get; set; }

        [DisplayName("Tags")]
        public List<int> TagIds { get; set; }

        #endregion
    }
}
