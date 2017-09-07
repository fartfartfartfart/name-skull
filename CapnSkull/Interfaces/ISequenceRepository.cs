using CapnSkull.Models;
using System.Collections.Generic;

namespace CapnSkull.Interfaces
{
    public interface ISequenceRepository
    {
        IEnumerable<Sequence> Get();
        Sequence GetSequenceByCharacters(string characters);
        IEnumerable<Sequence> GetCharSequences();
        Sequence Find(int id);
        void Add(Sequence sequence);
        void Update(Sequence sequence);
        void Remove(Sequence sequence);
    }
}
