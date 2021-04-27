namespace Gusals.Extensions
{
    /// <summary>
    /// String 확장 클래스.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// CamelCase.
        /// </summary>
        /// <param name="text">문자.</param>
        /// <returns><see cref="string"/></returns>
        public static string CamelCase(this string text) => char.ToLowerInvariant(text[0]) + text[1..];
    }
}