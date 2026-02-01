# 🚀 Inicio Rápido - SQL Injection Demo

## ✅ ¡Tu proyecto está listo!

### 🌐 Accede aquí:
```
http://localhost:5130
```

---

## 📖 Guías Disponibles

1. **README.md** - Documentación técnica del proyecto
2. **GUIA_USO.md** - Tutorial paso a paso (¡EMPIEZA AQUÍ!)
3. **PAYLOADS.md** - Ataques SQL Injection para probar
4. **INFORMACION.md** - Detalles técnicos y recursos

---

## 🎯 Tutorial Rápido de 5 Minutos

### 1️⃣ Ve a la página principal
```
http://localhost:5130
```
Lee la información presentada.

### 2️⃣ Prueba el Login Vulnerable
```
http://localhost:5130/VulnerableLogin
```
- **Intenta:** Usuario: `admin' OR '1'='1` | Contraseña: (vacía)
- **Resultado:** ¡Accedes sin contraseña! 😱

### 3️⃣ Prueba el Login Seguro
```
http://localhost:5130/SecureLogin
```
- **Intenta:** El mismo ataque anterior
- **Resultado:** ¡El ataque falla! ✅

### 4️⃣ Compara el código
Abre estos archivos en tu editor:
- `Controllers/VulnerableLoginController.cs` (línea ~24-28)
- `Controllers/SecureLoginController.cs` (línea ~24-28)

**Observa la diferencia:**
```csharp
// ❌ Vulnerable
string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";

// ✅ Seguro
string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
command.Parameters.AddWithValue("@username", username);
command.Parameters.AddWithValue("@password", password);
```

---

## 👥 Usuarios de Prueba

| Usuario | Contraseña | Rol |
|---------|-----------|-----|
| admin | admin123 | Admin |
| user1 | password1 | User |
| juan | secreto | User |

---

## 💣 Ataques Rápidos para Probar

Copia y pega en el **Login Vulnerable**:

### Bypass #1
```
Usuario: admin' OR '1'='1
Contraseña: (vacío)
```

### Bypass #2
```
Usuario: admin'--
Contraseña: (cualquiera)
```

### Bypass #3
```
Usuario: ' OR 1=1 --
Contraseña: (cualquiera)
```

### Bypass #4
```
Usuario: ' OR '1'='1
Contraseña: ' OR '1'='1
```

---

## 🎓 ¿Qué Aprenderás?

✅ Cómo funciona SQL Injection
✅ Por qué es peligroso
✅ Cómo prevenirlo con código seguro
✅ Buenas prácticas de seguridad

---

## 🛑 Detener el Servidor

En la terminal, presiona:
```
Ctrl + C
```

---

## 🔄 Reiniciar el Servidor

```powershell
cd SqlInjectionDemo
dotnet run
```

---

## 📚 Flujo de Aprendizaje

```
1. Lee README.md (5 min)
   ↓
2. Abre http://localhost:5130 (2 min)
   ↓
3. Prueba Login Vulnerable con ataques (10 min)
   ↓
4. Prueba Login Seguro con los mismos ataques (5 min)
   ↓
5. Compara el código fuente (10 min)
   ↓
6. Lee GUIA_USO.md para profundizar (15 min)
   ↓
7. Prueba todos los payloads de PAYLOADS.md (30 min)
   ↓
8. ¡Aplica lo aprendido en tus proyectos! 🎉
```

---

## 🔥 Highlights del Proyecto

- ✅ **2 Logins completos:** Vulnerable vs Seguro
- ✅ **Base de datos SQLite:** Con usuarios de prueba
- ✅ **Errores SQL visibles:** En el login vulnerable (para aprender)
- ✅ **25+ Payloads:** Listos para probar
- ✅ **Documentación completa:** 4 archivos de guías
- ✅ **Código comentado:** Para entender cada línea

---

## 💡 Consejo Pro

**No te limites a copiar y pegar los ataques.**

1. Lee cada payload
2. Entiende por qué funciona
3. Observa la query SQL resultante
4. Compara con el login seguro
5. Comprende la solución

---

## 🎯 Desafío Final

Después de probar todos los ataques:

1. ¿Puedes explicar por qué `admin' OR '1'='1` funciona?
2. ¿Por qué los comentarios `--` ayudan al atacante?
3. ¿Qué hace exactamente `Parameters.AddWithValue()`?
4. ¿Podrías identificar SQL Injection en otro código?

---

## 🌟 ¡Listo para comenzar!

Abre tu navegador y ve a:
# 🌐 http://localhost:5130

**¡Feliz hacking ético!** 🛡️

---

*Proyecto creado para fines educativos*
*Usa este conocimiento responsablemente*
