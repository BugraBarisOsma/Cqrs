using Cqrs.CQRS.Handlers;
using Cqrs.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
//serviceler burada builder icinden cekilecek sekilde olmali 

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddDbContext<StudentContext>(opt =>
opt.UseSqlServer("Server=sara; Database=StudentDb; User Id=sa; Password=1; TrustServerCertificate=True"));



//AddScoped bir hizmet (service) yaþam döngüsü belirleyicisidir ve ASP.NET Core uygulamalarýnda hizmetleri kaydetmek için kullanýlan bir yöntemdir.
//AddScoped metodu, hizmetin baðlamasý (scoped) olarak kaydedilmesini saðlar.
//Baðlamalý (scoped) hizmetler, genellikle HTTP isteði boyunca ayný örneklerin paylaþýlmasýný saðlar.
//Yani ayný HTTP isteði içerisinde ayný hizmet birden fazla kez çaðrýldýðýnda, ayný örnek geri döner.
//Ancak farklý HTTP istekleri arasýnda farklý örnekler oluþturulur.
//Örneðin, UpdateStudentCommandHandler gibi bir sýnýf AddScoped ile kaydedildiðinde,
//bu sýnýfýn her HTTP isteði için bir kere oluþturulup ayný istek içinde tekrar çaðrýldýðýnda ayný örneðin kullanýlmasýný saðlar.
//Bu, genellikle baðlamalý (scoped) hizmetlerin kullanýcý isteðinin kapsamý boyunca ayný veri durumu ve özellikleri paylaþmasý gereken senaryolarda faydalý olur.
//Bu nedenle, UpdateStudentCommandHandler'ýn AddScoped olarak kaydedilmesi,
//bu iþleve baðlamalý hizmet yaþam döngüsü atanýr ve genellikle HTTP isteði süresince ayný örneðin kullanýlmasýný saðlar.

//Son olarak MediatR kullanacagimiz icin artik her servisi tek tek scope'a eklememize gerek kalmadi onlari yorum satirina
// aliyoruz. Sadece MediatR olacak 
builder.Services.AddMediatR(typeof(Program));

//builder.Services.AddScoped<GetStudentByIdQueryHandler>();
//builder.Services.AddScoped<GetStudentsQueryHandler>();
//builder.Services.AddScoped<CreateStudentCommandHandler>();
//builder.Services.AddScoped<RemoveStudentCommandHandler>();
//builder.Services.AddScoped<UpdateStudentCommandHandler>();

var app = builder.Build();

//appler burada olacak 
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
