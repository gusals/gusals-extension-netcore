using System;
using System.Runtime.InteropServices;

namespace Gusals.Extensions
{
    /// <summary>
    /// Guid 확장 클래스.
    /// </summary>
    public static class GuidExtensions
    {
        private static GuidConverter _converter;

        [StructLayout(LayoutKind.Explicit)]
        private struct GuidConverter
        {
            [FieldOffset(0)]
            public Guid Guid;
            [FieldOffset(0)]
            public long Long1;
            [FieldOffset(8)]
            public long Long2;
            [FieldOffset(0)]
            public int Int1;
            [FieldOffset(4)]
            public int Int2;
            [FieldOffset(8)]
            public int Int3;
            [FieldOffset(12)]
            public int Int4;
        }

        /// <summary>
        /// Long(1, 2)를 Guid로 변환.
        /// </summary>
        /// <param name="long1">변환할 Long1.</param>
        /// <param name="long2">변환할 Long2.</param>
        /// <returns><see cref="Guid"/></returns>
        public static Guid FromLongs(long long1, long long2)
        {
            _converter.Long1 = long1;
            _converter.Long2 = long2;
            return _converter.Guid;
        }

        /// <summary>
        /// Guid을 Long으로 변환.
        /// </summary>
        /// <param name="guid">변환할 Guid.</param>
        /// <returns><see cref="long"/></returns>
        public static long ToLong(this Guid guid)
        {
            _converter.Guid = guid;
            return _converter.Long1;
        }

        /// <summary>
        /// Guid를 Long(1, 2)로 변환.
        /// </summary>
        /// <param name="guid">변환할 Guid.</param>
        /// <returns><see cref="Tuple{T1, T2}"/></returns>
        public static (long long1, long long2) ToLongs(this Guid guid)
        {
            _converter.Guid = guid;
            return (_converter.Long1, _converter.Long2);
        }
    }
}