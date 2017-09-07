using CapnSkull.Interfaces;
using CapnSkull.Models;
using System.Collections.Generic;
using System.Linq;

namespace CapnSkull.Services
{
    public class ReportService : IReportService
    {
        private ISequenceRepository _sequenceRepository;

        public ReportService(ISequenceRepository sequenceRepository)
        {
            _sequenceRepository = sequenceRepository;
        }

        public Report GetReport(Person person)
        {
            var firstName = person.FirstName.ToLower().Trim();

            var model = new Report()
            {
                Person = person,
                FirstNameReport = GetNameSection(person.FirstName, "First Name"),
                MiddleNameReport = GetNameSection(person.MiddleName, "Middle Name"),
                LastNameReport = GetNameSection(person.LastName, "Last Name"),
                NickanmeReport = GetNameSection(person.Nickname, "Nickname")
            };
            return model;
        }

        public NameSection GetNameSection(string name, string title)
        {
            var lowerName = name?.ToString().ToLower();
            return new NameSection
            {
                Name = name,
                Title = title,
                FirstLetterInfo = GetFirstLetterInfo(lowerName),
                FirstVowelInfo = GetFirstVowelInfo(lowerName),
                MiddleLettersInfo = GetMiddleLettersInfo(lowerName),
                LastLetterInfo = GetLastLetterInfo(lowerName)
            };
        }

        public string GetFirstLetterInfo(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;
            var firstLetter = name[0].ToString();
            var sequence = _sequenceRepository.GetSequenceByCharacters(firstLetter.ToLower());
            if (sequence != null)
            {
                var info = sequence.BeginningInfo;
                if (string.IsNullOrEmpty(info)) info = sequence.DefaultInfo;
                return info;
            } 
            return string.Empty;
        }

        public string GetFirstVowelInfo(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;

            var firstVowel = GetFirstVowel(name.ToLower());
            var sequence = _sequenceRepository.GetSequenceByCharacters(firstVowel);
            if (sequence != null)
            {
                var info = sequence.FirstVowelInfo;
                if (string.IsNullOrEmpty(info)) info = sequence.DefaultInfo;
                return info;
            }
            return string.Empty;
        }

        public IDictionary<char, string> GetMiddleLettersInfo(string name)
        {
            var model = new Dictionary<char, string>();
            var lowerName = name?.ToLower().Trim();

            if (string.IsNullOrEmpty(name)) return model;

            var firstVowel = GetFirstVowel(name);
            var firstLetter = lowerName[0].ToString();
            var lastLetter = lowerName[lowerName.Length - 1].ToString();

            for(int i = 1; i< lowerName.Length; i++)
            {
                var currentChar = lowerName[i];
                var charStr = currentChar.ToString();
                if (!charStr.Equals(firstVowel) && !charStr.Equals(lastLetter) && !charStr.Equals(firstLetter))
                {
                    var sequence = _sequenceRepository.GetSequenceByCharacters(charStr);
                    if (sequence != null)
                    {
                        var info = sequence.MiddleInfo;
                        if (string.IsNullOrEmpty(sequence.MiddleInfo)) info = sequence.DefaultInfo;
                        if (!model.Where(x => x.Key.Equals(currentChar)).Any())
                        {
                            model.Add(currentChar, info);
                        }
                    }
                }
            }
            return model;
        }

        public string GetLastLetterInfo(string name)
        {
            if (string.IsNullOrEmpty(name)) return string.Empty;

            var lastLetter = name[name.Length - 1].ToString();
            var sequence = _sequenceRepository.GetSequenceByCharacters(lastLetter.ToLower());

            if (sequence != null)
            {
                var info = sequence.EndInfo;
                if (string.IsNullOrEmpty(info)) info = sequence.DefaultInfo;
                return info;
            }
            return string.Empty;
        }

        public bool IsVowel(char c)
        {
            if (c.Equals('a') ||  c.Equals('e') ||  c.Equals('i') || c.Equals('o') || c.Equals('u') || c.Equals('y')) return true;
            return false;
        }

        public string GetFirstVowel(string name)
        {
            var lowerName = name.ToLower().Trim();
            foreach (var item in lowerName.ToArray())
            {
                if (IsVowel(item)) return item.ToString();
            }
            return string.Empty;
        }
    }
}