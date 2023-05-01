using ProyectoRecruiterAngularNet.Servicio;

var builder = WebApplication.CreateBuilder(args);

//Permite la configuracion del Cors, es decir se trata de dar permisos para api para poder consumirla
string cors = "ConfigurarCors";

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: cors, builder =>
    {
        builder.WithMethods("*");
        /*
         * Permite peticiones put, post, delete...
         */
        builder.WithHeaders("*");
        /*
         * Permite que la api esta abierta a todos, si quisiera que fuera mas cerrada solo pondria a la pagina que yo desee
         */
        builder.WithOrigins("*");
    });
});

builder.Services.AddScoped<IUsuarioApi, UsuarioApiServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(cors);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
