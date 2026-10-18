using Tarea_3.Interfaz;
using Tarea_3.Interfaz.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ILibroRepository, LibroRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
//Este es el que me permite pedir recursos a los controllers
app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
//<--Como funciona Map.ControllerRoute -->
//1) Mapeo Todos los controladores:
//La instruccion app.MapControllerRoute Mapea todos los controladores (Archivos.cs que heredan Controller como "public class HomeController : Controller")

//2) Agrego una ruta por defecto: 
//La instruccion app.MapControllerRoute tambien define la ruta default
//Si el usuario no inserta una URL especifica y solo entra a "/", se ejecuta la operacio Index de HomeController

//Observaciones que note:
//1: No tengo que crear un Controlador General porque de eso se encarga el framwork, yo configuro la forma de acceder usando MapControllerRoute.
//De la forma en que lo configure:
//Si desde el navegador pido el recurso "http://localhost:5262/Vehiculo/GetAllVehiculos" el frameork sabe que tiene que llamar al controlador Vehiculo y pedir el recurso GetAllVechiulos

//2: En Programacion de Aplicaciones con java era mas manual:
//Si le mandaba la URL "http://localhost:5262/Vehiculo/GetAllVehiculos" Tenia que hacer un Controlador General que tomara esa URL y pedir al VehiculoController el recurso "GerAllVehiculos"

//3: Si usara app.MapControllers() en lugar de app.MapControllerRoute(...),
//tendría que definir las rutas mediante atributos en los controladores y sus acciones.
//No se crearía automáticamente la ruta por convención /controlador/accion/id.

//Por ejemplo, si VehiculoController tiene [Route("Vehiculo")]
//y el método GetAllVehiculos tiene [HttpGet("GetAllVehiculos")],
//la URL sería: http://localhost:5262/Vehiculo/GetAllVehiculos
//
//En este caso la URL queda igual, pero está definida por los atributos.
//Si cambiara el atributo del método a [HttpGet("Listado")],
//la URL sería: http://localhost:5262/Vehiculo/Listado,
//aunque el método se siga llamando GetAllVehiculos.
//
//También tendría que definir mediante atributos qué acción responde a "/".
//Seguiría necesitando builder.Services.AddControllersWithViews().

//En resumen lo unico que cambiaria es que es que en lugar de usar el nombre de la funcion en la url usaria el de la ruta que defino arriba

app.Run();