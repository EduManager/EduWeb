using System;
using System.Runtime.Serialization;

namespace Edu.Model
{
    [Serializable, DataContract]
    public class CommandResult
    {
        const int OK_CODE = 200;
        const int ERROR_CODE = 500;

        [DataMember(Name = "code")]
        public int Code { get; private set; }

        [DataMember(Name = "message")]
        public string Message { get; private set; }

        public bool Ok
        {
            get
            {
                return Code.ToString().StartsWith("2");
            }
        }

        #region Factory
        public static CommandResult Success(string message = null)
        {
            return new CommandResult() { Code = OK_CODE, Message = message ?? "操作成功" };
        }

        public static CommandResult<T> Success<T>(T data, string message = null, int code = OK_CODE)
        {
            return new CommandResult<T> { Data = data, Code = code, Message = message ?? "操作已成功" };
        }

        public static CommandResult Failure(string message = null, int code = ERROR_CODE)
        {
            return new CommandResult
            {
                Code = code,
                Message = message ?? "操作失败",
            };
        }

        public static CommandResult<T> Failure<T>(string message = null, int code = ERROR_CODE)
        {
            return new CommandResult<T>() { Code = code, Message = message ?? "操作失败" };
        }
        #endregion
    }

    [Serializable, DataContract]
    public class CommandResult<T> : CommandResult
    {
        [DataMember(Name = "data")]
        public T Data { get; set; }
    }
}
