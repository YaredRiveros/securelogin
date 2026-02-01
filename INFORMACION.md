# 📖 SQL Injection Demo - Información del Proyecto

## ✅ Estado del Proyecto

Tu proyecto está **completamente configurado y funcionando**! 🎉

### 🌐 Acceso a la Aplicación

**URL:** http://localhost:5130

La aplicación está corriendo en segundo plano. Simplemente abre tu navegador y accede a esa dirección.

---

## 📁 Estructura del Proyecto

```
SqlInjectionDemo/
├── Controllers/
│   ├── HomeController.cs              # Página principal
│   ├── VulnerableLoginController.cs   # Login vulnerable (PELIGROSO)
│   └── SecureLoginController.cs       # Login seguro (CORRECTO)
│
├── Data/
│   └── AppDbContext.cs               # Contexto Entity Framework
│
├── Models/
│   ├── User.cs                       # Modelo de usuario
│   └── LoginViewModel.cs             # ViewModel para forms
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml              # Página de inicio
│   ├── VulnerableLogin/
│   │   └── Index.cshtml              # Vista login vulnerable
│   ├── SecureLogin/
│   │   └── Index.cshtml              # Vista login seguro
│   └── Shared/
│       └── _Layout.cshtml            # Layout de la app
│
├── sqldemo.db                        # Base de datos SQLite
├── README.md                         # Documentación principal
├── GUIA_USO.md                       # Guía paso a paso
├── PAYLOADS.md                       # Payloads de SQL Injection
└── INFORMACION.md                    # Este archivo
```

---

## 🎮 Cómo Usar

### 1. Acceder a la aplicación
Abre tu navegador en: **http://localhost:5130**

### 2. Navegar por las secciones
- **🏠 Inicio:** Explicación general y acceso a ambos logins
- **🔓 Login Vulnerable:** Probar ataques SQL Injection
- **🔐 Login Seguro:** Ver cómo se previene

### 3. Leer la documentación
- `README.md` - Información general del proyecto
- `GUIA_USO.md` - Tutorial paso a paso con ejemplos
- `PAYLOADS.md` - Lista de ataques SQL Injection para probar

---

## 🛑 Detener la Aplicación

Para detener el servidor, ve a la terminal y presiona:
```
Ctrl + C
```

O simplemente cierra la terminal.

---

## 🔄 Reiniciar la Aplicación

Si detienes la aplicación y quieres reiniciarla:

```powershell
cd c:\Users\yared\Documents\proyectos\vulnerabilidades-cshap\SqlInjectionDemo
dotnet run
```

---

## 👥 Usuarios de Prueba

La base de datos incluye estos usuarios:

| ID | Usuario | Contraseña | Email | Rol |
|----|---------|-----------|-------|-----|
| 1 | admin | admin123 | admin@demo.com | Admin |
| 2 | user1 | password1 | user1@demo.com | User |
| 3 | user2 | password2 | user2@demo.com | User |
| 4 | juan | secreto | juan@demo.com | User |

---

## 🧪 Flujo de Pruebas Recomendado

### Sesión 1: Entender el problema (15 min)
1. Lee la página de inicio
2. Abre el **Login Vulnerable**
3. Intenta login normal: `admin` / `admin123`
4. Ahora intenta: `admin' OR '1'='1` / (vacío)
5. Observa cómo accedes sin contraseña

### Sesión 2: Explorar ataques (20 min)
1. Abre `PAYLOADS.md`
2. Prueba 5-10 payloads diferentes en el Login Vulnerable
3. Observa los errores SQL que se muestran
4. Analiza las queries SQL ejecutadas

### Sesión 3: Ver la solución (15 min)
1. Abre el **Login Seguro**
2. Intenta los mismos ataques que funcionaron antes
3. Observa que ahora fallan
4. Compara las queries SQL mostradas

### Sesión 4: Análisis de código (30 min)
1. Abre `VulnerableLoginController.cs`
2. Abre `SecureLoginController.cs`
3. Compara línea por línea las diferencias
4. Entiende por qué uno es vulnerable y el otro no

---

## 🔍 Conceptos Clave Aprendidos

### ❌ Código Vulnerable
```csharp
// Concatenación directa = PELIGRO
string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
```

**Problema:** El input del usuario se interpreta como código SQL.

### ✅ Código Seguro
```csharp
// Parámetros = SEGURO
string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
command.Parameters.AddWithValue("@username", username);
command.Parameters.AddWithValue("@password", password);
```

**Solución:** El input del usuario se trata como datos, no código.

---

## 🎯 Objetivos de Aprendizaje

Al terminar este proyecto, deberías poder:

- ✅ Explicar qué es SQL Injection
- ✅ Identificar código vulnerable a SQL Injection
- ✅ Implementar consultas parametrizadas
- ✅ Entender por qué no se deben mostrar errores SQL
- ✅ Aplicar estas prácticas en tus propios proyectos

---

## 🔧 Tecnologías Utilizadas

- **ASP.NET Core 8.0** - Framework web
- **C#** - Lenguaje de programación
- **Entity Framework Core** - ORM
- **SQLite** - Base de datos ligera
- **Razor Pages** - Motor de vistas
- **Bootstrap 5** - Estilos CSS

---

## 📊 Estadísticas del Proyecto

- **Controladores:** 3
- **Vistas:** 4
- **Modelos:** 2
- **Usuarios de prueba:** 4
- **Payloads de ejemplo:** 25+
- **Líneas de código:** ~800

---

## 🛠️ Comandos Útiles

### Compilar el proyecto
```powershell
dotnet build
```

### Ejecutar el proyecto
```powershell
dotnet run
```

### Limpiar compilaciones anteriores
```powershell
dotnet clean
```

### Restaurar paquetes NuGet
```powershell
dotnet restore
```

### Ver información del proyecto
```powershell
dotnet --info
```

---

## 🗃️ Base de Datos

### Archivo
- **Nombre:** `sqldemo.db`
- **Tipo:** SQLite 3
- **Ubicación:** Raíz del proyecto

### Recrear base de datos
Si quieres resetear la BD:
1. Detén la aplicación (Ctrl+C)
2. Elimina `sqldemo.db`
3. Ejecuta `dotnet run` (se recrea automáticamente)

### Ver contenido de la BD
Puedes usar herramientas como:
- [DB Browser for SQLite](https://sqlitebrowser.org/)
- [SQLite Viewer (VS Code Extension)](https://marketplace.visualstudio.com/items?itemName=qwtel.sqlite-viewer)

---

## 📚 Recursos Adicionales

### Documentación Oficial
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)

### Seguridad
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [SQL Injection Prevention](https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html)
- [Secure Coding Guidelines](https://learn.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines)

### Práctica
- [OWASP WebGoat](https://owasp.org/www-project-webgoat/)
- [PortSwigger Web Security Academy](https://portswigger.net/web-security)
- [HackTheBox](https://www.hackthebox.com/)

---

## 💡 Ideas de Extensión

Si quieres expandir este proyecto:

1. **Agregar más vulnerabilidades:**
   - XSS (Cross-Site Scripting)
   - CSRF (Cross-Site Request Forgery)
   - Path Traversal

2. **Mejorar la seguridad:**
   - Hashear contraseñas (bcrypt)
   - Implementar rate limiting
   - Agregar CAPTCHA

3. **Funcionalidades adicionales:**
   - Panel de administración
   - Log de intentos de login
   - Dashboard con estadísticas

4. **Testing:**
   - Tests unitarios
   - Tests de integración
   - Tests de seguridad automatizados

---

## 🤝 Contribuciones

Este es un proyecto educativo personal. Si quieres:
- Reportar bugs
- Sugerir mejoras
- Compartir feedback

¡Siéntete libre de hacerlo!

---

## ⚖️ Licencia y Uso Responsable

### Uso Permitido ✅
- Aprendizaje personal
- Enseñanza en instituciones educativas
- Demostraciones de seguridad
- Investigación en seguridad

### Uso NO Permitido ❌
- Atacar sistemas sin autorización
- Uso malicioso en entornos de producción
- Distribución de malware basado en este código

**Recuerda:** El conocimiento es para defender, no para atacar.

---

## 📞 Soporte

### Si algo no funciona:

1. **La aplicación no inicia**
   - Verifica que .NET 8.0 esté instalado: `dotnet --version`
   - Compila el proyecto: `dotnet build`
   - Revisa los errores en la terminal

2. **No puedo acceder a localhost:5130**
   - Verifica que la aplicación esté corriendo
   - Busca el puerto correcto en la salida de la terminal
   - Prueba con: `http://localhost:5130` y `https://localhost:7130`

3. **Errores de base de datos**
   - Elimina `sqldemo.db` y reinicia la app
   - Verifica permisos de escritura en el directorio

4. **Los ataques no funcionan**
   - Asegúrate de estar en `/VulnerableLogin`, no en `/SecureLogin`
   - Copia y pega los payloads exactamente como están
   - Revisa `PAYLOADS.md` para más ejemplos

---

## 🎓 Próximos Pasos

Después de completar este proyecto:

1. ✅ Practica en plataformas de seguridad web
2. ✅ Lee sobre otras vulnerabilidades OWASP Top 10
3. ✅ Implementa código seguro en tus proyectos
4. ✅ Comparte tu conocimiento con otros
5. ✅ Considera certificaciones en ciberseguridad

---

## 🌟 Agradecimientos

Este proyecto fue creado con fines educativos para enseñar sobre:
- Vulnerabilidades de seguridad web
- SQL Injection y su prevención
- Buenas prácticas de programación segura

**¡Gracias por aprender y practicar seguridad responsablemente!** 🛡️

---

**Proyecto creado en enero 2026**

**Versión:** 1.0
**Framework:** ASP.NET Core 8.0
**Lenguaje:** C#
