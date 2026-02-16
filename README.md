# PasteleriaApp 🧁

¡Bienvenido/a a PasteleriaApp! Este es un proyecto prototipo desarrollado por **Feith Noir** como parte del programa de **Análisis y Desarrollo de Software**. El objetivo es crear una aplicación web para gestionar inventarios, recetas y documentos básicos de una pastelería.

## ✨ Propósito del Proyecto

La idea es explorar y aplicar conceptos de desarrollo de software full-stack, creando una herramienta sencilla pero funcional que podría ayudar a una pequeña pastelería a:

*   Llevar un control de sus ingredientes.
*   Monitorear los niveles de inventario.
*   Definir y costear sus recetas.
*   Gestionar documentos importantes (facturas, permisos, etc.).

## 🚀 Features Principales (Planificadas)

*   **Gestión de Ingredientes:** Crear, editar, ver y eliminar ingredientes, incluyendo información como costo por unidad y proveedor.
*   **Control de Inventario:** Registrar la cantidad actual de cada ingrediente, establecer niveles mínimos y recibir alertas (o visualizar) cuando el stock esté bajo.
*   **Administración de Recetas:** Definir recetas detallando ingredientes, cantidades, instrucciones, calcular el costo total y sugerir un precio de venta.
*   **Gestión Documental:** Subir, almacenar y categorizar documentos relevantes para el negocio.
*   **Gestión de Usuarios:** (Probablemente usando ASP.NET Core Identity) Autenticación y roles básicos.

## 🛠️ Stack Tecnológico

Este proyecto combina tecnologías modernas para el desarrollo web:

*   **Backend:**
    *   **Framework:** .NET Core (C#) - Usando ASP.NET Core para la API RESTful.
    *   **Base de Datos:** MySQL
    *   **Acceso a Datos:** Implementado con el Patrón Repositorio. (Probablemente usando [Entity Framework Core / Dapper / Otro - *Elige el que uses o planees usar*] bajo el repositorio).
    *   **Autenticación:** ASP.NET Core Identity.
*   **Frontend:**
    *   **Framework:** Angular (TypeScript, HTML, CSS/SCSS).

## 🏗️ Arquitectura

La idea es crear una arquitectura organizada y mantenible:

*   **Enfoque General MVC (Backend):** Aunque desacoplado por la API, la estructura del backend sigue principios MVC para separar responsabilidades (Controladores API, Lógica de Negocio/Servicios, Modelo).
*   **Patrón Repositorio:** ¡Fundamental! Abstrae el acceso a datos de MySQL. La lógica de negocio interactúa con interfaces (`IRepository<T>`) en lugar de directamente con la base de datos, facilitando pruebas y mantenibilidad.
*   **Inyección de Dependencias (DI):** Aprovechamos el sistema de DI nativo de .NET Core para gestionar las dependencias entre capas (ej: inyectar repositorios en los servicios).
*   **Patrón Factory (Uso puntual):** Considerado para la creación controlada de objetos complejos si es necesario.
*   **DTOs (Data Transfer Objects):** Para una comunicación limpia y segura entre el backend (API) y el frontend (Angular).

## 💾 Modelo de Datos (MER Resumido)

El diseño de la base de datos se basa en un Modelo Entidad-Relación con las siguientes entidades principales:

*   `User` (Gestionado por Identity)
*   `Document`
*   `Ingredient`
*   `InventoryItem`
*   `Recipe`
*   `RecipeIngredient` (Tabla de unión para la relación N:N entre Recetas e Ingredientes)

Las relaciones clave incluyen: Usuario-Documento (1:N), Ingrediente-Inventario (1:1 o 1:N según diseño final), y la crucial Receta-Ingrediente (N:N).

## 🚀 Empezando (¡Prototipo!)

Como esto es un prototipo, los pasos exactos para ponerlo en marcha pueden evolucionar. Sin embargo, los prerrequisitos generales serían:

1.  **SDK de .NET Core:** [Enlace a la descarga de la versión que uses, ej: .NET 6 o 7]
2.  **Node.js y npm/yarn:** [Enlace a Node.js](https://nodejs.org/)
3.  **Angular CLI:** (`npm install -g @angular/cli`)
4.  **Un servidor MySQL:** Local o remoto, accesible para el backend.

**Pasos Generales (A Detallar):**

1.  Clonar este repositorio.
2.  Configurar la cadena de conexión a MySQL en el archivo `appsettings.json` (o similar) del proyecto backend.
3.  Si usas EF Core, aplicar las migraciones: `dotnet ef database update`.
4.  Navegar a la carpeta del backend y ejecutar: `dotnet run`.
5.  Navegar a la carpeta del frontend y ejecutar: `npm install` (o `yarn install`).
6.  Ejecutar el frontend: `ng serve -o` (el `-o` abre el navegador automáticamente).

## 💻 Uso

Una vez que ambos, backend y frontend, estén corriendo, deberías poder acceder a la aplicación desde tu navegador, usualmente en `http://localhost:4200`.

## 🙌 Contribuciones / Feedback

¡Este es un proyecto de aprendizaje! Cualquier comentario, sugerencia o idea constructiva es más que bienvenida.

## 📄 Licencia

Distribuido bajo la Licencia MIT. Ver `LICENSE` para más información.

## 🧑‍💻 Contacto

**Feith Noir** - [feithnoir@gmail.com]

**NyaraSoft S.A.S.** (¡La división académica!)