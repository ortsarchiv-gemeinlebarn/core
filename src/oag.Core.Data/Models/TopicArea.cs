using System;
using System.ComponentModel.DataAnnotations;
using oag.Core.Data.Interfaces;

namespace oag.Core.Data.Models
{
    public class TopicArea : BaseModel, IHasId
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Label { get; set; }

        public int SortIndex { get; set; } = 100;
    }
}
