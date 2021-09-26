using oag.Core.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace oag.Core.Data.Models
{
    public class Fonds : BaseModel, IHasId, IHasSignature
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        public string Signature { get; set; }

        [Required]
        [MinLength(1)]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
