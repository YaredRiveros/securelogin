# 🔒 SQL Injection Demo

Proyecto educativo en ASP.NET Core que demuestra la diferencia entre un login vulnerable a SQL Injection y uno seguro que implementa consultas parametrizadas.

## ⚠️ Advertencia

**Este proyecto es SOLO para fines educativos.** El código vulnerable incluido nunca debe usarse en aplicaciones de producción.

## 🎯 Objetivo

Aprender sobre:
- Cómo funciona SQL Injection
- La diferencia entre código vulnerable y código seguro
- Implementación de consultas parametrizadas
- Riesgos de mostrar errores SQL al usuario

## 🚀 Cómo ejecutar

1. Asegúrate de tener .NET 8.0 SDK instalado
2. Navega al directorio del proyecto
3. Ejecuta:
   ```bash
   dotnet run
   ```
4. Abre tu navegador en `https://localhost:5001` o `http://localhost:5000`

## 📚 Usuarios de prueba

| Usuario | Contraseña | Rol   |
|---------|-----------|-------|
| admin   | admin123  | Admin |
| user1   | password1 | User  |
| juan    | secreto   | User  |

## 🔓 Login Vulnerable

**Ubicación:** `/VulnerableLogin`

### Características:
- ❌ Concatena directamente las entradas del usuario en la consulta SQL
- ❌ Muestra errores SQL completos en la página
- ❌ Vulnerable a bypass de autenticación

### Ejemplos de ataques que funcionan:

1. **Bypass de autenticación:**
   - Usuario: `admin' OR '1'='1`
   - Contraseña: (dejar vacío)

2. **Comentar el resto de la query:**
   - Usuario: `admin'--`
   - Usuario: `' OR 1=1 --`

3. **Acceder como cualquier usuario:**
   - Usuario: `' OR '1'='1`

### ¿Por qué es vulnerable?

```csharp
// ❌ CÓDIGO VULNERABLE
string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
```

Si un usuario ingresa `admin' OR '1'='1`, la consulta se convierte en:
```sql
SELECT * FROM Users WHERE Username = 'admin' OR '1'='1' AND Password = ''
```

Como `'1'='1'` siempre es verdadero, se devuelve un resultado sin necesidad de contraseña válida.

## 🔐 Login Seguro

**Ubicación:** `/SecureLogin`

### Características:
- ✅ Usa consultas parametrizadas
- ✅ Los parámetros son tratados como valores literales
- ✅ No muestra detalles de errores SQL
- ✅ Inmune a SQL Injection

### ¿Por qué es seguro?

```csharp
// ✅ CÓDIGO SEGURO
string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
command.Parameters.AddWithValue("@username", username);
command.Parameters.AddWithValue("@password", password);
```

Los parámetros (`@username`, `@password`) son:
- Escapados automáticamente
- Tratados como valores literales, no código SQL
- Protegidos contra caracteres especiales

Si un usuario intenta `admin' OR '1'='1`, el sistema busca un usuario llamado literalmente `admin' OR '1'='1`, que no existe.

## 🛡️ Mejores prácticas

1. **Siempre usa consultas parametrizadas** (prepared statements)
2. **Nunca concatenes entradas del usuario** en consultas SQL
3. **No muestres errores SQL** al usuario final
4. **Valida y sanitiza** todas las entradas
5. **Usa un ORM** como Entity Framework cuando sea posible
6. **Implementa el principio de mínimo privilegio** en la base de datos

## 📖 Recursos adicionales

- [OWASP SQL Injection](https://owasp.org/www-community/attacks/SQL_Injection)
- [Microsoft Docs - Consultas parametrizadas](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/configuring-parameters-and-parameter-data-types)
- [SQL Injection Prevention Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html)

## 🗂️ Estructura del proyecto

```
SqlInjectionDemo/
├── Controllers/
│   ├── HomeController.cs           # Página de inicio
│   ├── VulnerableLoginController.cs # Login vulnerable
│   └── SecureLoginController.cs    # Login seguro
├── Data/
│   └── AppDbContext.cs            # Contexto de Entity Framework
├── Models/
│   ├── User.cs                    # Modelo de usuario
│   └── LoginViewModel.cs          # ViewModel para login
├── Views/
│   ├── Home/
│   │   └── Index.cshtml           # Página principal
│   ├── VulnerableLogin/
│   │   └── Index.cshtml           # Vista del login vulnerable
│   ├── SecureLogin/
│   │   └── Index.cshtml           # Vista del login seguro
│   └── Shared/
│       └── _Layout.cshtml         # Layout principal
└── Program.cs                     # Configuración de la aplicación
```

## 🧪 Ejercicios sugeridos

1. Intenta todos los ejemplos de SQL Injection en el login vulnerable
2. Intenta los mismos ataques en el login seguro y observa la diferencia
3. Compara el código fuente de ambos controladores
4. Observa cómo se muestran los errores SQL en el login vulnerable
5. Analiza las consultas SQL generadas que se muestran en pantalla

## 💡 ¿Qué aprendí?

- La diferencia entre concatenación directa y consultas parametrizadas
- Cómo un atacante puede explotar SQL Injection
- Por qué no se deben mostrar errores SQL al usuario
- Cómo implementar código seguro contra SQL Injection

---

**Desarrollado con fines educativos - 2026**
