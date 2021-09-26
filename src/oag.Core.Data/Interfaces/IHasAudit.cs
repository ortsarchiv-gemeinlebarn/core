using System;

namespace oag.Core.Data.Interfaces
{
    public interface IHasAudit
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}