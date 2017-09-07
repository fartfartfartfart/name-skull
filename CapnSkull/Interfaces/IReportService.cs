using CapnSkull.Models;
using System.Collections.Generic;

namespace CapnSkull.Interfaces
{
    public interface IReportService
    {
        Report GetReport(Person person);
        NameSection GetNameSection(string name, string title);
        string GetFirstLetterInfo(string name);
        string GetFirstVowelInfo(string name);
        IDictionary<char, string> GetMiddleLettersInfo(string name);
        string GetLastLetterInfo(string name);
        bool IsVowel(char c);
        string GetFirstVowel(string name);
    }
}
