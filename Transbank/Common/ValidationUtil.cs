using System;
using System.Collections.Generic;

namespace Transbank.Common
{
    public class ValidationUtil
    {
        public static void hasText(String value, String valueName)
        {
            if (String.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException($"'{valueName}' can't be null or white space");
        }
        public static void hasTextWithMaxLength(String value, int length, String valueName)
        {
            ValidationUtil.hasText(value, valueName);
            if (value.Length > length)
                throw new ArgumentOutOfRangeException($"'{valueName}' is too long, the maximum length is {length}");
        }
        public static void hasTextTrimWithMaxLength(String value, int length, String valueName)
        {
            ValidationUtil.hasText(value, valueName);
            if (value.Length > value.Trim().Length)
                throw new ArgumentOutOfRangeException($"'{valueName}' has spaces at the begining or the end");
            if (value.Length > length)
                throw new ArgumentOutOfRangeException($"'{valueName}' is too long, the maximum length is {length}");
        }
        public static void hasElements<T>(List<T> value, String valueName)
        {
            if (value == null || value.Count == 0)
                throw new ArgumentNullException($"list '{valueName}' can't be null or empty");
        }
    }
}
