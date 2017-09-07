using System.Collections.Generic;

namespace CapnSkull.Models
{
    public class SequenceIndexViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<Sequence> Sequences { get; set; }
    }
}