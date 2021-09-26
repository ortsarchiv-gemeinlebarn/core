using oag.Core.Data.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace oag.Core.Data.Models
{
    public class Version : BaseModel, IHasId
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        public Item Item { get; set; }
    }
}
