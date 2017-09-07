using System.Collections.Generic;

namespace CapnSkull.Models
{
    public class NameSection
    {
        public NameSection()
        {
            MiddleLettersInfo = new Dictionary<char, string>();
        }

        public string Title { get; set; }
        public string Name { get; set; }
        public string FirstVowelInfo { get; set; }
        public string FirstLetterInfo { get; set; }
        public string LastLetterInfo { get; set; }
        public IDictionary<char, string> MiddleLettersInfo { get; set; }
    }
}