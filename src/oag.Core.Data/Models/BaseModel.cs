using oag.Core.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace oag.Core.Data.Models
{
    public class BaseModel : IHasAudit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}