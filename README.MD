# 🍕 Pizzeria POS API 🍕

Este proyecto consiste en un API diseñado para operar como un sistema de punto de venta (`POS`) específicamente diseñado para una pizzería, facilitando la generación eficiente de órdenes.

## Instalación

Para configurar y ejecutar este proyecto en tu entorno local, sigue estos pasos:

- **Clonar el Repositorio:**

```bash
git clone https://github.com/EFZR/Pizzeria-POS.git
```

- **Instalar Dependencias:**

```bash
dotnet build
```

- **Configuración de Variables de Entorno:**

> Asegúrate de configurar las variables de entorno necesarias, como la conexión a la base de datos. Puedes encontrar estas configuraciones en el archivo `Service/Service.PizzaPos/appsettings.Development`.

- **Ejecutar la Aplicación:**

```bash
dotnet watch run --project Service/Service.PizzaPos
```

Este comando iniciará el servidor en modo de desarrollo y te permitirá acceder a la documentación de cada API.
