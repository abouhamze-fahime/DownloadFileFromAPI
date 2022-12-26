using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ابزارهای مورد نیاز 
#region Ioc
builder.Services.AddControllers(options =>
{
    //options.OutputFormatters.Add();
    options.ReturnHttpNotAcceptable=false;
}).AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();//برای تشخیص نوع فایل پی دی اف است یا داکیومنت برای تایپهای فایلها استفاده می شود 
#endregion


var app = builder.Build();



// Configure the HTTP request pipeline.  چرخه حیات برنامه 
#region PipeLine
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // فعالش میکنم 
    app.UseSwaggerUI();//نمایش 
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

//app.MapControllers();//آدرس دهی کنترلها // domain/controller name / Action/ {id}

//اگر همه میدل ورها درخواست را نگرفتند و رسید به این خط  یک صفحه باز کن که پیدا نشد 
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello User");
//});
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();


#endregion



