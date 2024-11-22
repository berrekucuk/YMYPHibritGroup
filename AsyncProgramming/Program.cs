// See https://aka.ms/new-console-template for more information
using AsyncProgramming;

Console.WriteLine("1.Satır");

var multiThread = new MultiThreadExample();

await multiThread.Example1();

Console.WriteLine("2.Satır");

Console.ReadLine();

//var httpClient = new HttpClient();

//var response = await httpClient.GetAsync("https://www.google.com");

//var responseAsText = await response.Content.ReadAsStringAsync();

//Console.WriteLine($"Data : {responseAsText}");


//var httpClient = new HttpClient();

//ContinueWith, .NET’te bir Task tamamlandıktan sonra çalıştırılacak yeni bir işlemi tanımlamak için kullanılır.Görevleri sıralı veya bağımsız şekilde zincirlemeyi sağlar.

//httpClient.GetAsync("https://www.google.com").ContinueWith(async responseMessage =>
//{
//    if (responseMessage.IsFaulted)
//    {
//        Console.WriteLine($"Hata var : {responseMessage.Exception.Message}");
//    }
//    else
//    {
//        Console.WriteLine("Data Başarılı alındı");

//        var response = responseMessage.Result;

//        var responseAsText = await response.Content.ReadAsStringAsync();

//        Console.WriteLine($"Data : {responseAsText}");
//    }
//});

//Console.WriteLine("2.Satır");

//Console.ReadLine();

//sync programming
//UI thread or Main thread
var helper = new Helper();
// thread blocking
//helper.GetFullName("ahmet", "yıldız");


//async programming


var serviceHelper = new ServiceHelper();

await serviceHelper.MakeLogging5("message 1");

//concurrent programming

//multi-threading
//parallel programming