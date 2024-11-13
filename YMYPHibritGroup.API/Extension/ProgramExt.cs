using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using YMYPHibritGroup.API.Filters;
using YMYPHibritGroup.API.Model.Repositories;
using YMYPHibritGroup.API.Model.Services;

namespace YMYPHibritGroup.API.Extension
{
    public static class ProgramExt
    {
        public static void AddServiceAndRepositoryAndFilterExt(this IServiceCollection services)
        {
            //AddScoped : Request, response dönüşünceye kadar aynı nesne örneğini kullanır.
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<NotFoundProductFilter>();
        }

        public static void AddSwaggeExt(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public static void AddMvcExt(this IServiceCollection services)
        {
            services.AddMvc(opt => {

                //add global filter
                //opt.Filters.Add<MyResourceFilter>(); //Filterları burada tanımlarsak tüm enpointler için geçerlidir.

                opt.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            }); //C# kendi hata kodunu kapatmayı ve sadece Fluent Validation çalışmasını sağlar.

            services.AddControllers();
        }

        public static void AddValidationExt(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
