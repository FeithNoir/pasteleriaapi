# PasteleriaApp API 🧁 (Backend Refactored)

¡Bienvenido/a a la API de **PasteleriaApp**! Este es un backend robusto desarrollado por **Feith Noir** y optimizado para una gestión eficiente de una pastelería moderna.

## ✨ Propósito del Proyecto

Este backend proporciona una base sólida, escalable y profesional para gestionar:

*   **Ingredientes:** Base de datos centralizada de materias primas con costos y proveedores.
*   **Inventario:** Control de stock en tiempo real con alertas de niveles bajos.
*   **Recetas:** Definición detallada de recetas con cálculo automático de costos.
*   **Documentación:** Registro y gestión de documentos importantes del negocio.
*   **Seguridad:** Sistema de autenticación JWT y roles (`Admin`, `User`, `Visitor`).

## 🛠️ Stack Tecnológico (Actualizado)

*   **Backend:**
    *   **Framework:** .NET 8.0 (C#) - ASP.NET Core API.
    *   **Base de Datos:** SQLite (para desarrollo ágil) - `pasteleriapp.db`.
    *   **Acceso a Datos:** Entity Framework Core con Patrón Repositorio.
    *   **Mapeo de Objetos:** AutoMapper para una comunicación limpia entre capas.
    *   **Autenticación:** ASP.NET Core Identity con JWT Bearer Tokens.
    *   **Documentación:** Swagger (OpenAPI) con soporte para XML comments.

## 🏗️ Arquitectura y Mejores Prácticas

*   **Clean Architecture:** Separación clara entre `Data`, `Business`, `Shared` y `API`.
*   **Patrón Repositorio:** Abstracción total del acceso a datos, facilitando pruebas unitarias.
*   **DTOs Optimizados:** Uso de objetos de transferencia de datos para evitar redundancias y fugas de entidades al cliente.
*   **Inyección de Dependencias:** Gestión nativa de servicios y repositorios.
*   **Respuestas Estandarizadas:** Todas las respuestas de la API siguen el formato `ApiResponse<T>`, garantizando coherencia para el frontend.

## 💾 Modelo de Datos (Principales Entidades)

*   `User` (Gestionado por ASP.NET Identity)
*   `Ingredient` (Materias primas)
*   `InventoryItem` (Stock de ingredientes)
*   `Recipe` (Ficha técnica de productos)
*   `RecipeIngredient` (Relación ingredientes-receta)
*   `Document` (Registro documental)

## 🚀 Empezando con el Backend

1.  **SDK de .NET 8.0:** Asegúrate de tener instalada la última versión de .NET.
2.  **Configuración:** Revisa `appsettings.json` para las claves JWT y la ruta de la base de datos SQLite.
3.  **Base de Datos:** El proyecto ya incluye una base de datos SQLite preconfigurada. Si deseas reiniciarla, usa: `dotnet ef database update`.
4.  **Ejecutar:** `dotnet run` dentro de la carpeta `BaseApi`.
5.  **Swagger:** Accede a `http://localhost:5000/swagger` para ver la documentación interactiva.

---

## 🧑‍💻 Desarrollado por: **Feith Noir**
### Optimizado por: **Gemini CLI (Senior Developer Mode)**
