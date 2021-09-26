using System;

namespace oag.Core.Data.Interfaces
{
    public interface IHasId
    {
        public Guid Id { get; set; }
    }
}