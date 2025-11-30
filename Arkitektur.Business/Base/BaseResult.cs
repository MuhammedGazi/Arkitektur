using System.Text.Json.Serialization;

namespace Arkitektur.Business.Base
{
    public class BaseResult<T>
    {
        public T? Data { get; set; }
        public IEnumerable<object> Errors { get; set; }

        [JsonIgnore]
        public bool IsSuccessful => Errors == null || !Errors.Any();

        [JsonIgnore]
        public bool IsFailure => !IsSuccessful;

        public static BaseResult<T> Success(T? data)
        {
            return new BaseResult<T> { Data = data };
        }
        public static BaseResult<T> Success()
        {
            return new BaseResult<T> {Errors=null};
        }

        public static BaseResult<T> Fail(string errorMessage)
        {
            return new BaseResult<T> { Errors = new[] { new { ErrorMessage = errorMessage } } };
        }
    }
}
