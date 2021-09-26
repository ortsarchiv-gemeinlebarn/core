using System;
using System.ComponentModel;

namespace oag.Core.ViewModels
{
    public class FondsView
    {
        [DisplayName("ID")]
        public Guid Id { get; set; }

        [DisplayName("Signature")]
        public string Signature { get; set; }

        [DisplayName("Long Name")]
        public string Name { get; set; }
    }
}
