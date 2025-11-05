# 🍕 Sistema de Gestión de Productos y Ventas

Este es un sistema de gestión de productos y ventas desarrollado en C# con Windows Forms y SQL Server. El sistema permite administrar productos, realizar ventas y generar tickets de venta.

## 🏗️ Estructura del Proyecto

El proyecto está organizado en capas para separar las responsabilidades:

### 📁 Modelos
Contiene las clases que representan los datos del sistema:

- **Producto.cs**: Representa un producto con propiedades Id, Nombre, Precio y Stock.
- **Venta.cs**: Representa una venta con Id, Fecha, Lista de DetallesVenta y Total.
- **DetalleVenta.cs**: Representa un detalle de venta con Producto, Cantidad, PrecioUnitario y Subtotal.

### 📁 AccesoDatos
Maneja la comunicación con la base de datos:

- **ConexionBD.cs**: Gestiona la conexión a la base de datos y prueba la conectividad.
- **IRepositorioProductos.cs**: Interfaz que define las operaciones CRUD para productos.
- **RepositorioProductosSQL.cs**: Implementación concreta del repositorio para SQL Server.

### 📁 Servicios
Contiene la lógica de negocio:

- **ServicioProductos.cs**: Servicio que maneja las operaciones sobre productos (agregar, actualizar, vender, etc.).
- **ServicioVentas.cs**: Servicio que maneja el proceso de ventas y cálculo de totales.

### 📁 Formularios
Interfaz de usuario con Windows Forms:

- **FrmInicio**: Formulario principal con menú de opciones.
- **FrmAgregar**: Formulario para agregar nuevos productos.
- **FrmListar**: Formulario para listar todos los productos.
- **FrmModificar**: Formulario para modificar productos existentes.
- **FrmVender**: Formulario para realizar ventas de productos.
- **FrmTicket**: Formulario para mostrar el ticket de venta.

### 🔧 Archivos de Configuración y Entrada

- **Program.cs**: Punto de entrada de la aplicación, configura los servicios y lanza el formulario principal.
- **App.config**: Contiene la cadena de conexión a la base de datos.

## 🚀 Funcionalidades

### Gestión de Productos
- **Agregar Productos**: Validación de nombre, precio y stock.
- **Listar Productos**: Muestra todos los productos en una grilla.
- **Modificar Productos**: Permite editar los datos de un producto existente.
- **Eliminar Productos**: Elimina productos por ID.

### Proceso de Ventas
- **Vender Productos**: Permite seleccionar productos por ID, especificar cantidades y calcular totales.
- **Validación de Stock**: Verifica que haya suficiente stock antes de realizar una venta.
- **Ticket de Venta**: Genera un ticket con los detalles de la venta y el total.

### Base de Datos
- **Creación Automática de Tablas**: La aplicación crea la tabla `Productos` si no existe al iniciar.
- **Conexión Configurable**: La cadena de conexión se define en `App.config`.

## 🛠️ Tecnologías Utilizadas

- **C#** (.NET Framework 4.7.2)
- **Windows Forms** para la interfaz gráfica
- **SQL Server** como base de datos (puede ser local o en contenedor Docker)
- **System.Data.SqlClient** para el acceso a datos

