using System;
using System.ComponentModel;

namespace Gusals.Extensions
{
    /// <summary>
    /// Enum 확장 클래스.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Enum의 Description 가져오기.
        /// </summary>
        /// <param name="enum">Enum.</param>
        /// <returns><see cref="string"/></returns>
        public static string GetDescription(this Enum @enum)
        {
            if (@enum == default)
                return string.Empty;
            var attribute = @enum.GetAttribute<DescriptionAttribute>();
            return attribute == default ? @enum.ToString() : attribute.Description;
        }

        /// <summary>
        /// Enum을 Array로 변환.
        /// </summary>
        /// <param name="enum">변환할 Enum.</param>
        /// <returns><see cref="Array"/></returns>
        public static string[] ToArray(this Enum @enum) => @enum.ToString().Split(", ");

        /// <summary>
        /// String을 Enum으로 변환.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">변환할 string.</param>
        /// <returns><see cref="Enum"/></returns>
        public static T ToEnum<T>(this string value) => (T)Enum.Parse(typeof(T), value);

        private static T? GetAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == default)
                return default;

            var member = value.GetType().GetMember(value.ToString());
            var attributes = member[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }
    }
}