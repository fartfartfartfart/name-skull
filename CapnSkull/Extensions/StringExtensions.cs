namespace CapnSkull.Extensions
{
    public static class StringExtensions
    {
        public static char FirstVowel(this string str)
        {
            if (string.IsNullOrEmpty(str)) return ' ';
            foreach (var c in str.ToCharArray())
            {
                if (c.Equals('a') || c.Equals('e') || c.Equals('i') || c.Equals('o') || c.Equals('u')) return c;
            }
            return ' ';
        }

        public static char FirstLetter(this string str)
        {
            if (string.IsNullOrEmpty(str)) return ' ';
            return str[0];
        }

        public static char LastLetter(this string str)
        {
            if (string.IsNullOrEmpty(str)) return ' ';
            return str[str.Length - 1];
        }
    }
}

