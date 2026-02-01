# 🎓 Guía de Uso - SQL Injection Demo

## 🚀 Inicio Rápido

### La aplicación está corriendo en: 
**http://localhost:5130**

Abre tu navegador y ve a esa dirección para comenzar.

---

## 📋 Paso a Paso

### 1. Página de Inicio
La página principal te muestra:
- Una explicación del propósito del proyecto
- Dos botones: uno para el login vulnerable y otro para el seguro
- Credenciales de prueba
- Objetivos de aprendizaje

### 2. Probar el Login Vulnerable 🔓

**Ruta:** http://localhost:5130/VulnerableLogin

#### Pruebas básicas:
1. **Login normal (funciona):**
   - Usuario: `admin`
   - Contraseña: `admin123`
   - ✅ Deberías poder iniciar sesión

2. **SQL Injection - Bypass de autenticación:**
   - Usuario: `admin' OR '1'='1`
   - Contraseña: (dejar vacío)
   - ⚠️ ¡Deberías poder iniciar sesión sin contraseña!

3. **SQL Injection - Comentar query:**
   - Usuario: `admin'--`
   - Contraseña: (cualquier cosa)
   - ⚠️ ¡Acceso concedido! Los `--` comentan el resto de la query

4. **SQL Injection - OR 1=1:**
   - Usuario: `' OR 1=1 --`
   - Contraseña: (cualquier cosa)
   - ⚠️ ¡Devuelve el primer usuario de la base de datos!

#### ¿Qué observar?
- 📝 La consulta SQL ejecutada se muestra en la página
- 🔍 Puedes ver cómo tu input modifica la query
- 💀 Los errores SQL completos se muestran (ayuda al atacante)
- ✅ La información del usuario se muestra cuando el ataque funciona

### 3. Probar el Login Seguro 🔐

**Ruta:** http://localhost:5130/SecureLogin

#### Prueba las mismas credenciales:
1. **Login normal (funciona):**
   - Usuario: `admin`
   - Contraseña: `admin123`
   - ✅ Acceso concedido

2. **Intentar SQL Injection:**
   - Usuario: `admin' OR '1'='1`
   - Contraseña: (cualquier cosa)
   - ❌ Credenciales incorrectas (¡el ataque no funciona!)

3. **Intentar otros ataques:**
   - Usuario: `admin'--`
   - Usuario: `' OR 1=1 --`
   - ❌ Ninguno funciona

#### ¿Qué observar?
- 📝 La consulta SQL usa parámetros (`@username`, `@password`)
- 🛡️ Los intentos de inyección se tratan como texto literal
- ❌ Los ataques simplemente fallan sin revelar información
- 🔒 No se muestran errores SQL detallados

---

## 🔬 Análisis del Código

### Código Vulnerable (VulnerableLoginController.cs)

```csharp
// ⚠️ PELIGRO: Concatenación directa
string query = $"SELECT * FROM Users WHERE Username = '{model.Username}' AND Password = '{model.Password}'";
```

**Problemas:**
- Las entradas del usuario se insertan directamente en la query
- Los caracteres especiales (`'`, `--`, `;`) se interpretan como SQL
- El atacante puede modificar la lógica de la consulta

### Código Seguro (SecureLoginController.cs)

```csharp
// ✅ SEGURO: Consultas parametrizadas
string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
command.Parameters.AddWithValue("@username", model.Username);
command.Parameters.AddWithValue("@password", model.Password);
```

**Ventajas:**
- Los parámetros se tratan como valores, no como código
- El driver escapa automáticamente caracteres especiales
- Imposible modificar la estructura de la query

---

## 💡 Ejemplos de Ataques Explicados

### Ejemplo 1: `admin' OR '1'='1`

**Query vulnerable construida:**
```sql
SELECT * FROM Users WHERE Username = 'admin' OR '1'='1' AND Password = ''
```

**¿Por qué funciona?**
- Se cierra la comilla del username con `'`
- Se agrega una condición `OR '1'='1'` que siempre es verdadera
- El password ya no importa
- Resultado: Se devuelve el usuario admin

**Query segura:**
```sql
SELECT * FROM Users WHERE Username = @username AND Password = @password
-- @username se trata como el texto literal: "admin' OR '1'='1"
-- Busca un usuario con ese nombre exacto (no existe)
```

### Ejemplo 2: `admin'--`

**Query vulnerable construida:**
```sql
SELECT * FROM Users WHERE Username = 'admin'--' AND Password = 'cualquier_cosa'
```

**¿Por qué funciona?**
- Se cierra la comilla con `'`
- Los `--` comentan el resto de la línea SQL
- La verificación de password es ignorada
- Resultado: Login como admin sin contraseña

**Query segura:**
- Busca un usuario llamado literalmente `admin'--`
- No existe, por lo tanto falla

### Ejemplo 3: `' OR 1=1 --`

**Query vulnerable construida:**
```sql
SELECT * FROM Users WHERE Username = '' OR 1=1 --' AND Password = ''
```

**¿Por qué funciona?**
- `1=1` siempre es verdadero
- Se devuelve el primer registro de la tabla Users
- Generalmente es un administrador

---

## 🎯 Ejercicios Sugeridos

### Nivel Principiante
1. ✅ Inicia sesión normalmente con credenciales válidas en ambos logins
2. ✅ Prueba `admin' OR '1'='1` en el login vulnerable
3. ✅ Intenta el mismo ataque en el login seguro y observa la diferencia

### Nivel Intermedio
4. 🔍 Compara las queries SQL mostradas en ambas páginas
5. 🔍 Observa qué errores se muestran en cada caso
6. 🔍 Lee el código fuente de ambos controladores y encuentra las diferencias

### Nivel Avanzado
7. 🧪 Intenta otros tipos de SQL injection:
   - `' UNION SELECT * FROM Users --`
   - `'; DROP TABLE Users; --` (tranquilo, no funcionará, pero intenta)
   - `admin' AND '1'='2' UNION SELECT * FROM Users --`
8. 🧪 Analiza por qué algunos ataques funcionan y otros no
9. 🧪 Modifica el código para agregar más vulnerabilidades o protecciones

---

## 📊 Tabla Comparativa

| Característica | Login Vulnerable 🔓 | Login Seguro 🔐 |
|----------------|---------------------|-----------------|
| Método de query | Concatenación directa | Parámetros |
| SQL Injection | ❌ Vulnerable | ✅ Protegido |
| Muestra errores SQL | ❌ Sí (peligroso) | ✅ No |
| Escapa caracteres | ❌ No | ✅ Sí (automático) |
| Seguro para producción | ❌ NUNCA | ✅ Sí |

---

## 🛑 Lo que NO debes hacer en producción

1. ❌ Concatenar entradas de usuario en queries SQL
2. ❌ Mostrar errores SQL completos al usuario
3. ❌ Confiar en validaciones del lado del cliente únicamente
4. ❌ Almacenar contraseñas en texto plano (usa hashing)
5. ❌ Tener usuarios de BD con más privilegios de los necesarios

## ✅ Lo que SÍ debes hacer en producción

1. ✅ Usar consultas parametrizadas (prepared statements)
2. ✅ Usar un ORM como Entity Framework cuando sea posible
3. ✅ Validar y sanitizar todas las entradas
4. ✅ Registrar errores en logs, no mostrarlos al usuario
5. ✅ Implementar el principio de mínimo privilegio
6. ✅ Hashear contraseñas con algoritmos seguros (bcrypt, Argon2)
7. ✅ Implementar limitación de intentos de login
8. ✅ Usar autenticación de dos factores (2FA)

---

## 🔗 Recursos Adicionales

- [OWASP Top 10 - A03:2021 Injection](https://owasp.org/Top10/A03_2021-Injection/)
- [SQL Injection Prevention Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/SQL_Injection_Prevention_Cheat_Sheet.html)
- [Microsoft - SQL Injection](https://learn.microsoft.com/en-us/sql/relational-databases/security/sql-injection)

---

## 🆘 Solución de Problemas

### La aplicación no inicia
```bash
cd SqlInjectionDemo
dotnet run
```

### No puedo acceder a la URL
- Verifica que la aplicación esté corriendo
- Busca en la salida de la terminal la línea: `Now listening on: http://localhost:XXXX`
- Usa ese puerto exacto

### Error de base de datos
- La base de datos se crea automáticamente al iniciar
- Si hay problemas, elimina `sqldemo.db` y reinicia la aplicación

---

## 🎓 Reflexión Final

Después de completar esta demo, deberías entender:

1. **Cómo funciona SQL Injection:** Los atacantes insertan código SQL en campos de entrada
2. **Por qué es peligroso:** Puede dar acceso no autorizado, filtrar datos o destruir información
3. **Cómo prevenirlo:** Usar consultas parametrizadas es la mejor defensa
4. **Buenas prácticas:** No confiar en datos del usuario, no mostrar errores detallados

**¡Ahora estás mejor preparado para escribir código seguro! 🎉**

---

**Recuerda: Este conocimiento es para defensa, no para ataque. Usa estos conocimientos responsablemente.**
