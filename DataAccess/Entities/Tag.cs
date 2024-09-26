#nullable disable

using Core.Records.Bases;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Tag : Record
    {
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        public  bool IsPopular { get; set; }

        public List<BlogTag> BlogTags { get; set; }
    }
}
