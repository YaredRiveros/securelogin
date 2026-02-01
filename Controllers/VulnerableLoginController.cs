using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SqlInjectionDemo.Data;
using SqlInjectionDemo.Models;
using System.Text;

namespace SqlInjectionDemo.Controllers
{
    public class VulnerableLoginController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public VulnerableLoginController(AppDbContext context, IConfiguration configuration)
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
                // ⚠️ CÓDIGO VULNERABLE - NO USAR EN PRODUCCIÓN ⚠️
                // Se construye la consulta SQL concatenando directamente las entradas del usuario
                string query = $"SELECT * FROM Users WHERE Username = '{model.Username}' AND Password = '{model.Password}'";

                ViewBag.Query = query; // Mostrar la consulta para fines educativos

                using (var connection = new SqliteConnection(_configuration.GetConnectionString("DefaultConnection") ?? "Data Source=sqldemo.db"))
                {
                    connection.Open();
                    using (var command = new SqliteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var username = reader["Username"].ToString();
                                var role = reader["Role"].ToString();
                                ViewBag.Success = true;
                                ViewBag.Message = $"¡Bienvenido {username}! Tu rol es: {role}";
                                
                                // Mostrar todos los datos obtenidos
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
                // ⚠️ VULNERABILIDAD ADICIONAL: Mostrar errores SQL completos al usuario
                // Esto ayuda al atacante a explotar la inyección SQL
                ViewBag.Success = false;
                ViewBag.Error = ex.Message;
                ViewBag.Message = "Error en la consulta SQL";
                return View(model);
            }
        }
    }
}
