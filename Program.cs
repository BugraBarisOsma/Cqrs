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



//AddScoped bir hizmet (service) ya�am d�ng�s� belirleyicisidir ve ASP.NET Core uygulamalar�nda hizmetleri kaydetmek i�in kullan�lan bir y�ntemdir.
//AddScoped metodu, hizmetin ba�lamas� (scoped) olarak kaydedilmesini sa�lar.
//Ba�lamal� (scoped) hizmetler, genellikle HTTP iste�i boyunca ayn� �rneklerin payla��lmas�n� sa�lar.
//Yani ayn� HTTP iste�i i�erisinde ayn� hizmet birden fazla kez �a�r�ld���nda, ayn� �rnek geri d�ner.
//Ancak farkl� HTTP istekleri aras�nda farkl� �rnekler olu�turulur.
//�rne�in, UpdateStudentCommandHandler gibi bir s�n�f AddScoped ile kaydedildi�inde,
//bu s�n�f�n her HTTP iste�i i�in bir kere olu�turulup ayn� istek i�inde tekrar �a�r�ld���nda ayn� �rne�in kullan�lmas�n� sa�lar.
//Bu, genellikle ba�lamal� (scoped) hizmetlerin kullan�c� iste�inin kapsam� boyunca ayn� veri durumu ve �zellikleri payla�mas� gereken senaryolarda faydal� olur.
//Bu nedenle, UpdateStudentCommandHandler'�n AddScoped olarak kaydedilmesi,
//bu i�leve ba�lamal� hizmet ya�am d�ng�s� atan�r ve genellikle HTTP iste�i s�resince ayn� �rne�in kullan�lmas�n� sa�lar.

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
