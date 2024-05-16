using Microsoft.EntityFrameworkCore; // Importa el espacio de nombres necesario para Entity Framework Core.
using Web.Components; // Importa el espacio de nombres del proyecto para los componentes.
using Web.Persistence; // Importa el espacio de nombres para la persistencia en la base de datos.

var builder = WebApplication.CreateBuilder(args); // Crea un nuevo constructor de la aplicación web.

// Agrega servicios al contenedor de inyección de dependencias.
builder.Services.AddRazorComponents() // Agrega servicios para Razor Components.
        .AddInteractiveServerComponents(); // Agrega servicios para componentes interactivos del servidor.

var connectionString = builder.Configuration.GetConnectionString("WebDb"); // Obtiene la cadena de conexión de la configuración.

// Agrega el contexto de la base de datos a los servicios.
builder.Services.AddDbContext<WebDbContext>(options =>
    options.UseNpgsql(connectionString)); // Configura el uso de PostgreSQL como proveedor de base de datos (Agarra la conexion con appsettings.json).

var option = new DbContextOptionsBuilder<WebDbContext>(); // Crea un constructor de opciones de contexto de base de datos.

option.UseNpgsql(connectionString); // Configura el uso de PostgreSQL como proveedor de base de datos y establece la cadena de conexión.

var context = new WebDbContext(option.Options); // Crea una nueva instancia del contexto de base de datos usando las opciones configuradas.

context.Database.EnsureCreated(); // Asegura que la base de datos esté creada. Si la base de datos no existe, se crea basándose en el modelo de datos. 


var app = builder.Build(); // Construye la aplicación.

// Configura el pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment()) // Verifica si no estamos en modo de desarrollo.
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true); // Maneja las excepciones y redirige a la página de error.
    app.UseHsts(); // Habilita HSTS (Strict Transport Security) para mejorar la seguridad.
}

app.UseHttpsRedirection(); // Redirecciona todas las solicitudes HTTP a HTTPS.
app.UseStaticFiles(); // Habilita el uso de archivos estáticos (CSS, imágenes, etc.).
app.UseAntiforgery(); // Agrega protección contra falsificación de solicitudes entre sitios (CSRF).

app.MapRazorComponents<App>() // Mapea los componentes Razor para la aplicación principal.
    .AddInteractiveServerRenderMode(); // Habilita el modo de renderizado interactivo del servidor para los componentes.

app.Run(); // Ejecuta la aplicación.