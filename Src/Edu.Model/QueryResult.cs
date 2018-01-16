using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Edu.Model
{
    /// <summary>
    /// 结果集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable, DataContract]
    public class QueryResult<T>
    {
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public int Code { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public List<T> Items { get; set; }
    }
    /// <summary>
    /// 结果处理类
    /// </summary>
    public sealed class QueryResult
    {
        public static QueryResult<T> Success<T>(
            List<T> items, int? total = null, string message = null)
        {
            return new QueryResult<T>
            {
                Code = 200,
                Message = message ?? "操作成功",
                Total = total ?? items.Count,
                Items = items,
            };
        }
        public static QueryResult<T> Failure<T>(string message = null)
        {
            return new QueryResult<T>
            {
                Code = 500,
                Message = message ?? "操作失败",
                Total = 0,
                Items = new List<T>(),
            };
        }
    }
}
