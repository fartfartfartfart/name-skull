using CapnSkull.Interfaces;
using CapnSkull.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CapnSkull.Services
{
    public class SequenceRepository : ISequenceRepository
    {
        public Sequence GetSequenceByCharacters(string characters)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Sequences.Where(x => x.Characters.Equals(characters.Trim())).FirstOrDefault();
            }
        }

        public IEnumerable<Sequence> GetCharSequences()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Sequences.Where(x => x.Characters.Length == 1);
            }
        }

        public IEnumerable<Sequence> Get()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Sequences.ToList();
            }            
        }

        public Sequence Find(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Sequences.Find(id);
            }
        }

        public void Add(Sequence sequence)
        {
            using (var db = new ApplicationDbContext())
            {
                sequence.Characters = sequence.Characters.ToLower().Trim();
                db.Sequences.Add(sequence);
                db.SaveChanges();
            }
        }

        public void Update(Sequence sequence)
        {
            using (var db = new ApplicationDbContext())
            {
                sequence.Characters = sequence.Characters.ToLower().Trim();
                db.Entry(sequence).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Remove(Sequence sequence)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Sequences.Remove(sequence);
                db.SaveChanges();
            }
        }
    }
}
