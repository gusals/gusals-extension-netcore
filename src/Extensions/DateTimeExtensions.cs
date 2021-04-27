using System;

namespace Gusals.Extensions
{
    /// <summary>
    /// DateTime 확장 클래스.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// DateTime을 UnixTimestamp로 변경.
        /// </summary>
        /// <param name="dateTime">변경할 DateTime.</param>
        /// <returns><see cref="double"/></returns>
        public static double ToUnixTimestamp(this DateTime dateTime)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = dateTime - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        /// <summary>
        /// UnixTimestamp를 DateTime으로 변경.
        /// </summary>
        /// <param name="unixTimeStamp">유닉스 시간.</param>
        /// <returns><see cref="DateTime"/></returns>
        public static DateTime ToDateTime(this double unixTimeStamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(unixTimeStamp).ToLocalTime();
        }
    }
}