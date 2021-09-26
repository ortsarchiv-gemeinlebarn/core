using System;

namespace oag.Core.Data.Models
{
    public class Item : BaseModel
    {
        public Guid Id { get; set; }

        public Guid FileId { get; set; }

        public File File { get; set; }

        #region Location
        public Double LocationX { get; set; }

        public Double LocationY { get; set; }

        public Double LocationRadius { get; set; }
        #endregion
    }
}
