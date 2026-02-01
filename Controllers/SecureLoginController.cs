using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SqlInjectionDemo.Data;
using SqlInjectionDemo.Models;
using System.Text;

namespace SqlInjectionDemo.Controllers
{
    public class SecureLoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public SecureLoginController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            try
            {
                // ✅ CÓDIGO SEGURO - Uso de consultas parametrizadas
                string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";

                ViewBag.Query = query; // Mostrar la consulta para fines educativos

                using (var connection = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection") ?? "Data Source=sqldemo.db"))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(query, connection))
                    {
                        // Los parámetros evitan la inyección SQL
                        command.Parameters.AddWithValue("@username", model.Username);
                        command.Parameters.AddWithValue("@password", model.Password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var username = reader["Username"].ToString();
                                var role = reader["Role"].ToString();
                                ViewBag.Success = true;
                                ViewBag.Message = $"¡Bienvenido {username}! Tu rol es: {role}";
                                
                                // Mostrar datos del usuario autenticado
                                var userInfo = new StringBuilder();
                                userInfo.AppendLine($"ID: {reader["Id"]}");
                                userInfo.AppendLine($"Usuario: {reader["Username"]}");
                                userInfo.AppendLine($"Email: {reader["Email"]}");
                                userInfo.AppendLine($"Rol: {reader["Role"]}");
                                ViewBag.UserInfo = userInfo.ToString();

                                return View(model);
                            }
                            else
                            {
                                ViewBag.Success = false;
                                ViewBag.Message = "Credenciales incorrectas";
                                return View(model);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // En producción, no se deben mostrar detalles de errores
                ViewBag.Success = false;
                ViewBag.Message = "Error al procesar la solicitud. Por favor, inténtelo de nuevo.";
                // Log del error (no mostrar al usuario)
                Console.WriteLine($"Error: {ex.Message}");
                return View(model);
            }
        }
    }
}
