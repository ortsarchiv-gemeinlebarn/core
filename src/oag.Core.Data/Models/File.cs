using oag.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oag.Core.Data.Models
{
    public class File : BaseModel, IHasId, IHasNumericSignature
    {
        public Guid Id { get; set; }

        public Guid FondsId { get; set; }

        public Fonds Fonds { get; set; }

        public int NumericSignature { get; set; }

        [StringLength(120)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Calc Dating from Items Dates?

        public Topic Topic { get; set; }

        public IEnumerable<Item> Items { get; set; }
    }
}
