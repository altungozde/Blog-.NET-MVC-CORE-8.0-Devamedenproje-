#nullable disable

using Core.Records.Bases;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Entities
{
    public class BlogTag : Record
    {
        [Key]
        [Column(Order = 0)]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        [Key]
        [Column(Order = 1)]
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
