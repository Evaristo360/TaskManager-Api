# TaskManager-Api

TaskManager-Api es una Web API desarrollada en .NET Core para la gestión de tareas. Proporciona un conjunto de endpoints para crear, actualizar, eliminar y consultar tareas.

## Configuración de la base de datos

Este proyecto está configurado para conectarse a una base de datos SQL Server. Los datos de conexión por defecto son los siguientes:

- **Server:** `SERVER`
- **Database:** `taskManagerDb`
- **Usuario:** `userTask`
- **Contraseña:** `t@skM@n@ger`

Asegúrate de que la base de datos esté configurada y corriendo antes de ejecutar el proyecto.

## Configuración del proyecto

1. Clona este repositorio en tu máquina local:

   ```
   git clone https://github.com/tu-usuario/taskmanager-api.git
   ```
2. Configura las variables de conexión a la base de datos en el archivo appsettings.json
  ```
  {
    "ConnectionStrings": {
      "DefaultConnection": "Server=SERVER;Database=taskManagerDb;UID=userTask;Password=t@skM@n@ger;"
    }
  } 
  ```
3. Restaura las dependencias del proyecto:
```
dotnet restore
```
## Migraciones y Base de Datos

El proyecto utiliza Entity Framework para manejar las migraciones de la base de datos, sigue los siguientes pasos para aplicar las migraciones:

1. Genera una migración (si aún no lo has hecho):
```
dotnet ef migrations add InitialCreate
```

2. Aplica las migraciones a la base de datos:
```
dotnet ef database update
```

## Ejecución del proyecto
Para ejecutar el proyecto localmente:
```
dotnet run
```

## Pruebas de la API
GET /api/tasks - Obtiene todas las tareas.

POST /api/tasks - Crea una nueva tarea.

PUT /api/tasks/{id} - Actualiza una tarea existente.

DELETE /api/tasks/{id} - Elimina una tarea.
