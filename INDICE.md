# 📚 Índice de Documentación - SQL Injection Demo

Bienvenido al proyecto educativo sobre SQL Injection. Esta página te ayudará a navegar por toda la documentación disponible.

---

## 🚀 ¿Por dónde empezar?

### Si tienes 5 minutos: → **[INICIO_RAPIDO.md](INICIO_RAPIDO.md)**
Guía express para probar rápidamente el proyecto.

### Si tienes 30 minutos: → **[GUIA_USO.md](GUIA_USO.md)**
Tutorial completo paso a paso con explicaciones detalladas.

### Si quieres entender la técnica: → **[README.md](README.md)**
Documentación técnica completa del proyecto.

---

## 📖 Documentos Disponibles

### 1. [INICIO_RAPIDO.md](INICIO_RAPIDO.md) ⚡
**Tiempo de lectura:** 5 minutos
**Para quién:** Usuarios que quieren probar rápidamente

**Contenido:**
- ✅ Tutorial de 5 minutos
- ✅ Ataques rápidos para copiar/pegar
- ✅ Usuarios de prueba
- ✅ Comandos básicos

**Comienza aquí si:** Quieres ver resultados inmediatos

---

### 2. [README.md](README.md) 📘
**Tiempo de lectura:** 15 minutos
**Para quién:** Desarrolladores que quieren entender el proyecto

**Contenido:**
- ✅ Descripción general del proyecto
- ✅ Cómo ejecutar la aplicación
- ✅ Estructura del código
- ✅ Diferencias entre código vulnerable y seguro
- ✅ Mejores prácticas
- ✅ Recursos adicionales

**Lee esto si:** Quieres una visión completa del proyecto

---

### 3. [GUIA_USO.md](GUIA_USO.md) 🎓
**Tiempo de lectura:** 30 minutos
**Para quién:** Personas que quieren aprender en profundidad

**Contenido:**
- ✅ Tutorial paso a paso
- ✅ Explicación de cada ataque
- ✅ Análisis del código vulnerable vs seguro
- ✅ Ejercicios sugeridos (principiante a avanzado)
- ✅ Tabla comparativa
- ✅ Mejores prácticas detalladas

**Lee esto si:** Quieres dominar el tema

---

### 4. [PAYLOADS.md](PAYLOADS.md) 💣
**Tiempo de lectura:** 20 minutos
**Para quién:** Personas que quieren practicar ataques

**Contenido:**
- ✅ 25+ payloads de SQL Injection
- ✅ Explicación de cada uno
- ✅ Queries SQL resultantes
- ✅ Técnicas avanzadas (UNION, Time-based, etc.)
- ✅ Tabla resumen de técnicas

**Usa esto si:** Quieres probar diferentes ataques

---

### 5. [INFORMACION.md](INFORMACION.md) ℹ️
**Tiempo de lectura:** 10 minutos
**Para quién:** Desarrolladores que necesitan referencia técnica

**Contenido:**
- ✅ Estructura del proyecto
- ✅ Tecnologías utilizadas
- ✅ Comandos útiles
- ✅ Información de la base de datos
- ✅ Recursos adicionales
- ✅ Ideas de extensión
- ✅ Troubleshooting

**Consulta esto si:** Necesitas detalles técnicos específicos

---

## 🎯 Rutas de Aprendizaje

### 🟢 Ruta Principiante (1 hora)
1. Lee [INICIO_RAPIDO.md](INICIO_RAPIDO.md) (5 min)
2. Abre http://localhost:5130 (2 min)
3. Prueba 3-5 ataques del [INICIO_RAPIDO.md](INICIO_RAPIDO.md) (15 min)
4. Lee secciones básicas de [GUIA_USO.md](GUIA_USO.md) (20 min)
5. Compara el código fuente (15 min)

**Resultado:** Entenderás qué es SQL Injection y cómo prevenirlo.

---

### 🟡 Ruta Intermedio (2 horas)
1. Lee [README.md](README.md) completo (15 min)
2. Lee [GUIA_USO.md](GUIA_USO.md) completo (30 min)
3. Prueba todos los ataques de [PAYLOADS.md](PAYLOADS.md) (45 min)
4. Analiza el código línea por línea (30 min)

**Resultado:** Comprenderás en profundidad SQL Injection y múltiples técnicas de ataque.

---

### 🔴 Ruta Avanzado (4+ horas)
1. Completa la Ruta Intermedio (2 hrs)
2. Implementa tus propios payloads (1 hr)
3. Modifica el código para agregar otras vulnerabilidades (1 hr)
4. Lee recursos externos y practica en otras plataformas (continuo)

**Resultado:** Serás capaz de identificar y prevenir SQL Injection en proyectos reales.

---

## 🌐 Enlaces a la Aplicación

### Página Principal
```
http://localhost:5130
```
Información general y acceso a ambos logins.

### Login Vulnerable
```
http://localhost:5130/VulnerableLogin
```
Probar ataques SQL Injection aquí.

### Login Seguro
```
http://localhost:5130/SecureLogin
```
Ver cómo se previene SQL Injection.

---

## 📊 Mapa Conceptual

```
                    SQL Injection Demo
                           |
        ┌──────────────────┼──────────────────┐
        ↓                  ↓                  ↓
   DOCUMENTOS          CÓDIGO            PRÁCTICA
        |                  |                  |
  ┌─────┴─────┐      ┌────┴────┐      ┌──────┴──────┐
  ↓     ↓     ↓      ↓    ↓    ↓      ↓      ↓      ↓
 README GUIA PAYLOADS MVC  DB  VIEWS  VULNER SECURE TEST
  ↓     ↓     ↓      ↓    ↓    ↓      ↓      ↓      ↓
[INFO][PASO][ATTACK][CODE][SQL][UI][EXPLOIT][SAFE][TRY]
```

---

## 🎓 Conceptos por Documento

### INICIO_RAPIDO.md
- Acceso rápido
- Usuarios de prueba
- Ataques básicos

### README.md
- SQL Injection: Qué es
- Concatenación vs Parámetros
- Mejores prácticas
- Estructura del proyecto

### GUIA_USO.md
- Paso a paso detallado
- Explicación de ataques
- Análisis de código
- Ejercicios prácticos
- Buenas prácticas

### PAYLOADS.md
- Bypass de autenticación
- Técnicas de comentarios
- UNION-based injection
- Time-based injection
- Error-based injection
- Boolean-based injection

### INFORMACION.md
- Tecnologías usadas
- Estructura de archivos
- Comandos útiles
- Troubleshooting
- Recursos externos

---

## 🎯 Preguntas Frecuentes

### ¿Qué documento leo primero?
→ **[INICIO_RAPIDO.md](INICIO_RAPIDO.md)** si quieres acción inmediata
→ **[README.md](README.md)** si quieres contexto primero

### ¿Dónde encuentro ejemplos de ataques?
→ **[PAYLOADS.md](PAYLOADS.md)** tiene 25+ ejemplos listos

### ¿Cómo sé si funciona?
→ Sigue la [GUIA_USO.md](GUIA_USO.md) paso a paso

### ¿Dónde está el código?
→ Carpeta `Controllers/` para la lógica
→ Carpeta `Views/` para las interfaces

### ¿Cómo detengo la app?
→ Ctrl+C en la terminal

---

## 📚 Glosario Rápido

- **SQL Injection:** Vulnerabilidad que permite ejecutar código SQL arbitrario
- **Payload:** Código malicioso que explota la vulnerabilidad
- **Concatenación:** Unir strings directamente (vulnerable)
- **Parámetros:** Variables especiales que se escapan automáticamente (seguro)
- **Bypass:** Eludir la autenticación sin credenciales válidas
- **OWASP:** Organización de seguridad web
- **Prepared Statements:** Consultas con parámetros (método seguro)

---

## 🔗 Enlaces Externos

### Seguridad Web
- [OWASP Top 10](https://owasp.org/www-project-top-ten/)
- [SQL Injection Cheat Sheet](https://portswigger.net/web-security/sql-injection/cheat-sheet)
- [OWASP SQL Injection](https://owasp.org/www-community/attacks/SQL_Injection)

### Práctica
- [PortSwigger Academy](https://portswigger.net/web-security)
- [OWASP WebGoat](https://owasp.org/www-project-webgoat/)
- [HackTheBox](https://www.hackthebox.com/)

### Documentación Técnica
- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [C# Docs](https://learn.microsoft.com/en-us/dotnet/csharp/)

---

## ✅ Checklist de Aprendizaje

Marca lo que has completado:

### Nivel 1: Fundamentos
- [ ] He abierto la aplicación en el navegador
- [ ] He probado login normal con credenciales válidas
- [ ] He probado mi primer ataque SQL Injection
- [ ] Entiendo la diferencia entre login vulnerable y seguro
- [ ] He leído el README.md

### Nivel 2: Práctica
- [ ] He probado al menos 5 payloads diferentes
- [ ] Entiendo cómo funcionan los comentarios SQL (`--`, `#`)
- [ ] Sé por qué `' OR '1'='1` funciona
- [ ] He comparado el código fuente de ambos controladores
- [ ] He leído la GUIA_USO.md completa

### Nivel 3: Dominio
- [ ] He probado todos los payloads de PAYLOADS.md
- [ ] Puedo explicar cada ataque a otra persona
- [ ] Entiendo las consultas parametrizadas en profundidad
- [ ] Puedo identificar SQL Injection en otro código
- [ ] Sé implementar código seguro contra SQL Injection

### Nivel 4: Maestría
- [ ] He creado mis propios payloads
- [ ] He modificado el código para agregar funcionalidades
- [ ] He practicado en otras plataformas de seguridad
- [ ] Puedo enseñar SQL Injection a otros
- [ ] Aplico estas prácticas en mis proyectos reales

---

## 🎉 ¡Comienza tu Viaje!

Elige tu documento de inicio:

1. **Quiero acción rápida** → [INICIO_RAPIDO.md](INICIO_RAPIDO.md)
2. **Quiero entender el proyecto** → [README.md](README.md)
3. **Quiero un tutorial completo** → [GUIA_USO.md](GUIA_USO.md)
4. **Quiero probar ataques** → [PAYLOADS.md](PAYLOADS.md)
5. **Quiero detalles técnicos** → [INFORMACION.md](INFORMACION.md)

---

## 🌟 Resumen Final

Este proyecto te enseña:
- ✅ Qué es SQL Injection
- ✅ Por qué es peligroso
- ✅ Cómo explotarlo (con fines educativos)
- ✅ Cómo prevenirlo
- ✅ Mejores prácticas de seguridad

**Todo en un entorno seguro y controlado para aprender.**

---

**¡Feliz aprendizaje! 🎓**

*Usa este conocimiento responsablemente para crear software más seguro.*
