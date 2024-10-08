using System.ComponentModel.DataAnnotations;

namespace YMYPHibritGroup.API.Model.Services.DTO
{

    public record AddProductRequest(string Name, decimal Price, int Stock);
    //Buradaki kod ile aşağıdaki kod aynıdır. İnit ve constructor özellikleride geçerlidir. Bu yöntemin adı Primary Constructor'dır. !! Bu yaklaşım sadece record için geçerlidir.




    //public record AddProductRequest
    //{
    //    //[StringLength(20,ErrorMessage ="isim alanı en fazla20 karakter olabilir")]
    //    //[Required(ErrorMessage ="isim alanı gereklidir")]
    //    public string Name { get; init; } = default!; 

    //    //float - double -decimal
    //    //[Range(1,double.MaxValue, ErrorMessage ="fiyat alanı 0'dan büyük olmalıdır")]
    //    public decimal Price { get; init; }

    //    //[Range(1,int.MaxValue,ErrorMessage ="stok alanı 0'dan büyük olmalıdır")]
    //    public int Stock { get; init; }

    //    public AddProductRequest(string name, decimal price, int stock)
    //    {
    //        Name = name;
    //        Price = price;
    //        Stock = stock;
    //    }

    //    //!!! NOT: set'i init yaptığımızda nesne örneği oluştuktan sonra propetylerinde değişiklik yapamayız.

    //    //!!! NOT: record => classlar yerine propertylere bakarak karşılaştıma yapmamızı sağlar.
    //}
}
