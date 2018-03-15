using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Edu.Infrastructure.Common
{
    /// <summary>
    /// Beisen Cloud 有，目前不再使用
    /// </summary>
    public class Arguments
    {
        public static ArgumentException Positive(int value, string paramName)
        {
            return value > 0
                ? null
                : new ArgumentException("参数必须大于零", paramName);
        }
        public static ArgumentException Positive(decimal value, string paramName)
        {
            return value > 0
                ? null
                : new ArgumentException("参数必须大于零", paramName);
        }
        public static ArgumentException NotNull<T>(T value, string paramName)
            where T : class
        {
            return value != null
                ? null
                : new ArgumentNullException(paramName, "参数不能为null");
        }

        public static ArgumentException NotEmpty(string value, string paramName)
        {
            return ArgumentHelper.Combine(
                () => NotNull(value, paramName),
                () => value.Length > 0
                    ? null
                    : new ArgumentException("参数必须为非空字符串", paramName)
            ).FirstOrDefault(ex => ex != null);
        }

        public static ArgumentException NotEmptyOrWhitespace(string value, string paramName)
        {
            return ArgumentHelper.Combine(
                () => NotEmpty(value, paramName),
                () => value.Trim(' ').Length > 0
                    ? null
                    : new ArgumentException("参数字符串必须包含非空白字符", paramName)
            ).FirstOrDefault(ex => ex != null);
        }

        public static ArgumentException NotEmpty<T>(T[] value, string paramName)
        {
            return ArgumentHelper.Combine(
                () => NotNull(value, paramName),
                () => value.Length > 0
                    ? null
                    : new ArgumentException("参数不能为空数组", paramName)
            ).FirstOrDefault(ex => ex != null);
        }

        public static Func<string, string, ArgumentException> MinLength(int length)
        {
            ArgumentHelper.Require(length, "length", Arguments.Minimum(0));

            return (value, paramName) =>
            {
                return ArgumentHelper.Combine(
                    () => NotNull(value, paramName),
                    () => value.Length >= length
                        ? null
                        : new ArgumentException("参数字符串的长度必须大于或等于" + length, paramName)
                ).FirstOrDefault(ex => ex != null);
            };
        }

        public static Func<string, string, ArgumentException> MaxLength(int length)
        {
            ArgumentHelper.Require(length, "length", Arguments.Minimum(0));

            return (value, paramName) =>
            {
                return ArgumentHelper.Combine(
                    () => NotNull(value, paramName),
                    () => value.Length <= length
                        ? null
                        : new ArgumentException("参数字符串的长度必须小于或等于" + length, paramName)
                ).FirstOrDefault(ex => ex != null);
            };
        }

        public static Func<int, string, ArgumentException> Minimum(int minimum)
        {
            return (value, paramName) =>
            {
                return value >= minimum
                    ? null
                    : new ArgumentException("参数数值必须大于或等于" + minimum, paramName);
            };
        }

        public static Func<int, string, ArgumentException> Maximum(int maximum)
        {
            return (value, paramName) =>
            {
                return value <= maximum
                    ? null
                    : new ArgumentException("参数数值必须小于或等于" + maximum, paramName);
            };
        }
    }

    public static class ArgumentHelper
    {
        [DebuggerStepThrough]
        public static void Require<T>(T value,
            string paramName, params Func<T, string, ArgumentException>[] guards)
        {
            ArgumentException ex;
            foreach (var guard in guards)
            {
                ex = guard(value, paramName);
                if (ex != null)
                {
                    throw ex;
                }
            }
        }

        [DebuggerStepThrough]
        public static IEnumerable<T> Combine<T>(params Func<T>[] producers)
        {
            foreach (var produce in producers)
            {
                yield return produce();
            }
        }

        [DebuggerStepThrough]
        public static Func<T, string, TException> Combine<T, TException>(params Func<T, string, TException>[] guards)
            where TException : ArgumentException
        {
            return (paramValue, paramName) =>
            {
                TException ex = null;
                foreach (var guard in guards)
                {
                    ex = guard(paramValue, paramName);
                    if (ex != null)
                        break;
                }
                return ex;
            };
        }
    }
}
