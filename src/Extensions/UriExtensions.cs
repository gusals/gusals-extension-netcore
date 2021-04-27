using System.Text;
using System.Text.RegularExpressions;

namespace Gusals.Extensions
{
    /// <summary>
    /// Uri 확장 클래스.
    /// </summary>
    public static class UriExtensions
    {
        /// <summary>
        /// Slug 생성.
        /// </summary>
        /// <param name="phrase">Slug 생성할 구문.</param>
        /// <returns><see cref="string"/></returns>
        public static string GenerateSlug(this string phrase)
        {
            var str = phrase.RemoveAccent().ToLower();
            str = Regex.Replace(str, @"[^a-z0-9\s-]", string.Empty);
            str = Regex.Replace(str, @"\s+", " ").Trim();
            str = str.Substring(0, str.Length <= 75 ? str.Length : 75).Trim();
            str = Regex.Replace(str, @"\s", "-");
            return str;
        }

        /// <summary>
        /// Accent를 제거.
        /// </summary>
        /// <param name="phrase">Accent를 제거할 구문.</param>
        /// <returns><see cref="string"/></returns>
        public static string RemoveAccent(this string phrase)
        {
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(phrase);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}