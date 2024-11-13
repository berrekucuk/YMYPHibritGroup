// See https://aka.ms/new-console-template for more information
using AsyncProgramming;

Console.WriteLine("Hello, World!");

//sync programming
//UI thread or Main thread

var helper = new Helper();

//thread blocking
helper.GetFullName("ahmet", "yıldız");


//async programming

var serviceHelper = new ServiceHelper();

var result = await serviceHelper.MakeRequestToGoogle();



//concurrent programming

//multi-threading
//parallel programming
