namespace SkvProject.Common
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string StripHtml(this string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }
    }
}
