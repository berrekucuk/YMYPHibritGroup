namespace YMYPHibritGroup.API.Extension
{
    public static class MidlewareExt
    {
        public static void CheckWhiteIpAddressList(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                //check ip address
                var whiteIpList = new List<string>() { "192.168.1.1", "::1" };

                var requestIpAddress = context.Connection.RemoteIpAddress!.ToString();

                if (!whiteIpList.Contains(requestIpAddress))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.WriteAsync("You are not authorized to access this resource");
                    return;
                }

                await next();

                //if (!whiteIpList.Contains(requestIpAddress))
                //{
                //    context.Response.StatusCode = 403;
                //    await context.Response.WriteAsync("You are not authorized to access this resource");
                //}
                //else
                //{
                //    await next();
                //}
            });
        }
        

        public static void ExapleMiddlewares(this WebApplication app)
        {
            #region Middleware Example

            app.Use(async (context, next) =>
            {
                Console.WriteLine("1.middleware request");
                var request = context.Request;

                await next();

                Console.WriteLine("1.middleware response");

                var response = context.Response;
            });

            app.Use(async (context, next) =>
            {
                Console.WriteLine("2.middleware request");
                var request = context.Request;

                await next();

                Console.WriteLine("2.middleware response");

                var response = context.Response;
            });

            //Şartlı middleware için app.map kullanıyoruz.Hiçbir kurala uymayan enpointler için de kullanılabilir.
            app.Map("/GetLoggingList", (app) =>
            {
                app.Run(async (context) =>
                {
                    Console.WriteLine("Terminal middleware");

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "LoggingList.txt");

                    var logs = System.IO.File.ReadAllLines(path);

                    context.Response.StatusCode = 200;

                    await context.Response.WriteAsJsonAsync(logs);
                });

                //app.Use(async (context, next) =>
                //{
                //    Console.WriteLine("3.middleware request");
                //    var request = context.Request;

                //    await next();

                //    Console.WriteLine("3.middleware response");

                //    var response = context.Response;
                //});

                //app.Run(async (context) =>
                //{
                //    Console.WriteLine("Terminal middleware");

                //    context.Response.StatusCode = 200;
                //    await context.Response.WriteAsync("Terminal Middleware");

                //    //context.Response.WriteAsJsonAsync(new { data = new List<string>() { "ahmet", "" }});
                //});
            });


            #endregion
        }

        public static void AddCommonMiddleware(this WebApplication app)
        {
            //app.ExapleMiddlewares();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.CheckWhiteIpAddressList();

            app.UseHttpsRedirection();

            app.UseAuthorization();
        }
    }
}
