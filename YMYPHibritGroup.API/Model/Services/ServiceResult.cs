using System.Net;
using System.Text.Json.Serialization;

namespace YMYPHibritGroup.API.Model.Services
{

    //Anemic Model : Class sadece propertylerden meydana geliyorsa anemic model denir.

    //Rich Domain Model : Classların içerisinde propertylerin yanında method varsa rich domain model denir.(Bunu kullanmalıyız.)

    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        //JsonIgnore = Bir sınıfın belirli bir özelliğinin JSON serileştirme veya deserializasyon işlemi sırasında yoksayılmasını sağlar. 
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        [JsonIgnore] public bool IsSuccess => Errors is null && Errors?.Count == 0; //Sadece get'i olan bir property 
        [JsonIgnore] public bool IsFail => !IsSuccess;


        //Static factory Methods (sürekli newlememek için yazılan kod)
        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T> { Data = data, Status = status };
        }

        //Bu metod birden fazla hata mesajı için,
        public static ServiceResult<T> Failure(List<string> errors,HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = errors, Status = status };
        }

        //Tek bir hata mesajı için,
        public static ServiceResult<T> Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T> { Errors = [error], Status = status };
        }
    }


    // Update ve Delete void döndüğü için generic değer almayan bir sınıf düzenledik.
    public class ServiceResult
    {
        public List<string>? Errors { get; set; }

        [JsonIgnore] public bool IsSuccess => Errors is null || Errors?.Count == 0;
        [JsonIgnore] public bool IsFail => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult()
            {
                Status = status
            };
        }

        public static ServiceResult Failure(List<string> errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult { Errors = errors, Status = status };
        }

        public static ServiceResult Failure(string error, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                Errors = [error],
                Status = status
            };
        }
    }  

}
